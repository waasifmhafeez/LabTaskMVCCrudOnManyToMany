using LabTaskMVC.DataLayer;
using LabTaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskMVC.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        DataLayerTeacher obj = new DataLayerTeacher();
        // GET: Teacher
        public ActionResult GetAll()
        {
            var list = obj.GetAll();
            return View(list);
        }
        public ActionResult GetById(int Id)
        {
            return View(obj.GetById(Id));
        }

        public ActionResult Create()
        {
            Teacher emp = new Teacher();
            return View(emp);

            //return RedirectToAction("GetAll");
        }
        [HttpPost]
        public ActionResult Create(Teacher TModel)
        {
            obj.Create(TModel);
            return RedirectToAction("GetAll");
            //return RedirectToAction("GetAll");
        }
        public ActionResult Update(int id)
        {
            //EmployeeModel emp = new EmployeeModel();
            // obj.Update(emp);
            return View(obj.GetById(id));
        }
        [HttpPost]
        public ActionResult Update(int id, Teacher TModel)
        {
            obj.Update1(id, TModel);
            return RedirectToAction("GetAll");
        }
        public ActionResult Delete(int Id)
        {
            obj.Delete(Id);
            return View();
        }
    }
}