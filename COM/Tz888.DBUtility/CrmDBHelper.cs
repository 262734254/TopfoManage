using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tz888.DBUtility
{
    public class CrmDBHelper
    {
        public static string sqlconn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public static string company = System.Configuration.ConfigurationManager.ConnectionStrings["CompanyShow"].ToString();//��ҵչ��

        public CrmDBHelper()
        {

        }

        /// <summary>
        ///���  ���� ����ID
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        public int ExecuteQuerySQLID(string cmdText, params SqlParameter[] sqlParam)
        {

            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {

                    conn.Open();
                }
                catch
                {
                    return 0;
                }
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddRange(sqlParam);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select @@IDENTITY";
                    return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        /// <summary>
        /// ��� ɾ�� ����
        /// </summary>
        /// <param name="cmdText">SQL���</param>
        /// <param name="sqlParam">����</param>
        /// <returns></returns>
        public int ExecuteQuerySQL(string cmdText, ref SqlParameter[] sqlParam)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    return 0;
                }
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddRange(sqlParam);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// ����DataSet��������Դ
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>����DataSet</returns>
        public DataSet ExecuteQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                return ds;
            }
        }
        /// <summary>
        /// ����DataSet��������Դ
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="sqlParam">����</param>
        /// <returns>����DataSet</returns>
        public DataSet ExecuteQuery(string sql, ref SqlParameter[] sqlParam)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(sqlParam);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    return ds;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// ����SqlDataReader
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="sqlParam">����</param>
        /// <returns>����SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string sql, ref SqlParameter[] sqlParam)
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(sqlParam);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ����ָ���Ĵ洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">���ڴ洢�������������������</param>
        /// <returns></returns>
        public bool RunProcLob(
            string procName,
            SqlParameter[] prams)
        {
            bool blret = false;
            using (SqlConnection connection = new SqlConnection(company))
            {
                //int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, procName, prams);
                int rowsAffected = command.ExecuteNonQuery();
                //result = Convert.ToInt32(command.Parameters[prams.Length - 1].Value);
                //Connection.Close();
                if (rowsAffected > 0)
                {
                    blret = true;
                }

            }
            return blret;
        }
        public bool Exist(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingles(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// ����SqlDataReader
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>����SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 
        /// ����DataTable����
        /// </summary>
        /// <param Name="safeSql"></param>
        /// <returns></returns>
        public DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(sqlconn))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(safeSql, Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(sqlconn))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        public  DataSet Query1(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                return ds;
            }
        }
        public DataSet Query(string sqlString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        /// <summary>
        /// ����SqlDataReader
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>����SqlDataReader</returns>
        public SqlDataReader ExecuteReaders(string strSQL)
        {
            SqlConnection connection = new SqlConnection(company);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }
        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺ʹ�ú�һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="strSQL">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteReaders(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(company);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }
       
        public DataSet Querys(string sqlString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        public object GetSingles(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public int ExecuteSqls(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        /// <summary>X
        /// ���� SqlCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
           // command.Parameters.Clear();
            command.CommandTimeout = 0;
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // ���δ����ֵ���������,���������DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                   
                }
            }
           // command.Parameters.Clear();
            return command;
        }

        /// <summary>
        /// ���� SqlCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand ����ʵ��</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="rowsAffected">Ӱ�������</param>
        /// <returns></returns>
        public  int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(dataSet, tableName);
                    connection.Close();
                    return dataSet;
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    return new DataSet();
                }

            }
        }

        #region ��ҵչ��
        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureShow(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(dataSet, tableName);
                    connection.Close();
                    return dataSet;
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    return new DataSet();
                }

            }
        }
        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public object GetSingleShow(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        public DataSet QueryShow(string sqlString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        /// <summary>
        /// ����DataSet��������Դ
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>����DataSet</returns>
        public DataSet ExecuteQueryShow(string sql)
        {
            using (SqlConnection connection = new SqlConnection(company))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                return ds;
            }
        }
        #endregion

    }
}
