using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;


public partial class Test : System.Web.UI.Page
{
    //BL_Members Members = new BL_Members();
    protected void Page_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("FirstName", typeof(string));
        dt.Columns.Add("LastName", typeof(string));
        dt.Columns.Add("Age", typeof(int));

        Page.Controls.Add(new LiteralControl("<script>alert('成功!')</script>"));

        var dr = dt.NewRow();
        dr["FirstName"] = "Person";
        dr["LastName"] = "One";
        dr["Age"] = 23;
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["FirstName"] = "Person";
        dr["LastName"] = "Two";
        dr["Age"] = 43;
        dt.Rows.Add(dr);
        //Response.Write("<script>alert('成功!')</script>");
        //Mapper.CreateMap<IDataReader, List<Person>>();
        //List<Person> People = Mapper.Map<IDataReader, List<Person>>(dt.CreateDataReader());
       
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    class Student
    {
        public string Member_NickName { get; set; }
        public string Member_Email { get; set; }
        public string Member_SiteID { get; set; }
    }
}