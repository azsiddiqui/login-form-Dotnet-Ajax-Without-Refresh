using login_page.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Helpers;

namespace login_page.Controllers
{
       
    public class accountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: account
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        void connectionstring()
        {
            con.ConnectionString = " data source = DESKTOP-GARFCS8; database = wpf; integrated security = true; ";
        }
        [HttpGet]
        public int verify(string n, string p)
        {

            account acc = new account() {
            name = n,
            password = p,
            };
            connectionstring();
            con.Open();
            com.Connection = con;
            com.CommandText =" select * from loginfrm where username='"+acc.name+"'and password='"+acc.password+"' ";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return 1; 
            }
            else
            {
                con.Close();
                return 0;
            }

            
        }
    }
}