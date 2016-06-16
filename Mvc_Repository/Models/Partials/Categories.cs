using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Mvc_Repository.Models
{
    [MetadataType(typeof(CategoriesMD))]
    public partial class Categories
    {
        public class CategoriesMD
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
            public byte[] Picture { get; set; }
            [ScriptIgnore]
            public virtual ICollection<Products> Products { get; set; }
        }
    }
}