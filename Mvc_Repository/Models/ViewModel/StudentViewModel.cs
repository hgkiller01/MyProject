using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc_Repository.Controllers;

namespace Mvc_Repository.Models.ViewModel
{
    public class StudentViewModel
    {
        public IEnumerable<Student> AvailableStudent { get; set; }
        public IEnumerable<Student> SelectedStudent { get; set; }
        public PostedStudent PostedStudent { get; set; }
    }
}