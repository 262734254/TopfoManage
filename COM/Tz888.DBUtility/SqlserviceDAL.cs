using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace Tz888.DBUtility
{
   public class SqlserviceDAL
    {
        protected static String connectionString = ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString;
        protected static String connectionString2 = ConfigurationManager.ConnectionStrings["SelfCreateWeb"].ConnectionString;
        protected static String connectionStringSms = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
        protected static String UnionConnString = ConfigurationManager.ConnectionStrings["UnionConnString"].ConnectionString;
        protected static String UnionConnString0 = ConfigurationManager.ConnectionStrings["UnionConnString0"].ConnectionString;//使用专业服务联盟数据库invest_Union
        protected static String connectionString3 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

       public SqlserviceDAL()
       { 

       }


       /// <summary>
       /// 不含存储过程参数
       /// </summary>
       /// <param name="strname">存储过程</param>
       /// <returns></returns>
       public static DataSet ExecuteQueryStore(string strname)
       {
           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               try
               {
                   if (conn.State == ConnectionState.Closed)
                   {
                       conn.Open();
                   }
               }
               catch
               {
                   conn.Close();
                   conn.Dispose();
                   return null;
               }
               finally
               {
                   conn.Close();
                   conn.Dispose();
               }
               using (SqlCommand cmd = new SqlCommand(strname, conn))
               {
                   try
                   {
                       cmd.CommandType = CommandType.StoredProcedure; //存储过程名称
                       using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                       {
                           try
                           {
                               DataSet ds = new DataSet();
                               da.Fill(ds);
                               return ds;
                           }
                           catch
                           {
                               return null;
                           }
                       }
                   }
                   catch
                   {
                       conn.Close();
                       conn.Dispose();
                       return null;
                   }
                   finally
                   {
                       conn.Close();
                       conn.Dispose();
                   }
               }
           }
       }

       /// <summary>
       /// 作用：返回DataSet
       /// </summary>
       /// <param name="strname">存储过程</param>
       /// <param name="parms">参数</param>
       /// <returns>DataSet</returns>
       public static DataSet ExecuteQueryStore(string strname, ref SqlParameter[] parms)
       {
           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               try
               {
                   if (conn.State == ConnectionState.Closed)
                   {
                       conn.Open();
                   }

               }
               catch
               {
                   conn.Close();
                   conn.Dispose();
                   return null;
               }
               finally
               {
                   conn.Close();
                   conn.Dispose();
               }
               using (SqlCommand cmd = new SqlCommand(strname, conn))
               {
                   try
                   {
                       cmd.CommandType = CommandType.StoredProcedure; //存储过程名称
                       //添加存储过程参数
                       if (parms != null)
                       {
                           foreach (SqlParameter parameter in parms)
                           {
                               cmd.Parameters.Add(parameter);
                           }
                       }
                       using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                       {
                           try
                           {
                               DataSet ds = new DataSet();
                               da.Fill(ds);
                               cmd.Parameters.Clear();
                               return ds;
                           }
                           catch
                           {
                               conn.Close();
                               conn.Dispose();
                               return null;
                           }
                       }
                   }
                   catch
                   {
                       conn.Close();
                       conn.Dispose();
                       return null;
                   }
                   finally
                   {
                       conn.Close();
                       conn.Dispose();
                   }
               }
           }
       }


       /// <summary>
       /// 返回DataSet类型数据源
       /// </summary>
       /// <param name="sql">SQL语句</param>
       /// <returns>返回DataSet</returns>
       public static DataSet ExecuteQuery(string sql)
       {
          

           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               DataSet ds = new DataSet();

               //try
               //{
                   if (conn.State == ConnectionState.Closed)
                   {
                       conn.Open();
                   }
               //}
               //catch
               //{
               //    conn.Close();
               //    conn.Dispose();
               //    return null;
               //}
               //finally
               //{
               //    conn.Close();
               //    conn.Dispose();
               //}

               using (SqlCommand cmd = new SqlCommand(sql, conn))
               {
                   //try
                  // {
                      using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                       {
                           try
                           {
                             //  DataSet ds = new DataSet();
                               da.Fill(ds,"ds");
                              // return ds;
                           }
                           //catch
                           //{
                           //    return null;
                           //}
                           catch (System.Data.SqlClient.SqlException ex)
                           {
                               throw new Exception(ex.Message);
                           }
                       }
                  // }
                //  catch //(System.Data.SqlClient.SqlException ex)
                  // {
                      // conn.Close();
                     //  conn.Dispose();
                     //  throw new Exception(ex.Message);
                      // return null;
                 //  }
                   //finally
                   //{
                   //   // conn.Close();
                   //    conn.Dispose();
                   //}
               }

               return ds;
           }
       }

       /// <summary>
       /// 返回DataSet类型数据源不带参数
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="sqlParam"></param>
       /// <returns></returns>
       public static DataSet ExecuteQuery(string sql, ref SqlParameter[] sqlParam)
       {
           using (SqlConnection conn = new SqlConnection(connectionString))
           {
               try
               {
                   if (conn.State == ConnectionState.Closed)
                   {
                       conn.Open();
                   }
               }
               catch
               {
                   conn.Close();
                   conn.Dispose();
                   return null;
               }
               finally
               {
                   conn.Close();
                   conn.Dispose();
               }
               using (SqlCommand cmd = new SqlCommand(sql, conn))
               {
                   try
                   {
                       cmd.Parameters.AddRange(sqlParam);
                       using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                       {
                           try
                           {
                               DataSet ds = new DataSet();
                               da.Fill(ds);
                               return ds;
                           }
                           catch
                           {
                               conn.Close();
                               conn.Dispose();
                               return null;
                           }
                       }
                   }
                   catch
                   {
                       conn.Close();
                       conn.Dispose();
                       return null;
                   }
                   finally
                   {
                       conn.Close();
                       conn.Dispose();
                   }
               }
           }
       }

    }
}
