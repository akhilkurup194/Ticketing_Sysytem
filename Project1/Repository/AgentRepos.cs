using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Project1.Models;

//This is the Customer and Agent CURD part Repository
namespace Project1.Repository
{
    public class AgentRepos
    {
        //Insert Agent details
        public string InsertAgent(CustAgentModel objcust)
        {
            SqlConnection con = null;

            string result = "";
            try//using try catch method
            {
                //TODO: insert logic is here
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudGob", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", objcust.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", objcust.Lastname);
                cmd.Parameters.AddWithValue("@DateOfBirth", objcust.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", objcust.Gender);
                cmd.Parameters.AddWithValue("@Phonenumber", objcust.Phonenumber);
                cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Username", objcust.Username);
                cmd.Parameters.AddWithValue("@Password", objcust.Password);
                cmd.Parameters.AddWithValue("@type", 1);
                con.Open();
                cmd.ExecuteNonQuery();
                return result;
            }
            catch(Exception)
            {
                
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        //Insert Agent details
        public string UpdateAgent(CustAgentModel objcust)
        {
            //TODO: Update logic is here
            SqlConnection con = null;
            string result = "";
            try//try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudGob", con);//connect with Stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", objcust.id);
                cmd.Parameters.AddWithValue("@Firstname", objcust.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", objcust.Lastname);
                cmd.Parameters.AddWithValue("@DateOfBirth", objcust.DateOfBirth);
                cmd.Parameters.AddWithValue("@Gender", objcust.Gender);
                cmd.Parameters.AddWithValue("@Phonenumber", objcust.Phonenumber);
                cmd.Parameters.AddWithValue("@EmailID", objcust.EmailID);
                cmd.Parameters.AddWithValue("@Address", objcust.Address);
                cmd.Parameters.AddWithValue("@Username", objcust.Username);
                cmd.Parameters.AddWithValue("@Password", objcust.Password);
                //cmd.Parameters.AddWithValue("@ConformPassword", objcust.ConformPassword);
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

        //Delete Agent details
        public int DeleteAgentDetails(String id)
        {
            //TODO: Delete Logic is here
            SqlConnection con = null;
            int result;
            try//Try catch methos
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudGob", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Firstname", null);
                cmd.Parameters.AddWithValue("@Lastname", null);
                cmd.Parameters.AddWithValue("@DateOfBirth", null);
                cmd.Parameters.AddWithValue("@Gender", null);
                cmd.Parameters.AddWithValue("@Phonenumber", null);
                cmd.Parameters.AddWithValue("@EmailID", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Username", null);
                cmd.Parameters.AddWithValue("@Password", null);
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

        //Selecet all Agent details
        public List<CustAgentModel> SelectAllAgents()
        {
            //TODO Show all deatils logic is here
            SqlConnection con = null;
            List<CustAgentModel> custlist = null;
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudGob", con);//connect with stored produre
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                custlist = new List<CustAgentModel>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustAgentModel cobj = new CustAgentModel();
                    cobj.id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    cobj.AgentId = dt.Rows[i]["AgentId"].ToString();
                    cobj.Firstname = dt.Rows[i]["Firstname"].ToString();
                    cobj.Lastname = dt.Rows[i]["Lastname"].ToString();
                    cobj.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"].ToString());
                    cobj.Gender = dt.Rows[i]["Gender"].ToString();
                    cobj.Phonenumber = dt.Rows[i]["Phonenumber"].ToString();
                    cobj.EmailID = dt.Rows[i]["EmailID"].ToString();
                    cobj.Address = dt.Rows[i]["Address"].ToString();
                    cobj.Username = dt.Rows[i]["Username"].ToString();
                    cobj.Password = dt.Rows[i]["Password"].ToString();
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

        //Select data by id Agent details
        public CustAgentModel SelectEditDatabyID(string id)
        {
            //TODO select data by id using update data or details the datas
            SqlConnection con = null;
            DataSet ds = null;
            CustAgentModel cobj = null;
            try//using try catch method
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());//sql connection
                SqlCommand cmd = new SqlCommand("sp_CrudGob", con);//connect with stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@type", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new CustAgentModel();
                    cobj.id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    cobj.Firstname = ds.Tables[0].Rows[i]["Firstname"].ToString();
                    cobj.Lastname = ds.Tables[0].Rows[i]["Lastname"].ToString();
                    cobj.DateOfBirth = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfBirth"].ToString());
                    cobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    cobj.Phonenumber = ds.Tables[0].Rows[i]["Phonenumber"].ToString();
                    cobj.EmailID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    cobj.Username = ds.Tables[0].Rows[i]["Username"].ToString();
                    cobj.Password = ds.Tables[0].Rows[i]["Password"].ToString();
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
    }
}
