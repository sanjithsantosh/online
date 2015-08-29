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
using System.Data;
using System.Data.OleDb;
using BE.Common;
namespace DL
{
    /// <summary>
    /// Data Layer class for Personal
    /// </summary>
    public class Professional
    {
               OleDbConnection connection;
          OleDbCommand command;

        private void ConnecTo()
        {
            connection=new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanji_000\Documents\Visual Studio 2012\Projects\OnlineCV\Database.accdb;Persist Security Info=False");
            command=connection.CreateCommand();
        }

        public Professional()
        {
             ConnecTo();
        
        }

        /// <summary>
        /// Create or Update Request
        /// </summary>
        /// <param name="requesterId">Requester Id</param>
        /// <param name="requestId">Request Id</param>
        /// <returns>Success or failure</returns>
        /// Default Value for ValidationNotes set to "NONE"
        public bool CreateUpdateProfessional(string requesterId, BE.Professional professional)
        {
            try
            {
                command.CommandText = "UPDATE TBLCV set  PrTotExp = '" + professional.totexp + "', PrPrEmpl = '" + professional.PrevEmp + "', PrPeDsgn = '" + professional.PrevDesgn + "', PrPrRsnLv = '" + professional.PrevRsnLvng + "', PrPrRoles = '" + professional.PrevRles + "', PrPrFrmDte = '" + professional.PrvFrmDate + "', PrPrToDte = '" + professional.PrvToDate + "', PrCrntEmp ='" + professional.CrntEmp + "', PrCrntDsgn = '" + professional.CrntDesgn + "', PrCrntRsnLvng = '" + professional.CrntRsnLvng + "', PrCrntRles = '" + professional.CrntRles + "', PrCrntFrmDte = '" + professional.CrntFrmDate + "', PrCrntSlry = '" + professional.CrntSlry + "', PrExpSlry = '" + professional.ExpctSlry + "' where UsNme ='" + requesterId.ToString() + "'";
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
        /// GetProfessional
        /// </summary>
        public BE.Professional GetProfessional(string requester)
        {
            try
            {
                BE.Professional prof = new BE.Professional();

                command.CommandText = "Select PrTotExp,PrPrEmpl,PrPeDsgn,PrPrRsnLv,PrPrRoles,PrPrFrmDte,PrPrToDte,PrCrntEmp,PrCrntDsgn,PrCrntRsnLvng,PrCrntRles,PrCrntFrmDte,PrCrntSlry,PrExpSlry from TBLCV where UsNme = '" + requester + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    prof.totexp = Convert.ToInt32(reader["PrTotExp"].ToString());
                    prof.PrevEmp = reader["PrPrEmpl"].ToString();
                    prof.PrevDesgn = reader["PrPeDsgn"].ToString();
                    prof.PrevRsnLvng = reader["PrPrRsnLv"].ToString();
                    prof.PrevRles = reader["PrPrRoles"].ToString();
                    prof.PrvFrmDate = Convert.ToDateTime(reader["PrPrFrmDte"].ToString());
                    prof.PrvToDate = Convert.ToDateTime(reader["PrPrToDte"].ToString());
                    prof.CrntEmp = reader["PrCrntEmp"].ToString();
                    prof.CrntDesgn = reader["PrCrntDsgn"].ToString();
                    prof.CrntRsnLvng = reader["PrCrntRsnLvng"].ToString();
                    prof.CrntRles = reader["PrCrntRles"].ToString();
                    prof.CrntFrmDate = Convert.ToDateTime(reader["PrCrntFrmDte"].ToString());
                    prof.CrntSlry = Convert.ToInt32(reader["PrCrntSlry"].ToString());
                    prof.ExpctSlry = Convert.ToInt32(reader["PrExpSlry"].ToString());

                }

                return prof;

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
