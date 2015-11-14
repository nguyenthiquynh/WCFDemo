using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFormMvc.ServiceReferenceSinhVien;
using WebFormMvc.ServiceReferenceDemo;
namespace WebFormMvc.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            List<SinhVien> ListSV = new List<SinhVien>();
            ServiceSinhVienClient sv = new ServiceSinhVienClient();
            ViewBag.ListSV = sv.ListSinhVien().ToList();
            return View();
        }

    }
}
