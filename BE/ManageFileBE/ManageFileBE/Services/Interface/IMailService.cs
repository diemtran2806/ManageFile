using ManageFileBE.Dto;

namespace ManageFileBE.Service.Interface
{
    public interface IMailService
    {
        public void SendEmail(MailRequest mailRequest);
    }
}
