using ContosoSiteRestful.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoSiteRestful.Controllers
{
    public class StudentsController : Controller
    {
        private ContosoSiteRestfulEntities db = new ContosoSiteRestfulEntities();

        // GET: /api/students
        [HttpGet]
        [Route("api/students")]
        public ActionResult Index()
        {
            var query = from student in db.Student
                        select student;

            var students = query.AsEnumerable().Select(student => new {
                student.StudentID,
                student.LastName,
                student.FirstName,
                EnrollmentDate = student.EnrollmentDate.ToString("MM/dd/yyyy HH:mm:ss"),
            }).ToList();

            var responseJson = new Dictionary<string, dynamic>();
            responseJson.Add("status", "ok");
            responseJson.Add("result", new Dictionary<string, dynamic>());
            responseJson["result"].Add("students", students);

            return Json(responseJson, JsonRequestBehavior.AllowGet);
        }

        // GET: /api/students/:id
        [HttpGet]
        [Route("api/students/{id:regex(\\d+)}")]
        public ActionResult Show(int id)
        {
            var query = (from st in db.Student
                         where st.StudentID == id
                         select st);

            var student = query.AsEnumerable().Select(st => new
            {
                st.StudentID,
                st.LastName,
                st.FirstName,
                EnrollmentDate = st.EnrollmentDate.ToString("MM/dd/yyyy HH:mm:ss")
            }).FirstOrDefault();

            var responseJson = new Dictionary<string, dynamic>();
            responseJson.Add("status", "ok");
            responseJson.Add("result", new Dictionary<string, dynamic>());
            responseJson["result"].Add("student", student);

            return Json(responseJson, JsonRequestBehavior.AllowGet);
        }

        // POST: /api/students
        [HttpPost]
        [Route("api/students")]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();

            var responseJson = new Dictionary<string, dynamic>();
            responseJson.Add("status", "ok");

            return Json(responseJson, JsonRequestBehavior.AllowGet);
        }

        // PUT: /api/students/:id
        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Post)]
        [Route("api/students/update/{id:regex(\\d+)}")]
        public ActionResult Update([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student, int id)
        {
            Student studentQuery = (from st in db.Student
                                    where st.StudentID == id
                                    select st).FirstOrDefault();

            studentQuery.LastName = student.LastName;
            studentQuery.FirstName = student.FirstName;
            studentQuery.EnrollmentDate = student.EnrollmentDate;

            db.SaveChanges();

            var responseJson = new Dictionary<string, dynamic>();
            responseJson.Add("status", "ok");

            return Json(responseJson, JsonRequestBehavior.AllowGet);
        }

        // DELETE: /api/students/:id
        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Post)]
        [Route("api/students/delete/{id:regex(\\d+)}")]
        public ActionResult Delete(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
            db.SaveChanges();

            var responseJson = new Dictionary<string, dynamic>();
            responseJson.Add("status", "ok");

            return Json(responseJson, JsonRequestBehavior.AllowGet);
        }
    }
}