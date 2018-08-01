using Net.Core.Utility;
using Net.Core.ViewModels.Identity.WebApi;

namespace Net.Core.Mails
{

    public class UserPdfResultsMail : RootMail
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public UserPdfResultsMail(IdentityUserViewModel user)
        {
            this.Subject = AppMessages.Email_PdfResult_Subject;
            this.Email = user.Email;
            this.UserName = user.UserName;
        }

        public override string RenderHtml()
        {
            Content = LoadHtmlFromFile(AppProperties.BasePhysicalPath + AppConstants.EmailTemplates + "UserPdfResultsMail.htm");
            Content = Content.Replace("{{UserName}}", UserName);
            Content = Content.Replace("{{Email}}", Email);

            return base.RenderHtml();
        }
    }

}
