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
    public class Certification
    {
            OleDbConnection connection;
          OleDbCommand command;

        private void ConnecTo()
        {
            connection=new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sanji_000\Documents\Visual Studio 2012\Projects\OnlineCV\Database.accdb;Persist Security Info=False");
            command=connection.CreateCommand();
        }

        public Certification()
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
        public bool CreateUpdateCertification(string requesterId, BE.Certification certification)
        {
            try
            {
                command.CommandText = "UPDATE TBLCV set  CrtNm1 = '" + certification.Cert1 + "', CrtOrg1 = '" + certification.Org2 + "', CrtExpDte = '" + certification.ExpryDte1 + "', CrtNm2 = '" + certification.Cert2 + "', CrtOrg2 = '" + certification.Org2 + "', CrtExp2 = '" + certification.ExpryDte2 + "', CrtNm3 = '" + certification.Cert3 + "', CrtOrg3 ='" + certification.Org3 + "', CrtExp3 = '" + certification.ExpryDte3 + "' where UsNme ='" + requesterId.ToString() + "'";
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
        public BE.Certification GetCertification(string requester)
        {
            try
            {
                BE.Certification cert = new BE.Certification();

                command.CommandText = "Select CrtNm1,CrtOrg1,CrtExpDte,CrtNm2,CrtOrg2,CrtExp2,CrtNm3,CrtOrg3,CrtExp3 from TBLCV where UsNme = '" + requester + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    cert.Cert1 = reader["CrtNm1"].ToString();
                    cert.Org1 = reader["CrtOrg1"].ToString();
                    cert.ExpryDte1 =  Convert.ToDateTime(reader["CrtExpDte"].ToString());
                    cert.Cert2 = reader["CrtNm2"].ToString();
                    cert.Org2 = reader["CrtOrg2"].ToString();
                    cert.ExpryDte2 = Convert.ToDateTime(reader["CrtExp2"].ToString());
                    cert.Cert3 = (reader["CrtNm3"].ToString());
                    cert.Org3 = reader["CrtOrg3"].ToString();
                    cert.ExpryDte3 = Convert.ToDateTime(reader["CrtExp3"].ToString());
                 
                }

                return cert;

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
