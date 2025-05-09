using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Services.Helpers.Emails
{
    public class ForgetPasswordEmail : IEmailStructure
    {
       

        public string Body { get; }

        public string To {get; }

        public string Subject { get; }

        public ForgetPasswordEmail(string to, string displayName, string resetLink)
        {
          
         To = to;
            Subject = "ForgetPassword Email";
            Body  = $@"
    <div style='font-family: Arial, sans-serif; line-height: 1.6; color: #333; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px;'>
        <h1 style='color: #555;'>Reset Your Password</h1>
        <p>Hello {displayName},</p>
        <p>We received a request to reset your password. If you made this request, please click the link below to reset your password:</p>
        <p style='text-align: center; margin: 20px 0;'>
            <a href='{resetLink}' 
               style='background-color: #007BFF; color: white; text-decoration: none; padding: 10px 20px; border-radius: 5px; display: inline-block;'>
               Reset Password
            </a>
        </p>
        <p>If you did not request a password reset, you can safely ignore this email. Your password will remain secure, and no action is required.</p>
        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;'/>
        <p style='font-size: 0.9em; color: #555;'>If the button above does not work, copy and paste the following link into your browser:</p>
        <p style='font-size: 0.9em; color: #007BFF; word-break: break-word;'>{resetLink}</p>
        <p style='font-size: 0.9em; color: #999;'>Thank you for using our services!</p>
    </div>";


        }



    }

}
