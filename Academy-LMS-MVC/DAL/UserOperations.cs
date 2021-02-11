using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Academy_LMS_MVC.Models;

namespace Academy_LMS_MVC.DAL
{
    public class UserOperations
    {
        public int AddUser(Users user)
        {

            //User from the BLL and saving that user in our database.
            string conn = ConfigurationManager.ConnectionStrings["Academy_MVC_DB"].ToString();
            SqlConnection objsqlconn = new SqlConnection(conn);
            objsqlconn.Open();
            SqlCommand objcmd = new SqlCommand("AllOperationsUser", objsqlconn);
            objcmd.CommandType = CommandType.StoredProcedure;

            SqlParameter FirstName = objcmd.Parameters.Add("@FirstName", SqlDbType.VarChar);
            FirstName.Value = user.FirstName;

            SqlParameter LastName = objcmd.Parameters.Add("@LastName", SqlDbType.VarChar);
            LastName.Value = user.LastName;

            SqlParameter Email = objcmd.Parameters.Add("@Email", SqlDbType.VarChar);
            Email.Value = user.Email;

            SqlParameter PhoneNumber = objcmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar);
            PhoneNumber.Value = user.PhoneNumber;


            SqlParameter Password = objcmd.Parameters.Add("@Password", SqlDbType.VarChar);
            Password.Value = user.Password ;


            SqlParameter StatementType = objcmd.Parameters.Add("@StatementType", SqlDbType.VarChar);
            StatementType.Value = "Insert";

            var returnParameter = objcmd.Parameters.Add("@ReturnID", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            int result = objcmd.ExecuteNonQuery();

            result = Convert.ToInt32(returnParameter.Value);
            return result;
        }

        public Users GetUserByEmail(string Email)
        {

            string conn = ConfigurationManager.ConnectionStrings["Academy_MVC_DB"].ToString();
            SqlConnection objsqlconn = new SqlConnection(conn);
            objsqlconn.Open();
            SqlCommand objcmd = new SqlCommand("AllOperationsUser", objsqlconn);
            objcmd.CommandType = CommandType.StoredProcedure;

            SqlParameter EmailParam = objcmd.Parameters.Add("@Email", SqlDbType.VarChar);
            EmailParam.Value = Email;

            SqlParameter StatementType = objcmd.Parameters.Add("@StatementType", SqlDbType.VarChar);
            StatementType.Value = "Select";

            SqlDataReader dr = objcmd.ExecuteReader();
            Users user = new Users();

            while (dr.Read())
            {
                user.FirstName = (string)dr["FirstName"];
                user.LastName = (string)dr["LastName"];
                user.PhoneNumber = (string)dr["PhoneNumber"];
                user.Email = (string)dr["Email"];
                return user;
            }
            return user;
        }
    }
}