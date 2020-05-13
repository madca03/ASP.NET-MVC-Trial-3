using ContosoSiteRestful.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public void Create()
        {

        }
    }
}