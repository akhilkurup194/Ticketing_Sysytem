using Project1.Models;
using Project1.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class AdminControlsController : Controller
    {
        // GET: AdminControls/ Admin Login
        public ActionResult AdminLogin()
        {
            ViewBag.Message = "Admin users only..!!";
            return View();
        }

        // GET: AdminControls/ Admin Details Page
        public ActionResult AdminPage()
        {
            return View();
        }

        // GET: AdminControls/ Add Agent
        [HttpGet]
        public ActionResult AddAgent()
        {
            return View();
        }

        // GET: AdminControls/ All Agent ErrorPage
        public ActionResult GetAllAgentErrorPage()
        {
            ViewData["Message"] = "No Agents Available.....!!";
            return View();
        }

        //POST:Login with admin credentials
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AdminLogin(Loginclass lc)
        {

            // TODO: Login logic is here
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
            SqlCommand cmd = new SqlCommand("sp_AdminLogin", con);//connect with stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", lc.Username);
            cmd.Parameters.AddWithValue("@Password", lc.Password);
            cmd.Parameters.AddWithValue("@type", 1);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                    Session["Username"] = lc.Username.ToString();
                    return RedirectToAction("AdminPage");
            }
            else
            {
                ViewData["Message"] = "login failed..!!";
            }
            con.Close();
            return View();//return View();
        }

        // GET: AdminControls/ SELECT Agent Details
        [HttpGet]
        public ActionResult AgentDetails()
        {
            AgentRepos Repo = new AgentRepos();
            ModelState.Clear();
            var result = Repo.SelectAllAgents();
            if(result.Count != 0)
            {
                return View(result);
            }
            else
            {
                ViewData["Message"] = "No Agents Available.....!!";
                return RedirectToAction("GetAllAgentErrorPage");
            }
        }

        // GET: AdminControls/ CREATE Agent
        [HttpPost]
        public ActionResult AddAgent(CustAgentModel objCustomer)
        {
            //ModelState.Clear();
            objCustomer.DateOfBirth = Convert.ToDateTime(objCustomer.DateOfBirth);//convert ToDateTime
            if (ModelState.IsValid) //checking model is valid or not    
            {
                AgentRepos objDB = new AgentRepos();
                string result = objDB.InsertAgent(objCustomer);
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model      
                return RedirectToAction("AgentDetails");//return View();
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();//return View();
            }
        }

        // GET: AdminControls/ GET BY ID Agent Details
        [HttpGet]
        public ActionResult EditAgentDetails(string id)
        {
            CustAgentModel objCustomer = new CustAgentModel();
            AgentRepos objDB = new AgentRepos(); //calling class DBdata    
            return View(objDB.SelectEditDatabyID(id));
        }

        // POST: AdminControls/ EDIT Agent details
        [HttpPost]
        public ActionResult EditAgentDetails(CustAgentModel objCustomer)
        {
            // TODO: update logic here
            objCustomer.DateOfBirth = Convert.ToDateTime(objCustomer.DateOfBirth);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                AgentRepos objDB = new AgentRepos(); //calling class DBdata    
                string result = objDB.UpdateAgent(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                return RedirectToAction("AgentDetails");//return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();//return View();
            }
        }

        // GET: AdminControls/ DELETE Agent
        [HttpGet]
        public ActionResult DeleteAgentDetails(String id)
        {
            // TODO:  delete logic here
            AgentRepos objDB = new AgentRepos();
            int result = objDB.DeleteAgentDetails(id);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
            return RedirectToAction("AgentDetails");//return View();
        }

    }
}
