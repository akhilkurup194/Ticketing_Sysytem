using Project1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Project1.Repository
{
    public class TicketRepo
    {
        //Insert new ticket
        public string CreateNewTicket(NewTicket objcust)
        {
            SqlConnection con = null;

            string result = "";
            try//using try catch method
            {
                //TODO: insert logic is here
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", objcust.CustomerId);
                cmd.Parameters.AddWithValue("@TicketType", objcust.TicketType);
                cmd.Parameters.AddWithValue("@Team", objcust.Team);
                cmd.Parameters.AddWithValue("@Category", objcust.Category);
                cmd.Parameters.AddWithValue("@Priority", objcust.Priority);
                cmd.Parameters.AddWithValue("@StDescr", objcust.StDescr);
                cmd.Parameters.AddWithValue("@Description", objcust.Description);
                cmd.Parameters.AddWithValue("@type", 1);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {

                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        //Update Ticket by id
        public string EditTicket(NewTicket objcust)
        {
            //TODO: Update logic is here
            SqlConnection con = null;
            string result = "";
            try//try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with Stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", objcust.TicketId);
                cmd.Parameters.AddWithValue("@TicketType", objcust.TicketType);
                cmd.Parameters.AddWithValue("@Team", objcust.Team);
                cmd.Parameters.AddWithValue("@Category", objcust.Category);
                cmd.Parameters.AddWithValue("@Priority", objcust.Priority);
                cmd.Parameters.AddWithValue("@StDescr", objcust.StDescr);
                cmd.Parameters.AddWithValue("@Description", objcust.Description);
                cmd.Parameters.AddWithValue("@type", 2);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        //Selecet all tickets
        public List<NewTicket> SelectallTicket()
        {
            //TODO Show all deatils logic is here
            SqlConnection con = null;
            List<NewTicket> custlist = null;
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored produre
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                custlist = new List<NewTicket>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NewTicket cobj = new NewTicket();
                    cobj.TicketId = dt.Rows[i]["TicketId"].ToString();
                    cobj.CustomerId = dt.Rows[i]["CustomerId"].ToString();
                    cobj.CreateDate = dt.Rows[i]["CreateDate"].ToString();
                    cobj.CreateDate = cobj.CreateDate.Split(' ')[0];
                    cobj.TicketType = dt.Rows[i]["TicketType"].ToString();
                    cobj.Team = dt.Rows[i]["Team"].ToString();
                    cobj.Category = dt.Rows[i]["Category"].ToString();
                    cobj.Priority = dt.Rows[i]["Priority"].ToString();
                    cobj.StDescr = dt.Rows[i]["StDescr"].ToString();
                    cobj.Description = dt.Rows[i]["Description"].ToString();
                    cobj.AssignedTo = dt.Rows[i]["AssignedTo"].ToString();
                    cobj.Status = dt.Rows[i]["Status"].ToString();
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        //Delete ticket data
        public int DeleteTicket(String TicketId)
        {
            //TODO: Delete Logic is here
            SqlConnection con = null;
            int result;
            try//Try catch methos
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", TicketId);
                cmd.Parameters.AddWithValue("@TicketType", null);
                cmd.Parameters.AddWithValue("@Team", null);
                cmd.Parameters.AddWithValue("@Category", null);
                cmd.Parameters.AddWithValue("@Priority", null);
                cmd.Parameters.AddWithValue("@StDescr", null);
                cmd.Parameters.AddWithValue("@Description", null);
                cmd.Parameters.AddWithValue("@type", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        //Select ticket by id
        public List<NewTicket> SelectTickeyById(string CustomerId)
        {
            //TODO select data by id using update data or details the datas
            SqlConnection con = null;
            DataSet ds = null;
            List<NewTicket> custlist = new List<NewTicket>();
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                cmd.Parameters.AddWithValue("@type", 5);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                custlist = new List<NewTicket>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NewTicket cobj = new NewTicket();
                    cobj.TicketId = dt.Rows[i]["TicketId"].ToString();
                    cobj.CustomerId = dt.Rows[i]["CustomerId"].ToString();
                    cobj.CreateDate = dt.Rows[i]["CreateDate"].ToString();
                    cobj.CreateDate = cobj.CreateDate.Split(' ')[0];
                    cobj.TicketType = dt.Rows[i]["TicketType"].ToString();
                    cobj.Team = dt.Rows[i]["Team"].ToString();
                    cobj.Category = dt.Rows[i]["Category"].ToString();
                    cobj.Priority = dt.Rows[i]["Priority"].ToString();
                    cobj.StDescr = dt.Rows[i]["StDescr"].ToString();
                    cobj.Description = dt.Rows[i]["Description"].ToString();
                    cobj.AssignedTo = dt.Rows[i]["AssignedTo"].ToString();
                    cobj.Status = dt.Rows[i]["Status"].ToString();
                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }


        //Select ticket by id for Assign to function
        public NewTicket SelectEditDatabyID(string id)
        {
            //TODO select data by id using update data or details the datas
            SqlConnection con = null;
            DataSet ds = null;
            NewTicket cobj = null;
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", id);
                cmd.Parameters.AddWithValue("@type", 6);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new NewTicket();
                    cobj.TicketType = ds.Tables[0].Rows[i]["TicketType"].ToString();
                    cobj.Team = ds.Tables[0].Rows[i]["Team"].ToString();
                    cobj.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                    cobj.Priority = ds.Tables[0].Rows[i]["Priority"].ToString();
                    cobj.StDescr = ds.Tables[0].Rows[i]["StDescr"].ToString();
                    cobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    cobj.AssignedTo = ds.Tables[0].Rows[i]["AssignedTo"].ToString();

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }

        //Select ticket by id for status change function
        public ChangeStatus ChangeStatusById(string id)
        {
            //TODO select data by id using update data or details the datas
            SqlConnection con = null;
            DataSet ds = null;
            ChangeStatus cobj = null;
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", id);
                cmd.Parameters.AddWithValue("@type", 6);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new ChangeStatus();
                    cobj.TicketId = ds.Tables[0].Rows[i]["TicketId"].ToString();
                    cobj.CustomerId = ds.Tables[0].Rows[i]["CustomerId"].ToString();
                    cobj.StDescr = ds.Tables[0].Rows[i]["StDescr"].ToString();
                    cobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    cobj.AssignedTo = ds.Tables[0].Rows[i]["AssignedTo"].ToString();
                    cobj.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }

        //Update Status by id
        public string UpdateStatus(ChangeStatus objcust)
        {
            //TODO: Update logic is here
            SqlConnection con = null;
            string result = "";
            try//try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with Stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", objcust.TicketId);
                cmd.Parameters.AddWithValue("@Status", objcust.Status);
                cmd.Parameters.AddWithValue("@type", 8);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        //Select ticket by id for searching tickets
        public IEnumerable<NewTicket> SearchTicketById(NewTicket SearchData)
        {
            //TODO select data by id using update data or details the datas
            SqlConnection con = null;
            DataSet ds = null;
            List<NewTicket> dataTicket = new List<NewTicket>();
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", Convert.ToInt16(SearchData.TicketId));
                cmd.Parameters.AddWithValue("@CustomerId", SearchData.SearchString);
                cmd.Parameters.AddWithValue("@StDescr", SearchData.SearchString);
                cmd.Parameters.AddWithValue("@Description", SearchData.SearchString);
                cmd.Parameters.AddWithValue("@type", 9);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    NewTicket cobj = new NewTicket();
                    cobj.TicketId = ds.Tables[0].Rows[i]["TicketId"].ToString();
                    cobj.CustomerId = ds.Tables[0].Rows[i]["CustomerId"].ToString();
                    cobj.CreateDate = ds.Tables[0].Rows[i]["CreateDate"].ToString();
                    cobj.TicketType = ds.Tables[0].Rows[i]["TicketType"].ToString();
                    cobj.Team = ds.Tables[0].Rows[i]["Team"].ToString();
                    cobj.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                    cobj.Priority = ds.Tables[0].Rows[i]["Priority"].ToString();
                    cobj.StDescr = ds.Tables[0].Rows[i]["StDescr"].ToString();
                    cobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    cobj.AssignedTo = ds.Tables[0].Rows[i]["AssignedTo"].ToString();
                    cobj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                    dataTicket.Add(cobj);
                }
                return dataTicket;
            }
            catch
            {
                return dataTicket;
            }
            finally
            {
                con.Close();
            }
        }

        //Edit tickets for Assign to function
        public string AssignTicket(NewTicket objcust)
        {
            //TODO: Update logic is here
            SqlConnection con = null;
            string result = "";
            try//try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudTicket", con);//connect with Stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketId", objcust.TicketId);
                cmd.Parameters.AddWithValue("@AssignedTo", objcust.AssignedTo);
                cmd.Parameters.AddWithValue("@type", 7);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
    }
}