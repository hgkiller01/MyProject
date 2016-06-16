using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models.ViewModel;
using System.Web.Mvc.Filters;

namespace Mvc_Repository.Controllers
{
    public class JqueryTestController : Controller
    {
        // GET: JqueryTest
        
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult TestPartialView()
        {
            return PartialView();
        }
        public ActionResult UrlTest()
        {
            return View();
        }
        public ActionResult Mobile()
        {
            return View();
        }
        public ActionResult DateTime()
        {
            return View();
        }
        public ActionResult Razor()
        {
            Dictionary<string, string> abc = new Dictionary<string, string>();
            abc.Add("123", "ddd");
            abc.Add("456", "aaa");
            abc.Add("214", "ccc");
            List<Student> student = GetALL();
            var items = new SelectList(student, "StudnetID", "Name", "3");
            foreach (var item in items)
            {
                bool select = item.Selected;
            }
            ViewBag.Student = items;
            MultiSelectList studentlist = new MultiSelectList(student, "StudnetID", "Name", new List<int>() { 1, 2, 3 });

            foreach (var item in studentlist)
            {
                string txtitem = item.Text;
                string valuetiem = item.Value;
                bool isSelected = item.Selected;
            }
            ViewBag.lists = studentlist;
            ViewBag.All = new SelectList(abc, "key", "value", "456");
            ViewBag.Sex = "F";
            return View(GetStudentInitialModel());
        }
        public ActionResult Razor2(PostedStudent postedStudent)
        {
            StudentViewModel student = GetFruitsModel(postedStudent);
            return View(student);
        }
        private StudentViewModel GetFruitsModel(PostedStudent postedStudent)
        {
            // setup properties
            var model = new StudentViewModel();
            var selectedStudents = new List<Student>();
            var postedStudents = new string[0];
            if (postedStudent == null) postedStudent = new PostedStudent();

            // if a view model array of posted fruits ids exists
            // and is not empty,save selected ids
            if (postedStudent.StudentIds != null && postedStudent.StudentIds.Any())
            {
                postedStudents = postedStudent.StudentIds;
            }

            // if there are any selected ids saved, create a list of fruits
            if (postedStudents.Any())
            {
                selectedStudents = GetALL()
                 .Where(x => postedStudents.Any(s => x.StudnetID.ToString().Equals(s)))
                 .ToList();
            }

            //setup a view model
            model.AvailableStudent = GetALL().ToList();
            model.SelectedStudent = selectedStudents;
            model.PostedStudent = postedStudent;

            return model;
        }
        /// <summary>
        /// for setup initial view model for all fruits
        /// </summary>
        private StudentViewModel GetStudentInitialModel()
        {
            //setup properties
            var model = new StudentViewModel();
            var selectedStudents = new List<Student>();

            //setup a view model
            model.AvailableStudent = GetALL().ToList();
            model.SelectedStudent = selectedStudents;

            return model;
        }
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            
            
        }
        [NonAction]
        public List<Student> GetALL()
        {
            return new List<Student>(){
                new Student(){
                     StudnetID = "1",
                     Name = "Peter"
                },
                new Student(){
                     StudnetID = "2",
                     Name = "Mary"
                },
                new Student(){
                     StudnetID = "3",
                     Name = "Cheng"
                },
                new Student(){
                     StudnetID = "4",
                       Name = "Killer"
                 },
                 new Student(){
                     StudnetID = "5",
                     Name= "devil"
                  },
            };
        }



    }
    public class Student
    {
        public string StudnetID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public object Tags { get; set; }
    }

    public class PostedStudent
    {
        //this array will be used to POST values from the form to the controller
        public string[] StudentIds { get; set; }
    }
}