using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWeb2024.Utility
{
    public class EmailSender : IEmailSender
    {
        // FAKE EMAIL SENDER:
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // LOGIC TO SEND EMAIL
            return Task.CompletedTask;
        }
    }
}
