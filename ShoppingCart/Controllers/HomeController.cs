using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult SaveProductDetails(string ProductName, int Price, string Description)
        {
            string connctionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connctionString);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "usp_SaveProductDeatils";

            cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;

            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Price;

            cmd.Parameters.Add("@Decription", SqlDbType.NVarChar).Value = Description;


            cmd.Connection = con;

            try

            {

                con.Open();

                cmd.ExecuteNonQuery();

                // lblMessage.Text = "Record inserted successfully";

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

                con.Dispose();

            }
            return Json("saved successfully.", JsonRequestBehavior.AllowGet);
        }
    }
}