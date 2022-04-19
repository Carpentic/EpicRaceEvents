using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService;

public class Sender : ISender
{
    private readonly Config _config;

    public Sender(Config config)
    {
        _config = config;
    }

    public void SendEmail(Message message)
    {
        Send(CreateEmailMessage(message));
    }

    public async Task SendEmailAsync(Message message)
    {
        await SendAsync(CreateEmailMessage(message));
    }

    private void Send(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_config.SmtpServer, _config.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_config.UserName, _config.Password);

                client.Send(mailMessage);
            }
            catch
            {
                throw new Exception("Could not send email");
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(_config.SmtpServer, _config.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_config.UserName, _config.Password);

                await client.SendAsync(mailMessage);
            }
            catch
            {
                throw new Exception("Could not send email");
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_config.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

        if (message.Attachments != null && message.Attachments.Any())
        {
            byte[] fileBytes;
            foreach (var attachment in message.Attachments)
            {
                using (var ms = new MemoryStream())
                {
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            }
        }
        emailMessage.Body = bodyBuilder.ToMessageBody();

        return emailMessage;
    }
}
