using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.ViewModel
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public int id { get; set; }
        public string text { get; set; }
        public Child[] children { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public Child1[] children { get; set; }
    }

    public class Child1
    {
        public string text { get; set; }
        public bool _checked { get; set; }
    }

}