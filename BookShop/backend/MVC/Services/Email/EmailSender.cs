using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MVC.Utility;

namespace MVC.Services.Email
{
  /// <summary>
  /// Class EmailSender.
  /// Implements IEmailSender
  /// </summary>
  public class EmailSender : IEmailSender
  {
    /// <summary>
    /// Logger
    /// </summary>
    private readonly ILogger<EmailSender> _logger;

    /// <summary>
    /// EmailOptions
    /// </summary>
    public EmailOptions Options { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="emailOptions">EmailOptions</param>
    /// <param name="logger">ILogger</param>
    public EmailSender(IOptions<EmailOptions> emailOptions,
      ILogger<EmailSender> logger)
    {
      _logger = logger;
      Options = emailOptions.Value;
    }

    /// <summary>
    /// Method sends email to Mailtrap.io
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="subject">Subject</param>
    /// <param name="message">Message</param>
    /// <returns>void</returns>
    public async Task SendEmailAsync(string email, string subject,
      string message)
    {
      var emailMessage = new MimeMessage();

      emailMessage.From.Add(
        new MailboxAddress(SD.AppName, SD.AdminEmail)
      );
      emailMessage.To.Add(new MailboxAddress("", email));
      emailMessage.Subject = subject;
      emailMessage.Body = new TextPart(TextFormat.Html)
      {
        Text = message
      };

      try
      {
        using (var client = new SmtpClient())
        {
          await client.ConnectAsync(Options.MailHost,
            Convert.ToInt32(Options.MailPort), false);
          await client.AuthenticateAsync(Options.MailUserName,
            Options.MailPassword);
          await client.SendAsync(emailMessage);

          await client.DisconnectAsync(true);
        }
      }
      catch (Exception e)
      {
        _logger.LogError(e, "Emailing fails!");
      }
    }
  }
}
