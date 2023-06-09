﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.Areas.admin.ViewModels;

namespace Tasaryeri.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(AuthenticationSchemes = "TasaryeriAdminAuth")]
    public class AdminController : Controller
    {
        IAdminTransactions adminBusiness;
        public AdminController(IAdminTransactions adminBusiness)
        {
            this.adminBusiness = adminBusiness;
        }
        [Route("admin/adminler")]
        public IActionResult Index()
        {
            try
            {
                var respone = adminBusiness.GetAll();
                AdminVM adminVM = new AdminVM
                {
                    AdminDTOList = respone,
                };
                return View(adminVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("admin/delete")]
        public string Delete(int id)
        {
            try
            {
                adminBusiness.Delete(id);
                return "Ok";
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Route("admin/admin-ekle"), HttpPost]
        public IActionResult Add(AdminDTO adminDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (adminBusiness.Add(adminDTO))
                    {
                        TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                        return Redirect("adminler");
                    }
                }
                TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
                return Redirect("adminler");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("admin/update"), HttpPost]
        public IActionResult Update(AdminDTO adminDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (adminBusiness.Update(adminDTO))
                    {
                        TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                        return Redirect("adminler");
                    }
                }
                TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
                return Redirect("adminler");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


