using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CusjoTestBusinessLayer;
using System.Data;
using CusjoInterface;
using CusjoDataAccessLayer;
using System.Data.Entity;

namespace SendEmailTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> unVerifiedUserList = GetUnVerifiedUser();
            try
            {
                if(unVerifiedUserList.Count > 0)
                {
                    foreach (User user in unVerifiedUserList)
                    {
                        if (SendEmailToUser(user))
                        {
                            Console.WriteLine($"Verification Email Sent to User Id {user.UserId}");
                            UpdateEmailSendCount(user);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No New Register User");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While running the Job {0}", ex);
            }
        }
        private static List<User> GetUnVerifiedUser()
        {
            try
            {
                using (CusJoDBContext db = new CusJoDBContext())
                {
                    return db.Users.Where(item => item.IsVerified == 0 && item.Retries <=3).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetcing the details from DB {ex.ToString()}");
            }
            return null;
        }
        private static bool SendEmailToUser(User user)
        {
            try
            {
                EmailComponent emailComponent = new EmailComponent("smtp.gmail.com", 587);
                emailComponent.EmailMessage = GetVerificationEmailBody(user);
                emailComponent.Subject = "Cusjo - Verification Email";
                emailComponent.ToAddress = user.UserEmail;
                emailComponent.CcAddress = "";
                emailComponent.FromAddress = "";
                emailComponent.UserName = "";
                emailComponent.Password = "";
                emailComponent.SendEmail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While Processing the Email {0}", ex);
                return false;
            }
            return true;
        }
        private static string GenerateUserLink(User user)
        {
            return $"http://localhost:61400/Login/VerifyEmail/{user.UserId}";
        }
        private static string GetVerificationEmailBody(User user) 
        {
            string messgae = $"Hi {user.UserFirstName}, \nThanks for Registering with us. \n" +
                $"Please click below link to verify your account. \n" +
                $"{GenerateUserLink(user)} \n" +
                $"Thank You, \n" +
                $"CusJo Team";
            return messgae;
        }
        private static void UpdateEmailSendCount(User user)
        {
            try
            {
                using (CusJoDBContext context = new CusJoDBContext())
                {
                    User existingUser = context.Users
                        .Where(u => u.UserId == user.UserId)
                        .FirstOrDefault<User>();
                    existingUser.Retries += 1;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
