using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.Template
{
    public class SqlFileTemplate
    {
        public static string GetSqlFileTemplate(string connStr,List<string> selectItems)
        {
            SqlConnection sqlConnection = null;
            StringBuilder sb = null;
            string dbName = null;  //数据库名称
            try
            {
                sqlConnection = new SqlConnection(connStr);  //连接数据库
                sqlConnection.Open();                        //打开数据库
                dbName = sqlConnection.Database;             //获得数据库名称


                #region 数据库结构表模板
                sb = new StringBuilder();

                sb.Append("<!DOCTYPE html>\r\n");
                sb.Append("<html>\r\n");
                sb.Append(" <head> \r\n");
                sb.Append("  <meta charset=\"utf-8\" /> \r\n");
                sb.Append("  <title>" + dbName + "数据库表结构</title> \r\n");
                sb.Append("  <style type=\"text/css\">\r\n");
                sb.Append("        body,table,h1,h2,h3\r\n");
                sb.Append("        {\r\n");
                sb.Append("            font-family:\"Microsoft YaHei\" ;\r\n");
                sb.Append("        }\r\n");
                sb.Append("        .tableStyle\r\n");
                sb.Append("        {\r\n");
                sb.Append("            width: 100%;\r\n");
                sb.Append("            border-collapse: collapse;\r\n");
                sb.Append("        }\r\n");
                sb.Append("        .tableStyle td, .tableStyle th\r\n");
                sb.Append("        {\r\n");
                sb.Append("            border: 1px solid #9EC9FE;\r\n");
                sb.Append("            padding: 3px;\r\n");
                sb.Append("        }\r\n");
                sb.Append("        .tableStyle th\r\n");
                sb.Append("        {\r\n");
                sb.Append("            background: #ECF3FD;\r\n");
                sb.Append("        }\r\n");
                sb.Append("        .tableStyle .tableStyleTxt\r\n");
                sb.Append("        {\r\n");
                sb.Append("            padding: 4px 3px;\r\n");
                sb.Append("            height: 14px;\r\n");
                sb.Append("            line-height: 14px;\r\n");
                sb.Append("            border: 1px solid #A0A0A0;\r\n");
                sb.Append("            color: #404040;\r\n");
                sb.Append("        }\r\n");
                sb.Append("        .tableStyle .tableStyleTextarea\r\n");
                sb.Append("        {\r\n");
                sb.Append("            border: 1px solid #A0A0A0;\r\n");
                sb.Append("            color: #404040;\r\n");
                sb.Append("            padding: 4px 3px;\r\n");
                sb.Append("        }\r\n");
                sb.Append("        .tableStyle .tableStyleBtn\r\n");
                sb.Append("        {\r\n");
                sb.Append("            border: 1px solid #707070;\r\n");
                sb.Append("            background: #D8D8D8;\r\n");
                sb.Append("            color: Black;\r\n");
                sb.Append("            padding: 3px;\r\n");
                sb.Append("            text-decoration: none;\r\n");
                sb.Append("        }\r\n");
                sb.Append("    </style> \r\n");
                sb.Append(" </head> \r\n");
                sb.Append(" <body> \r\n");
                sb.Append("  <center> \r\n");
                sb.Append("   <h2>数据库名：" + dbName + "</h2> \r\n");
                sb.Append("   \r\n");

                //遍历选中的表，分别创建数据库表结构
                foreach (string item in selectItems)
                {
                    //连接数据库获取表信息
                    string tableName = item.ToString();

                    String sql = "";
                    sql += "SELECT a.name as '字段名',c.name '类型',sm.text as '默认值',a.isnullable as '是否为空', ";
                    sql += "a.length as '长度',a.xscale as '小数位数',e.value as '字段说明'";
                    sql += "FROM syscolumns a";
                    sql += "left join systypes b on a.xusertype = b.xusertype";
                    sql += "left join systypes c on a.xtype = c.xusertype";
                    sql += "inner join sysobjects d on a.id = d.id and d.xtype = 'U'";
                    sql += "left join syscomments sm on a.cdefault = sm.id";
                    sql += "left join sys.extended_properties e on a.id = e.major_id and a.colid = e.minor_id and";
                    sql += "e.name = 'MS_Description' where d.name = '" + tableName + "'";

                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    //查询数据
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    //存储数据
                    DataTable dataTable = new DataTable();
                    dataTable.Load(sqlDataReader);

                    //拼接每一个表
                    sb.Append("   <h3>表名：" + item.ToString() + "</h3> \r\n");
                    sb.Append("   <table class=\"tableStyle\"> \r\n");
                    sb.Append("    <tbody>\r\n");
                    sb.Append("     <tr> \r\n");
                    sb.Append("      <th> 序号 </th> \r\n");
                    sb.Append("      <th> 列名 </th> \r\n");
                    sb.Append("      <th> 数据类型 </th> \r\n");
                    sb.Append("      <th> 长度 </th> \r\n");
                    sb.Append("      <th> 小数位 </th> \r\n");
                    sb.Append("      <th> 允许空 </th> \r\n");
                    sb.Append("      <th> 默认值 </th> \r\n");
                    sb.Append("      <th> 说明 </th> \r\n");
                    sb.Append("     </tr> \r\n");

                    //遍历建立每一行
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow dataRow = dataTable.Rows[i];
                        sb.Append("     <tr> \r\n");
                        sb.Append("      <td> " + (i + 1) + " &nbsp; </td> \r\n");
                        sb.Append("      <td> " + dataRow["字段名"] + " &nbsp; </td> \r\n");
                        sb.Append("      <td> " + dataRow["类型"] + " &nbsp; </td> \r\n");
                        sb.Append("      <td> " + dataRow["长度"] + " &nbsp; </td> \r\n");
                        sb.Append("      <td> " + dataRow["小数位数"] + " &nbsp; </td> \r\n");
                        sb.Append("      <td> " + dataRow["是否为空"].ToString() == "0" ? "否" : "是" + "</td>\r\n");
                        sb.Append("      <td> " + dataRow["默认值"] + "&nbsp; </td> \r\n");
                        sb.Append("      <td> " + dataRow["表说明"] + " &nbsp; </td> \r\n");
                        sb.Append("     </tr> \r\n");
                    }
                    sb.Append("    </tbody>\r\n");
                    sb.Append("   </table> \r\n");
                }

                sb.Append("  </center> \r\n");
                sb.Append(" </body>\r\n");
                sb.Append("</html>\r\n");
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();  //关闭数据库
            }


            return sb.ToString();
        }
    }
}