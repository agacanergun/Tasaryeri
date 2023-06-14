using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        IFooterTransactions footerTransactions;
        public FooterViewComponent(IFooterTransactions footerTransactions)
        {
            this.footerTransactions = footerTransactions;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM
            {
                AboutUsDTOs = footerTransactions.GetAboutUs(),
                ContactDTOs = footerTransactions.GetContacts(),
                InstitutionalDTOs = footerTransactions.GetInstitutionals(),
                SocialMediaDTO = footerTransactions.GetSocialMedia(),
            };
            return View(footerVM);
        }
    }
}
