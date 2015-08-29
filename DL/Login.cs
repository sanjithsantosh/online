// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       :

using System;
using System.Linq;
using System.Collections.Generic;
using BE;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;
using BE.Common;
namespace DL
{
    /// <summary>
    /// Data Layer class for Login
    /// </summary>
    public class Login
    {
          OleDbConnection connection;
          OleDbCommand command;

        private void ConnecTo()
        {
            connection=new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanji_000\Documents\Visual Studio 2012\Projects\OnlineCV\Database.accdb;Persist Security Info=False");
            command=connection.CreateCommand();
        }

        public Login()
        {
             ConnecTo();
        
        }


        /// <summary>
        /// CreateUser
        /// </summary>
        public bool CreateUser(BE.Login _login)
        {
            try
            {
                command.CommandText = "INSERT INTO TBLLGN (Unme,Pswd,EmID) VALUES('" + _login.Uname + "','" + _login.Pswd + "','" + _login.Email + "')";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        /// <summary>
        /// CreateUser
        /// </summary>
        public bool CheckUser(BE.Login _login)
        {
            try
            {
                DataTable dt =new DataTable();
                command.CommandText = "Select * from TBLLGN where Unme = '" + _login.Uname + "' and Pswd = '" +_login.Pswd+ "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                dt.Load(reader);

                if (dt.Rows.Count != 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

    }
}
