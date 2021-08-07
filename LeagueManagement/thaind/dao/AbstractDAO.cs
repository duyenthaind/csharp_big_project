// @author duyenthai

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using log4net;

namespace LeagueManagement.thaind.dao
{
    public class AbstractDAO
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AbstractDAO));
        
        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (var connection = ConnectionProvider.GetConnection())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                try
                {
                    var sqlCommand = new SqlCommand(query, connection);
                    foreach (var entry in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.Error("Error: ", ex);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            object result = null;
            using (var connection = ConnectionProvider.GetConnection())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                try
                {
                    //insert into <table_name> output INSERTED.id values <values_here>
                    var sqlCommand = new SqlCommand(query, connection);
                    foreach (var entry in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                    }

                    result = sqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    log.Error("Error: ", ex);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }

        public DataTable FetchData(string query, Dictionary<string, object> parameters)
        {
            DataTable result = null;
            using (var connection = ConnectionProvider.GetConnection())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                try
                {
                    var sqlCommand = new SqlCommand(query, connection);
                    foreach (var entry in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                    }

                    var sqlReader = sqlCommand.ExecuteReader();
                    result = new DataTable();
                    result.Load(sqlReader);
                }
                catch (Exception ex)
                {
                    log.Error("Error: ", ex);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }
    }
}