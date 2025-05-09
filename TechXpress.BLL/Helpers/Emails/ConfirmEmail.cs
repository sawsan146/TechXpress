using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Services.Helpers.Emails;

namespace TechXpress.Services.Helpers.Emails
{
    public class ConfirmEmail : IEmailStructure
    {
        public string To { get  ; private set  ; }
       
     
        public string Body { get; private set; }

        public string Subject { get; }

        public ConfirmEmail(string to,string displayName,string confirmLink)
        {
            To = to;
            Subject = "Confirmation Email";
            Body  = $@"
    <div style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px;'>
        <h1 style='color: #555;'>Welcome, {displayName}!</h1>
        <p>We’re excited to have you join our community. To complete your registration, please confirm your email address by clicking the link below:</p>
        <p style='text-align: center; margin: 20px 0;'>
            <a href='{confirmLink}' 
               style='background-color: #007BFF; color: white; text-decoration: none; padding: 10px 20px; border-radius: 5px; display: inline-block;'>
               Confirm Email Address
            </a>
        </p>
        <p>If you did not create an account, you can safely ignore this email.</p>
        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;'/>
        <p style='font-size: 0.9em; color: #555;'>If the button above does not work, copy and paste the following link into your browser:</p>
        <p style='font-size: 0.9em; color: #007BFF; word-break: break-word;'>{confirmLink}</p>
        <p style='font-size: 0.9em; color: #999;'>Thank you for choosing us!</p>
    </div>";
          
        }



    }
}
