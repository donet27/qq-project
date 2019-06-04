using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class NoteController : Controller
    {
        Services.NoteTypeService NoteTypeService = new Services.NoteTypeService();
        Services.NoteService NoteService = new Services.NoteService();
        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create() {

            ViewBag.NoteTypes = this.NoteTypeService.GetAll();

            //转发到添加页面
            return View();
        }

        [HttpPost]
        public ActionResult Create(Model.Note note) {
            ////取得请求参数并封装成一个实体对象
            //var note = new Model.Note {
            //    NoteTypeId = Convert.ToInt32(Request["NoteTypeId"]),
            //    Title = Convert.ToString(Request["Title"]),
            //    Content = Convert.ToString(Request["Content"]),
            //    CreateDate = DateTime.Now
            //};

            note.CreateDate = DateTime.Now;

            int i = this.NoteService.Insert(note);
            if (i>0) {
                //添加成功，重定向到显示页面
                return RedirectToAction("Index", "Home");
            }

            //失败
            ViewBag.NoteTypes = this.NoteTypeService.GetAll();

            //转发到添加页面
            return View();
        }


        public ActionResult Delete(int id) {
            this.NoteService.Delete(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            //查询出要修该的对象
            var note = this.NoteService.Get(id);
            //传递到页面进行显示
            ViewBag.Note = note;
            ViewBag.NoteTypes = this.NoteTypeService.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Model.Note note) {
            //查询出要修该的对象
            var i = this.NoteService.Update(note);
            if (i>0) {
                return RedirectToAction("Index", "Home");
            }
            //传递到页面进行显示
            ViewBag.NoteTypes = this.NoteTypeService.GetAll();
            ViewBag.Note = note;

            return View();
        }

    }
}
