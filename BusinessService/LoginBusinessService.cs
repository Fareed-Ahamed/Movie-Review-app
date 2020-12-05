using MovieAPI.DBAccess;
using MovieAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.BusinessService
{
    public interface ILoginInterFace
    {
        string CheckUser(User user);
    }
    public class LoginBusinessService : ILoginInterFace
    {
        UserTableAccess userTableAccess;
        public LoginBusinessService()
        {
            userTableAccess = new UserTableAccess();
        }
        public string CheckUser(User user)
        {
            return userTableAccess.CheckUser(user);
        }
    }
}