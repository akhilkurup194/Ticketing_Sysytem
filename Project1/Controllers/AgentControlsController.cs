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
    public class AgentControlsController : Controller
    {
        // GET: Agent Login
        public ActionResult AgentLogin()
        {
            ViewBag.Message = "Agent users only..!!";
            return View();
        }      
        
        //GET: Agent Details Page
        public ActionResult AgentPage()
        {
            return View();
        }

        //POST:Login with agent credentials
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AgentLogin(Loginclass lc)
        {
            // TODO: Login logic is here
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
            SqlCommand cmd = new SqlCommand("sp_CrudGob", con);//connect with stored procedure
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
                Session["CustomerId"] = ds.Tables[0].Rows[0]["AgentId"].ToString();
                return RedirectToAction("AgentPage");//return View();
            }
            else
            {
                ViewData["Message"] = "login failed..!!";
            }
            con.Close();
            return View();
        }

        //GET: AgentControls/ SELECT All Tickets
        [HttpGet]
        public ActionResult GetAllTickets()
        {
            TicketRepo Repo = new TicketRepo();
            ModelState.Clear();
            return View(Repo.SelectallTicket());
        }

        //GET: AgentControls/ CREATE Ticket
        [HttpGet]
        public ActionResult AddTicket()
        {
            return View();
        }

        //POST: AgentControls/ CREATE Ticket
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

        // GET: AgentControls/ GET BY ID Tickets
        [HttpGet]
        public ActionResult EditTicket(string TicketId)
        {
            NewTicket objCustomer = new NewTicket();
            TicketRepo objDB = new TicketRepo(); //calling class DBdata    
            return View(objDB.SelectEditDatabyID(TicketId));
        }

        // POST: AgentControls/ EDIT Tickets
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

        // GET: AgentControls/ DELETE Tickets
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

        // GET: AgentControls/ GET BY ID Tickets
        // Assign  a Ticket to a Agent
        [HttpGet]
        public ActionResult AssignTicket(string TicketId)
        {
            NewTicket objCustomer = new NewTicket();
            TicketRepo objDB = new TicketRepo(); //calling class DBdata    
            return View(objDB.SelectEditDatabyID(TicketId));
        }

        // POST: AgentControls/ EDIT Tickets
        // Assign ticket to  a Agent
        [HttpPost]
        public ActionResult AssignTicket(NewTicket objCustomer)
        {
            // TODO: update logic here
            if (ModelState.IsValid) //checking model is valid or not    
            {
                TicketRepo objDB = new TicketRepo(); //calling class DBdata    
                string result = objDB.AssignTicket(objCustomer);
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

        // GET: AgentControls/ GET BY ID Tickets by ststus
        // Change the status of ticket Open/In Progress/Resolved/Closed
        [HttpGet]
        public ActionResult ChangeStatus(string TicketId)
        {
            ChangeStatus objCustomer = new ChangeStatus();
            TicketRepo objDB = new TicketRepo(); //calling class DBdata    
            return View(objDB.ChangeStatusById(TicketId));
        }

        // POST: AgentControls/ EDIT Tickets by ststus
        // Change the status of ticket Open/In Progress/Resolved/Closed
        [HttpPost]
        public ActionResult ChangeStatus(ChangeStatus objCustomer)
        {
            // TODO: update logic here
            if (ModelState.IsValid) //checking model is valid or not    
            {
                TicketRepo objDB = new TicketRepo(); //calling class DBdata    
                string result = objDB.UpdateStatus(objCustomer);
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

        // GET: AgentControls/ Search Tickets
        [HttpGet]
        public ActionResult Search(string SearchData)
        {
            if(string.IsNullOrEmpty(SearchData))
                return RedirectToAction("GetAllTickets");

            NewTicket objCustomer = new NewTicket();
            TicketRepo objDB = new TicketRepo(); //calling class DBdata    
            bool isInteger = int.TryParse(SearchData, out int parsedInt);

            if (isInteger)
            {
                objCustomer.TicketId = SearchData;
            }
            else
            {
                objCustomer.SearchString = SearchData;
            }
            var result = objDB.SearchTicketById(objCustomer);
            TempData["result2"] = result;
            //ModelState.Clear(); //clearing model    
            return View(result);
        }

        //GET: AgentControls/ CREATE customer by Agent view
        [HttpGet]
        public ActionResult AddCustByAgent()
        {
            return View();
        }

        //POST: AgentControls/ CREATE customer by Agent view
        [HttpPost]
        public ActionResult AddCustByAgent(CustAgentModel objCustomer)
        {
            //ModelState.Clear();
            objCustomer.DateOfBirth = Convert.ToDateTime(objCustomer.DateOfBirth);//convert ToDateTime
            if (ModelState.IsValid) //checking model is valid or not    
            {
                CustomerRepo objDB = new CustomerRepo();
                string result = objDB.InsertDataByAgent(objCustomer);
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model      
                return RedirectToAction("GetAllCustByAgent");//return View();
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();//return View();
            }
        }

        //GET: AgentControls/ SELECET customer by Agent view
        [HttpGet]
        public ActionResult GetAllCustByAgent()
        {
            CustomerRepo Repo = new CustomerRepo();
            ModelState.Clear();
            return View(Repo.SelectAllCustByAgent());;
        }

        //GET: AgentControls/ GET BY ID, Select customer by Agent view
        [HttpGet]
        public ActionResult EditCustByAgent(string id)
        {
            CustAgentModel objCustomer = new CustAgentModel();
            CustomerRepo objDB = new CustomerRepo(); //calling class DBdata    
            return View(objDB.SelectEditDataByID(id));
        }

        //POST: AgentControls/ EDIT customer by Agent view
        [HttpPost]
        public ActionResult EditCustByAgent(CustAgentModel objCustomer)
        {
            // TODO: update logic here
            objCustomer.DateOfBirth = Convert.ToDateTime(objCustomer.DateOfBirth);
            if (ModelState.IsValid) //checking model is valid or not    
            {
                CustomerRepo objDB = new CustomerRepo(); //calling class DBdata    
                string result = objDB.EditCustomerByAgent(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                return RedirectToAction("GetAllCustByAgent");//return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();//return View();
            }
        }

        //GET: AgentControls/ DELETE customer by Agent view
        [HttpGet]
        public ActionResult DeleteCustByAgent(String id)
        {
            // TODO:  delete logic here
            CustomerRepo objDB = new CustomerRepo();
            int result = objDB.DeleteCustByAgent(id);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
            return RedirectToAction("GetAllCustByAgent");//return View();
        }
    }
}
