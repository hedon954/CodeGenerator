using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Template
{
    /// <summary>
    /// 数据库操作助手模板
    /// </summary>
    public class MSSQLHelperTemplate
    {

        /// <summary>
        /// 生成数据库操作助手类模板
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static string GETMSSQLHelperTemplate(string ns,string connStr)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("using System;\r\n");
            sb.Append("using System.Collections.Generic;\r\n");
            sb.Append("using System.Linq;\r\n");
            sb.Append("using System.Text;\r\n");
            sb.Append("using System.Data;\r\n");
            sb.Append("using System.Data.SqlClient;\r\n");
            sb.Append("namespace "+ns+".DAL\r\n");
            sb.Append("{\r\n");
            sb.Append("    /// <summary>\r\n");
            sb.Append("    /// MSSQL数据库操作类\r\n");
            sb.Append("    /// </summary>\r\n");
            sb.Append("    public class MSSQLHelper\r\n");
            sb.Append("    {\r\n");
            sb.Append("        private SqlConnection conn = null;\r\n");
            sb.Append("        private SqlCommand cmd = null;\r\n");
            sb.Append("        private SqlDataReader sdr = null;\r\n");
            sb.Append("        public MSSQLHelper()\r\n");
            sb.Append("        {\r\n");
            sb.Append("            //string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[\"connStr\"].ToString();\r\n");
            sb.Append("            //使用上面方法时请在Web.config的<configuration>中加上以下注释节点\r\n");
            sb.Append("            //<connectionStrings>\r\n");
            sb.Append("            //    <add name=\"connStr\" connectionString=\""+connStr+"\" />	\r\n");
            sb.Append("            //</connectionStrings>\r\n");
            sb.Append("            string connStr = @\""+connStr+"\";\r\n");
            sb.Append("            conn = new SqlConnection(connStr);\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 创建Command对象，默认是SQL语句\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <param name=\"sql\">SQL语句</param>\r\n");
            sb.Append("        public void CreateCommand(string sql)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            conn.Open();\r\n");
            sb.Append("            cmd = new SqlCommand(sql, conn);\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 创建存储过程的Command对象\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <param name=\"procName\">存储过程名称</param>\r\n");
            sb.Append("        public void CreateStoredCommand(string procName)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            conn.Open();\r\n");
            sb.Append("            cmd = new SqlCommand(procName, conn);\r\n");
            sb.Append("            cmd.CommandType = CommandType.StoredProcedure;\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 添加参数，默认是输入参数\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <param name=\"paramName\">参数名称</param>\r\n");
            sb.Append("        /// <param name=\"value\">值</param>\r\n");
            sb.Append("        public void AddParameter(string paramName, object value)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            SqlParameter p = new SqlParameter(paramName, value);\r\n");
            sb.Append("            cmd.Parameters.Add(p);\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 添加输出参数，用于存储过程\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <param name=\"paramName\">参数名称</param>\r\n");
            sb.Append("        /// <param name=\"value\">值</param>\r\n");
            sb.Append("        public void AddOutputParameter(string paramName)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            SqlParameter p = new SqlParameter();\r\n");
            sb.Append("            p.ParameterName = paramName;\r\n");
            sb.Append("            p.Direction = ParameterDirection.Output;\r\n");
            sb.Append("            p.Size = 20;\r\n");
            sb.Append("            cmd.Parameters.Add(p);\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 获取输出参数的值\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <param name=\"paramName\">输出参数名称</param>\r\n");
            sb.Append("        /// <returns></returns>\r\n");
            sb.Append("        public string GetOutputParameter(string paramName)\r\n");
            sb.Append("        {\r\n");
            sb.Append("            return cmd.Parameters[paramName].Value.ToString();\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        ///  执行增删改SQL语句或存储过程\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <returns></returns>\r\n");
            sb.Append("        public bool ExecuteNonQuery()\r\n");
            sb.Append("        {\r\n");
            sb.Append("            int res;\r\n");
            sb.Append("            try\r\n");
            sb.Append("            {\r\n");
            sb.Append("                res = cmd.ExecuteNonQuery();\r\n");
            sb.Append("                if (res > 0)\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    return true;\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            catch (Exception ex)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                throw ex;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            finally\r\n");
            sb.Append("            {\r\n");
            sb.Append("                if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    conn.Close();\r\n");
            sb.Append("					conn.Dispose();\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return false;\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        ///  执行查询SQL语句或存储过程\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <returns></returns>\r\n");
            sb.Append("        public DataTable ExecuteQuery()\r\n");
            sb.Append("        {\r\n");
            sb.Append("            DataTable dt = new DataTable();\r\n");
            sb.Append("            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))\r\n");
            sb.Append("            {\r\n");
            sb.Append("                dt.Load(sdr);\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return dt;\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 返回查询SQL语句或存储过程查询出的结果的第一行第一列的值\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <returns></returns>\r\n");
            sb.Append("        public string ExecuteScalar()\r\n");
            sb.Append("        {\r\n");
            sb.Append("            string res = \"\";\r\n");
            sb.Append("            try\r\n");
            sb.Append("            {\r\n");
            sb.Append("                object obj = cmd.ExecuteScalar();\r\n");
            sb.Append("                if (obj != null)\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    res = obj.ToString();\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            catch (Exception ex)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                throw ex;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            finally\r\n");
            sb.Append("            {\r\n");
            sb.Append("                if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    conn.Close();\r\n");
            sb.Append("					conn.Dispose();\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            return res;\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 返回IDataReader只读数据流\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        /// <returns></returns>\r\n");
            sb.Append("        public IDataReader ExecuteReader()\r\n");
            sb.Append("        {\r\n");
            sb.Append("            try\r\n");
            sb.Append("            {\r\n");
            sb.Append("                sdr = cmd.ExecuteReader();\r\n");
            sb.Append("                return sdr;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            catch (Exception ex)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                throw ex;\r\n");
            sb.Append("            }\r\n");
            sb.Append("        }\r\n");
            sb.Append("        /// <summary>\r\n");
            sb.Append("        /// 关闭数据库连接\r\n");
            sb.Append("        /// </summary>\r\n");
            sb.Append("        public void CloseConn()\r\n");
            sb.Append("        {\r\n");
            sb.Append("            try\r\n");
            sb.Append("            {\r\n");
            sb.Append("                if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    conn.Close();\r\n");
            sb.Append("					conn.Dispose();\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("            catch (Exception ex)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                throw ex;\r\n");
            sb.Append("            }\r\n");
            sb.Append("            finally\r\n");
            sb.Append("            {\r\n");
            sb.Append("                if (conn.State == ConnectionState.Open)\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    conn.Close();\r\n");
            sb.Append("					conn.Dispose();\r\n");
            sb.Append("                }\r\n");
            sb.Append("            }\r\n");
            sb.Append("        }\r\n");
            sb.Append("    }\r\n");
            sb.Append("}\r\n");
            sb.Append("\r\n");


            return sb.ToString();
        }
    }
}
