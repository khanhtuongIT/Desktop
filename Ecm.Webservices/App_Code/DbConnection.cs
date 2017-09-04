using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecm.Webservice
{
    public class DbConnection
    {
        private static System.Data.OleDb.OleDbConnection m_connOledb;
        public static System.Data.OleDb.OleDbConnection OleDbConnection
        {
            get
            {
                while (m_connOledb == null || m_connOledb.State != System.Data.ConnectionState.Open || m_connOledb.State == System.Data.ConnectionState.Broken)
                {
                    try
                    {
                        m_connOledb = new System.Data.OleDb.OleDbConnection();
                        m_connOledb.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                        m_connOledb.Open();
                    }
                    catch (Exception ex)
                    {
                        m_connOledb.Close();
                    }
                }
                return m_connOledb;
            }
        }
    }
}