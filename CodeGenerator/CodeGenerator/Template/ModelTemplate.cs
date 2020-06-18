using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeGenerator.Template
{
    /// <summary>
    /// Model 的模板类
    /// </summary>
    public class ModelTemplate
    {
        /// <summary>
        /// 生成 Model 模板代码
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="author">作者</param>
        /// <param name="className">类名</param>
        /// <param name="connStr">数据库连接字符串</param>
        /// <returns></returns>
        public static string GetModelTemplate(string ns,string tableName,string author,string className,string connStr)
        {
            #region 生成 Model 的模板代码
            StringBuilder sb = new StringBuilder();

            /*
             * 基础部分
             */
            sb.Append("using System;\n\r");
            sb.Append("namespace "+ns+".Model\n\r");
            sb.Append("    {\n\r");
            sb.Append("        /// <summary>\n\r");
            sb.Append("        /// ["+tableName+"]表实体类\n\r");
            sb.Append("        /// 作者:"+author+"\n\r");
            sb.Append("        /// 创建时间:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\n\r");
            sb.Append("        /// </summary>\n\r");
            sb.Append("        [Serializable]\n\r");
            sb.Append("        public partial class "+className+"\n\r");
            sb.Append("        {\n\r");

            /*
             * 无参构造函数
             */
            sb.Append("            public "+className+"()\n\r");
            sb.Append("            { }\n\r");

            /*
             * 连接数据库，查询每个表中的每一项，遍历建立类中的属性
             */
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connStr);
                sqlConnection.Open();
                string sql = "";
                sql += "SELECT a.name as '字段名',c.name '类型',sm.text as '默认值',a.isnullable as '是否为空', ";
                sql += "a.length as '长度',a.xscale as '小数位数',e.value as '字段说明' ";
                sql += "FROM syscolumns a ";
                sql += "left join systypes b on a.xusertype = b.xusertype ";
                sql += "left join systypes c on a.xtype = c.xusertype ";
                sql += "inner join sysobjects d on a.id = d.id and d.xtype = 'U' ";
                sql += "left join syscomments sm on a.cdefault = sm.id ";
                sql += "left join sys.extended_properties e on a.id = e.major_id and a.colid = e.minor_id and ";
                sql += "e.name = 'MS_Description' where d.name = '" + tableName + "' ";


                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                //遍历
                while (sqlDataReader.Read())
                {
                    sb.Append("            private " + Tool.ConvertSqlTypeToNETType(sqlDataReader["类型"].ToString()) + " _" + sqlDataReader["字段名"] + "" + Tool.getDbFieldDefaultValue(sqlDataReader["默认值"].ToString()) + ";\r\n");
                    sb.Append("            /// <summary>\r\n");
                    sb.Append("            /// " + sqlDataReader["字段说明"] + "\r\n");
                    sb.Append("            /// </summary>\r\n");
                    sb.Append("            public " + Tool.ConvertSqlTypeToNETType(sqlDataReader["类型"].ToString()) + " " + sqlDataReader["字段名"] + "\r\n");
                    sb.Append("            {\r\n");
                    sb.Append("                set { _" + sqlDataReader["字段名"] + " = value; }\r\n");
                    sb.Append("                get { return _" + sqlDataReader["字段名"] + "; }\r\n");
                    sb.Append("            }\r\n");
                }

                sb.Append("        }\n\r");
                sb.Append("    }\n\r");
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            
            return sb.ToString();

            #endregion
        }
    }
}
