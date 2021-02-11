using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academy_LMS_MVC.Models;
using Academy_LMS_MVC.DAL;

namespace Academy_LMS_MVC.BLL
{
    public class UsersOperationsBLL
    {
        public int Register(Users user)
        {
            UserOperations userOperations = new UserOperations();
            int result = userOperations.AddUser(user);
            
            return result;
        }

        public Users Login(string Email, string Password)
        {


            Users user = new Users();
            return user;
        }

        public int UserExists(string Email)
        {

            UserOperations userOperations = new UserOperations();
            Users user = userOperations.GetUserByEmail(Email);
            if(user != null)
            {
                return 1;
            }
            return 0;
        }
    }
}