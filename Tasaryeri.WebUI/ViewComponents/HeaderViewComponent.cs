using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;

namespace Tasaryeri.WebUI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        IFooterTransactions footerTransactions;
        public HeaderViewComponent(IFooterTransactions footerTransactions)
        {
            this.footerTransactions = footerTransactions;
        }
        public IViewComponentResult Invoke()
        {
            return View(footerTransactions.GetSocialMedia());
        }
    }
}
