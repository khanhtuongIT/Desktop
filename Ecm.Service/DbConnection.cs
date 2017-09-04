using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Profile;

namespace Ecm.Service
{
    public class DbConnection
    {
        private static System.Data.OleDb.OleDbConnection m_connOledb;
        public static System.Data.OleDb.OleDbConnection OleDbConnection
        {
            get
            {
                while (m_connOledb == null)
                {

                    m_connOledb = new System.Data.OleDb.OleDbConnection();

                    try
                    {
                         GoobizFrame.Profile.Config config = new  GoobizFrame.Profile.Config( @"Resources\Database.config");
                        config.GroupName = "Database";
                        string ConnectionString = "" + config.GetValue("DbConnectionInfo", "ConnectionString");
                        //decrypt connection string
                        //m_connOledb.ConnectionString =  GoobizFrame.Windows.HelperClasses.CryptorEngine.Decrypt(ConnectionString,"SunoneLine",true);
                        m_connOledb.Open();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return m_connOledb;
            }
        }
    }
}
