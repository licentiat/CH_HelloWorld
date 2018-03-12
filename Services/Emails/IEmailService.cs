namespace Nh.Services.Emails
{
    public interface IEmailService
    {
        void SendEmailAsync(EmailRequest emailRequest);
    }

}
