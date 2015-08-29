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
    /// Data Layer class for Educational
    /// </summary>
    public class Educational
    {


            OleDbConnection connection;
          OleDbCommand command;

        private void ConnecTo()
        {
            connection=new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanji_000\Documents\Visual Studio 2012\Projects\OnlineCV\Database.accdb;Persist Security Info=False");
            command=connection.CreateCommand();
        }

        public Educational()
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
        public bool CreateUpdateEducational(string requesterId, BE.Educational educational)
        {
            try
            {
                command.CommandText = "UPDATE TBLCV set  EdInst = '" + educational.Institution + "', EdCntry = '" + educational.Country + "', EdMjr = '" + educational.MaDgree + "', EdScndMjr = '" + educational.ScndMjrDgree + "', EdMnr = '" + educational.MnrDgree + "', EdLvl = '" + educational.EdLvl + "', EdStrtDte = '" + educational.StartDate + "', EdEndDte ='" + educational.EndDate + "', EdHghrScnd = '" + educational.Hschl + "', EdGPA = '" + educational.GPA + "' where UsNme ='" + requesterId.ToString()+ "'";
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
        /// Get Educational
        /// </summary>
        public BE.Educational GetEducational(string requester)
        {
            try
            {
                BE.Educational edu = new BE.Educational();

                command.CommandText = "Select EdInst,EdCntry,EdMjr,EdScndMjr,EdMnr,EdLvl,EdStrtDte,EdEndDte,EdHghrScnd,EdGPA from TBLCV where UsNme = '" + requester + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    edu.Institution = reader["EdInst"].ToString();
                    edu.Country = reader["EdCntry"].ToString();
                    edu.MaDgree = reader["EdMjr"].ToString();
                    edu.ScndMjrDgree = reader["EdScndMjr"].ToString();
                    edu.MnrDgree = reader["EdMnr"].ToString();
                    edu.EdLvl = reader["EdLvl"].ToString();
                    edu.StartDate = Convert.ToDateTime(reader["EdStrtDte"].ToString());
                    edu.EndDate = Convert.ToDateTime(reader["EdEndDte"].ToString());
                    edu.Hschl = reader["EdHghrScnd"].ToString();
                    edu.GPA = Convert.ToInt32(reader["EdGPA"].ToString());

                }

                return edu;

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
