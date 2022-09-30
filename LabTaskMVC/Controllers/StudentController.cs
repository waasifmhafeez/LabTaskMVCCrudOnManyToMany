using LabTaskMVC.DataLayer;
using LabTaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTaskMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DataLayerStudent obj = new DataLayerStudent();
        // GET: Student
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
            Student emp = new Student();
            return View(emp);

            //return RedirectToAction("GetAll");
        }
        [HttpPost]
        public ActionResult Create(Student empModel)
        {
            obj.Create(empModel);
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
        public ActionResult Update(int id, Student EmpModel)
        {
            obj.Update1(id, EmpModel);
            return RedirectToAction("GetAll");
        }
        public ActionResult Delete(int Id)
        {
            obj.Delete(Id);
            return View();
        }
    }
}