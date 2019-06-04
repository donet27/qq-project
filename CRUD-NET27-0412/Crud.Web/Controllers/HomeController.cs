using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class HomeController : Controller
    {
        Services.NoteTypeService NoteTypeService = new Services.NoteTypeService();
        Services.NoteService NoteService = new Services.NoteService();

        //
        // GET: /Home/
        /// <summary>
        /// 没有参数时，显示所有的Note<br/>
        /// 有参数时，显示对应类别的Note
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            //向页面传递数据
            ViewBag.NoteTypes = this.NoteTypeService.GetAll();
            if (id == null) {
                ViewBag.Notes = this.NoteService.GetAll();
            } else {
                ViewBag.Notes = this.NoteService.GetByType(id.Value);
            }

            //转发到与方法同名（Index）的页面
            return View();
        }

    }
}
