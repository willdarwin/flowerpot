using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTA.Model;

namespace TTA.DAL.DataAccess
{
    

    public interface IDataAccess
    {
        void Open();
        void Close();
        void BeginTran();
        void CommitTran();
        void RollbackTran();

        int ExecuteNonQuery(string sql, params QueryParameter[] list);
        object ExecuteScalar(string sql, params QueryParameter[] list);
        DataTable GetTable(string sql, params QueryParameter[] list);
        IDataReader GetReader(string sql, params QueryParameter[] list);
        DataTable ExecuteSql(string sql);

    }

    public class SQLServerDataAccess : IDataAccess
    {

        public SqlConnection Connection { get; private set; }

        private SqlTransaction transaction;

        public SQLServerDataAccess(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        #region IDataAccess 成员

        public void Open()
        {
            if (this.Connection.State.Equals(ConnectionState.Closed))
            {
                this.Connection.Open();
            }
        }

        public void Close()
        {
            if (this.Connection != null && this.Connection.State.Equals(ConnectionState.Open))
            {
                this.Connection.Close();
            }
        }

        public void BeginTran()
        {
            transaction = this.Connection.BeginTransaction();
        }

        public void CommitTran()
        {
            this.transaction.Commit();
        }

        public void RollbackTran()
        {
            this.transaction.Rollback();
        }

        public int ExecuteNonQuery(string sql, params QueryParameter[] list)
        {
            SqlCommand command = new SqlCommand();
            if (transaction != null)
            {
                command.Transaction = transaction;
            }
            PrepareCommand(command, CommandType.Text, sql, list);
            int i = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return i;
        }

        public object ExecuteScalar(string sql, params QueryParameter[] list)
        {
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, CommandType.Text, sql, list);
            object obj = command.ExecuteScalar();
            command.Parameters.Clear();
            return obj;
        }

        public System.Data.DataTable GetTable(string sql, params QueryParameter[] list)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, CommandType.Text, sql, list);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Parameters.Clear();
            return table;
        }

        public IDataReader GetReader(string sql, params QueryParameter[] list)
        {
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, CommandType.Text, sql, list);
            SqlDataReader reader = command.ExecuteReader();
            command.Parameters.Clear();
            return reader;
        }

        public System.Data.DataTable ExecuteSql(string sql)
        {
            SqlDataAdapter myda = new SqlDataAdapter(sql, this.Connection);
            DataTable result = new DataTable();
            myda.Fill(result);
            return result;
        }
       
        #endregion

        private void PrepareCommand(SqlCommand command, CommandType type, string commandText, params QueryParameter[] list)
        {
            command.CommandText = commandText;
            command.CommandType = type;
            command.Connection = this.Connection;
            if (list != null && list.Length > 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    command.Parameters.AddWithValue(list[i].Name, list[i].Value);
                }
            }
        }    
    }

    
}

