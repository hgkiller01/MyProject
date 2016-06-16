using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Repository.Models.ViewModel
{
    public class GridViewModel<T>
    {
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
}