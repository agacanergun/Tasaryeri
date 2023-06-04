using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;

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
            return View();
        }
    }
}
