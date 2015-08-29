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
    /// Data Layer class for Personal
    /// </summary>
    public class Personal
    {

        
          OleDbConnection connection;
          OleDbCommand command;

        private void ConnecTo()
        {
            connection=new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanji_000\Documents\Visual Studio 2012\Projects\OnlineCV\Database.accdb;Persist Security Info=False");
            command=connection.CreateCommand();
        }

        public Personal()
        {
             ConnecTo();
        
        }
       
        /// <summary>
        /// Create or Update Personal
        /// </summary>
        /// <param name="requesterId">Requester Id</param>
        /// <param name="requestId">Request Id</param>
        /// <returns>Success or failure</returns>
        public bool CreateUpdatePersonal(string requesterId, BE.Personal personal)
        {
            try
            {
                command.CommandText = "INSERT INTO TBLCV (UsNme,FirstNme,Scndnme,LstNme,Gndr,Nat,ResAd1,ResAd2,ResCty,ResPcode,CrntAd1,CrntAd2,CrntCty,CrntPsCde,PmNmbr,HmeNmbr,MbleNmbr,EmailID1,EmailId2) VALUES('" + requesterId + "','" + personal.FName + "','" + personal.SName + "','" + personal.LName + "','" + personal.Gender + "','" + personal.Nat + "','" + personal.RAdd1 + "','" + personal.RAdd2 + "','" + personal.Rcty + "','" + personal.RPcode + "','" + personal.CAdd1 + "','" + personal.CAdd2 + "','" + personal.Ccty + "','" + personal.CPcode + "','" + personal.PNmbr + "','" + personal.HNmbr + "','" + personal.MNmbr + "','" + personal.EmailID1 + "','" + personal.EmailID2 + "')";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// Get Personal
        /// </summary>
        public BE.Personal GetPersonal(string requester)
        {
            try
            {
                BE.Personal pers = new BE.Personal();
               
                command.CommandText = "Select FirstNme,Scndnme,LstNme,Gndr,Nat,ResAd1,ResAd2,ResCty,ResPcode,CrntAd1,CrntAd2,CrntCty,CrntPsCde,PmNmbr,HmeNmbr,MbleNmbr,EmailID1,EmailId2 from TBLCV where UsNme = '" + requester + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  
                    pers.FName = reader["FirstNme"].ToString();
                    pers.SName = reader["Scndnme"].ToString();
                    pers.LName = reader["LstNme"].ToString();
                    pers.Gender = reader["Gndr"].ToString();
                    pers.Nat = reader["Nat"].ToString();
                    pers.RAdd1 =reader["ResAd1"].ToString();
                    pers.RAdd2 = reader["ResAd2"].ToString();
                    pers.Rcty = reader["ResCty"].ToString();
                    pers.RPcode = Convert.ToInt32(reader["ResPcode"].ToString());
                    pers.CAdd1 = reader["CrntAd1"].ToString();
                    pers.CAdd2 =reader["CrntAd2"].ToString();
                    pers.Ccty = reader["CrntCty"].ToString();
                    pers.CPcode =Convert.ToInt32(reader["CrntPsCde"].ToString());
                    pers.HNmbr = Convert.ToInt32(reader["PmNmbr"].ToString());
                    pers.PNmbr = Convert.ToInt32(reader["HmeNmbr"].ToString());
                    pers.MNmbr = Convert.ToInt32(reader["MbleNmbr"].ToString());
                    pers.EmailID1 = reader["EmailID1"].ToString();
                    pers.EmailID2 = reader["EmailId2"].ToString();

                  
                }

                return pers;
                
            }
            catch (Exception ex)
            {
                return null;
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
