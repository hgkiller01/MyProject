using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Repository.Models.ViewModel
{
    public class TestFormModel
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }
        public int Age { get; set; }
        public DateTime? Time { get; set; }
    }
}