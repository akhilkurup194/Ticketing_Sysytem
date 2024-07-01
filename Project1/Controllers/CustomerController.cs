using Project1.Models;
using Project1.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerPage()
        {
            return View();
        }

        // GET: Get error page view
        public ActionResult GetAllTicketsErrorPage()
        {
            ViewData["Message"] = "No Tickets Available.....!!";
            return View();
        }

        // GET: Customer login view
        public ActionResult CustomerLogin()
        {
            ViewBag.Message = "Customers only..!!";
            return View();
        }

        //POST:Login with Customer credentials
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CustomerLogin(Loginclass lc)
        {
            // TODO: Login logic is here
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
            SqlCommand cmd = new SqlCommand("sp_CrudCustomer", con);//connect with stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", lc.Username);
            cmd.Parameters.AddWithValue("@Password", lc.Password);
            cmd.Parameters.AddWithValue("@type", 6);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                Session["CustomerId"] = ds.Tables[0].Rows[0]["CustomerId"].ToString();
                return RedirectToAction("CustomerPage");//return View();
            }
            else
            {
                ViewData["Message"] = "login failed..!!";
            }
            con.Close();
            return View();
        }

        // GET: AdminControls/ INSERT new Ticket
        [HttpGet]
        public ActionResult AddTicket()
        {
            return View();
        }

        // POST: AdminControls/ INSERT new Ticket
        [HttpPost]
        public ActionResult AddTicket(NewTicket objCustomer)
        {
            //objCustomer.CreateDate = DateTime.Now("MM/dd/yyyy");
            if (ModelState.IsValid) //checking model is valid or not    
            {
                objCustomer.CustomerId = Session["CustomerId"].ToString();
                TicketRepo objDB = new TicketRepo();
                string result = objDB.CreateNewTicket(objCustomer);
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model      
                return RedirectToAction("GetAllTickets");//return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();//return View();
            }
        }

        // GET: AdminControls/ SELECET All Tickets
        [HttpGet]
        public ActionResult GetAllTickets(string TicketId)
        {
            TicketRepo Repo = new TicketRepo();
            List<NewTicket> custlist = new List<NewTicket>();
            ModelState.Clear();
            custlist = Repo.SelectallTicket();
            string customerId = Session["CustomerId"].ToString();
            custlist = Repo.SelectTickeyById(customerId.ToString());

            if(custlist.Count != 0)
            {
                return View(custlist);
            }
            else
            {
                ViewData["Message"] = "No Tickets Available.....!!";
                return RedirectToAction("GetAllTicketsErrorPage");
            }
            return View();

        }

        // GET: AdminControls/ GET BY ID selecet Ticket by ID
        [HttpGet]
        public ActionResult EditTicket(string TicketId)
        {
            NewTicket objCustomer = new NewTicket();
            TicketRepo objDB = new TicketRepo(); //calling class DBdata    
            return View(objDB.SelectEditDatabyID(TicketId));
        }

        // GET: AdminControls/ EDIT Ticket by ID
        [HttpPost]
        public ActionResult EditTicket(NewTicket objCustomer)
        {
            // TODO: update logic here
            if (ModelState.IsValid) //checking model is valid or not    
            {
                TicketRepo objDB = new TicketRepo(); //calling class DBdata    
                string result = objDB.EditTicket(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                return RedirectToAction("GetAllTickets");//return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();//return View();
            }
        }

        // GET: AdminControls/ DELETE Ticket by ID
        [HttpGet]
        public ActionResult DeleteTicket(String TicketId)
        {
            // TODO:  delete logic here
            TicketRepo objDB = new TicketRepo();
            int result = objDB.DeleteTicket(TicketId);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
            return RedirectToAction("GetAllTickets");//return View();
        }

        // GET: AdminControls/ SELECET customer by id
        [HttpGet]
        public ActionResult profileView(string TicketId)
        {
            CustomerRepo Repo = new CustomerRepo();
            CustAgentModel custlist = new CustAgentModel();
            ModelState.Clear();
            string customerId = Session["CustomerId"].ToString();
            custlist = Repo.profileDataSelectByID(customerId);
            //custlist = Repo.profileDataSelectByID(customerId.ToString());

            if (!string.IsNullOrEmpty(custlist.ToString()))
            {
                return View(custlist);
            }
            else
            {
                ViewData["Message"] = "Profile view failed.....!!";
                return RedirectToAction("GetAllTicketsErrorPage");
            }
            return View();

        }
    }
}
