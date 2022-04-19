namespace EmailService;

public interface ISender
{
    void SendEmail(Message message);
    Task SendEmailAsync(Message message);
}
