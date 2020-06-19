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
    /// <summary>
    /// DAL 的模板类
    /// </summary>
    public class DALTemplate
    {
        /// <summary>
        /// 生成 DAL 模板代码
        /// </summary>
        /// <param name="ns">命名空间</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="author">作者</param>
        /// <param name="className">类名</param>
        /// <param name="connStr">数据库连接字符串</param>
        /// <returns>DAL 模板代码</returns>
        public static string GetDALTemplate(string ns, string tableName, string author, string className, string connStr)
        {
            #region 生成 DAL 模板代码

            #region 连接数据库
            /*
             * 连接数据库，查询出数据库表的详细信息
             */
            SqlConnection sqlConnection = new SqlConnection(connStr);
            DataTable dataTable = new DataTable();
            try
            {
                //打开数据库
                sqlConnection = new SqlConnection(connStr);
                sqlConnection.Open();

                //定义 sql 语句
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

                //声明 SqlCommand
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                //查询数据
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                //声明一个datatable来存放数据
                dataTable = new DataTable();
                dataTable.Load(sqlDataReader);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            StringBuilder sb = new StringBuilder();

            #region 读取属性名与属性值
            //定义两个临时字符串
            string fieldNames = "";   //存放字段名序列
            string fieldValues = "";  //存放每个字段的值

            //遍历结果集
            for (int i =0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                if(dataRow["字段名"].ToString() == "id")
                {
                    continue;  //id是自增的，所以不需要插入id值，跳过
                }
                if (i == dataTable.Rows.Count - 1)
                {
                    fieldNames += "["+dataRow["字段名"].ToString()+"] ";
                    fieldValues += "@" + dataRow["字段名"].ToString()+" ";   //最后一个值后面不需要逗号
                }
                else
                {
                    fieldNames += "[" + dataRow["字段名"].ToString() + "], ";
                    fieldValues += "@" + dataRow["字段名"].ToString() + ", ";
                }
            }
            #endregion


            /*
             * 基础部分
             */
            #region 基础部分
            sb.Append("using System;\n\r");
            sb.Append("using System.Collections.Generic;\n\r");
            sb.Append("using System.Linq;\n\r");
            sb.Append("using System.Text;\n\r");
            sb.Append("using System.Data;\n\r");
            sb.Append("namespace "+ns+".DAL\n\r");
            sb.Append("    {\n\r");
            sb.Append("        /// <summary>\n\r");
            sb.Append("        /// ["+tableName+"]表数据访问类\n\r");
            sb.Append("        /// 作者:"+author+"\n\r");
            sb.Append("        /// 创建时间:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\n\r");
            sb.Append("        /// </summary>\n\r");
            sb.Append("        public class "+className+"DAL\n\r");
            sb.Append("        {\n\r");
            sb.Append("            public "+className+"DAL()\n\r");
            sb.Append("            { }\n\r\r\n");
            #endregion

            /*
             * 增
             */
            #region 增加部分
            sb.Append("            /// <summary>\n\r");
            sb.Append("            /// 增加一条数据\n\r");
            sb.Append("            /// </summary>\n\r");
            sb.Append("            public int Add("+ns+".Model."+className+" model)\n\r");
            sb.Append("            {\n\r");
            sb.Append("                StringBuilder strSql = new StringBuilder();\n\r");
            sb.Append("                strSql.Append(\"insert into ["+tableName+"](\");\n\r");
            sb.Append("                strSql.Append(\""+fieldNames+" )\");\n\r");
            sb.Append("                strSql.Append(\" values (\");\n\r");
            sb.Append("                strSql.Append(\""+fieldValues+" )\");\n\r");
            sb.Append("                strSql.Append(\";select @@IDENTITY\");\n\r");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\n\r");
            sb.Append("                h.CreateCommand(strSql.ToString());\n\r");

            /*
             * 判断是否有值：有值=》插入 | 无值=》跳过
             */
            foreach (DataRow row in dataTable.Rows)
            {
                if(row["字段名"].ToString() == "id") 
                {
                    continue;//忽略掉 id
                }
                else if( row["类型"].ToString() == "dateTime")//日期需要进行类型转换
                {
                    sb.Append("                if (model."+row["字段名"].ToString()+" == null)\n\r");
                    sb.Append("                {\n\r");
                    sb.Append("                    h.AddParameter(\"@"+row["字段名"].ToString()+"\", DateTime.Now);\n\r");
                    sb.Append("                }\n\r");
                    sb.Append("                else\n\r");
                    sb.Append("                {\n\r");
                    sb.Append("                    h.AddParameter(\"@"+row["字段名"].ToString()+"\", model."+row["字段名"].ToString()+");\n\r");
                    sb.Append("                }\n\r");
                }
                else
                {
                    sb.Append("                if (model." + row["字段名"].ToString() + " == null)\n\r");
                    sb.Append("                {\n\r");
                    sb.Append("                    h.AddParameter(\"@" + row["字段名"].ToString() + "\", DBNull.Value);\n\r");
                    sb.Append("                }\n\r");
                    sb.Append("                else\n\r");
                    sb.Append("                {\n\r");
                    sb.Append("                    h.AddParameter(\"@" + row["字段名"].ToString() + "\", model." + row["字段名"].ToString() + ");\n\r");
                    sb.Append("                }\n\r");
                }
            }
            

            sb.Append("                int result;\n\r");
            sb.Append("                string obj = h.ExecuteScalar();\n\r");
            sb.Append("                if (!int.TryParse(obj, out result))\n\r");
            sb.Append("                {\n\r");
            sb.Append("                    return 0;\n\r");
            sb.Append("                }\n\r");
            sb.Append("                return result;\n\r");
            sb.Append("            }\n\r\r\n");


            #endregion

            /*
             * 改
             */
            #region 修改部分
            //定义一个临时字符串，用来存放字段及其值
            string fieldsList = "";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                if(row["字段名"].ToString() == "id")
                {
                    continue;   //id自增，不需要为其赋值
                }
                else if(i == dataTable.Rows.Count-1)   //最后一个字段后面不需要加逗号
                {
                    fieldsList += "[" + row["字段名"].ToString() + "]=@" + row["字段名"].ToString() + " ";
                }
                else
                {
                    fieldsList += "[" + row["字段名"].ToString() + "]=@" + row["字段名"].ToString() + ", ";
                }
            }


            sb.Append("            /// <summary>\n\r");
            sb.Append("            /// 更新一条数据\n\r");
            sb.Append("            /// </summary>\n\r");
            sb.Append("            public bool Update("+ns+".Model."+className+ " model)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"update ["+tableName+ "] set \");\r\n");
            sb.Append("                strSql.Append(\""+fieldsList+ "   \");\r\n");
            sb.Append("                strSql.Append(\" where id=@id \");\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");

            /*
             * 遍历检查每个属性是否有值：有值=》赋值 | 无值=》跳过
             */
            foreach (DataRow row in dataTable.Rows)
            {
                sb.Append("                if (model."+row["字段名"]+ " == null)\r\n");
                sb.Append("                {\r\n");
                sb.Append("                    h.AddParameter(\"@"+row["字段名"]+ "\", DBNull.Value);\r\n");
                sb.Append("                }\r\n");
                sb.Append("                else\r\n");
                sb.Append("                {\r\n");
                sb.Append("                    h.AddParameter(\"@" + row["字段名"] + "\", model." + row["字段名"] + ");\r\n");
                sb.Append("                }\r\n");
            }    
            sb.Append("                return h.ExecuteNonQuery();\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            /*
             * 删
             */
            #region 删除部分
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 删除一条数据\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public bool Delete(int id)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"delete from ["+tableName+"] \");\r\n");
            sb.Append("                strSql.Append(\" where id=@id \");\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("                h.AddParameter(\"@id\", id);\r\n");
            sb.Append("                return h.ExecuteNonQuery();\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 根据条件删除
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 根据条件删除数据\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public bool DeleteByCond(string cond)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"delete from ["+tableName+"] \");\r\n");
            sb.Append("                if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    strSql.Append(\" where \" + cond);\r\n");
            sb.Append("                }\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("                return h.ExecuteNonQuery();\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion


            /*
             * 查
             */
            #region 取一个字段的值
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 取一个字段的值\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"filed\">字段，如sum(je)</param>\r\n");
            sb.Append("            /// <param name=\"cond\">条件，如userid=2</param>\r\n");
            sb.Append("            /// <returns></returns>\r\n");
            sb.Append("            public string GetOneFiled(string filed, string cond)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                string sql = \"select \" + filed + \" from ["+tableName+"]\";\r\n");
            sb.Append("                if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    sql += \" where \" + cond;\r\n");
            sb.Append("                }\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(sql);\r\n");
            sb.Append("                return h.ExecuteScalar();\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 读取一个元组(实体对象)
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 得到一个对象实体\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public "+ns+".Model."+className+" GetModel(int id)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"select * from ["+tableName+"] \");\r\n");
            sb.Append("                strSql.Append(\" where id=@id \");\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("                h.AddParameter(\"@id\", id);\r\n");
            sb.Append("                "+ns+".Model."+className+" model = null;\r\n");
            sb.Append("                using (IDataReader dataReader = h.ExecuteReader())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    if (dataReader.Read())\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        model = ReaderBind(dataReader);\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                    h.CloseConn();\r\n");
            sb.Append("                }\r\n");
            sb.Append("                return model;\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 根据条件得到一个元组（对象实体）
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 根据条件得到一个对象实体\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public "+ns+".Model."+className+" GetModelByCond(string cond)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"select top 1 * from ["+tableName+"] \");\r\n");
            sb.Append("                if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    strSql.Append(\" where \" + cond);\r\n");
            sb.Append("                }\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("                "+ns+".Model."+className+" model = null;\r\n");
            sb.Append("                using (IDataReader dataReader = h.ExecuteReader())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    if (dataReader.Read())\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        model = ReaderBind(dataReader);\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                    h.CloseConn();\r\n");
            sb.Append("                }\r\n");
            sb.Append("                return model;\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 查询满足条件的所有数据
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 获得数据列表\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public DataSet GetList(string strWhere)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"select * \");\r\n");
            sb.Append("                strSql.Append(\" FROM ["+tableName+"] \");\r\n");
            sb.Append("                if (strWhere.Trim() != \"\")\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    strSql.Append(\" where \" + strWhere);\r\n");
            sb.Append("                }\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("                DataTable dt = h.ExecuteQuery();\r\n");
            sb.Append("                DataSet ds = new DataSet();\r\n");
            sb.Append("                ds.Tables.Add(dt);\r\n");
            sb.Append("                return ds;\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 分页查询
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 分页获取数据列表\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public DataSet GetList(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateStoredCommand(\"[proc_SplitPage]\");\r\n");
            sb.Append("                h.AddParameter(\"@tblName\", \"["+tableName+"]\");\r\n");
            sb.Append("                h.AddParameter(\"@strFields\", fileds);\r\n");
            sb.Append("                h.AddParameter(\"@strOrder\", order);\r\n");
            sb.Append("                h.AddParameter(\"@strOrderType\", ordertype);\r\n");
            sb.Append("                h.AddParameter(\"@PageSize\", PageSize);\r\n");
            sb.Append("                h.AddParameter(\"@PageIndex\", PageIndex);\r\n");
            sb.Append("                h.AddParameter(\"@strWhere\", strWhere);\r\n");
            sb.Append("                DataTable dt = h.ExecuteQuery();\r\n");
            sb.Append("                DataSet ds = new DataSet();\r\n");
            sb.Append("                ds.Tables.Add(dt);\r\n");
            sb.Append("                return ds;\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 查询列表数组（效率高）
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 获得数据列表（比DataSet效率高，推荐使用）\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public List<"+ns+".Model."+className+"> GetListArray(string strWhere)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                StringBuilder strSql = new StringBuilder();\r\n");
            sb.Append("                strSql.Append(\"select * \");\r\n");
            sb.Append("                strSql.Append(\" FROM ["+tableName+"] \");\r\n");
            sb.Append("                if (strWhere.Trim() != \"\")\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    strSql.Append(\" where \" + strWhere);\r\n");
            sb.Append("                }\r\n");
            sb.Append("                List<"+ns+".Model."+className+"> list = new List<"+ns+".Model."+className+">();\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(strSql.ToString());\r\n");
            sb.Append("                using (IDataReader dataReader = h.ExecuteReader())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    while (dataReader.Read())\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        list.Add(ReaderBind(dataReader));\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                    h.CloseConn();\r\n");
            sb.Append("                }\r\n");
            sb.Append("                return list;\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 分页查询（高效率）
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 分页获取数据列表\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public List<"+ns+".Model."+className+"> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateStoredCommand(\"[proc_SplitPage]\");\r\n");
            sb.Append("                h.AddParameter(\"@tblName\", \"["+tableName+"]\");\r\n");
            sb.Append("                h.AddParameter(\"@strFields\", fileds);\r\n");
            sb.Append("                h.AddParameter(\"@strOrder\", order);\r\n");
            sb.Append("                h.AddParameter(\"@strOrderType\", ordertype);\r\n");
            sb.Append("                h.AddParameter(\"@PageSize\", PageSize);\r\n");
            sb.Append("                h.AddParameter(\"@PageIndex\", PageIndex);\r\n");
            sb.Append("                h.AddParameter(\"@strWhere\", strWhere);\r\n");
            sb.Append("                List<"+ns+".Model."+className+"> list = new List<"+ns+".Model."+className+">();\r\n");
            sb.Append("                using (IDataReader dataReader = h.ExecuteReader())\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    while (dataReader.Read())\r\n");
            sb.Append("                    {\r\n");
            sb.Append("                        list.Add(ReaderBind(dataReader));\r\n");
            sb.Append("                    }\r\n");
            sb.Append("                    h.CloseConn();\r\n");
            sb.Append("                }\r\n");
            sb.Append("                return list;\r\n");
            sb.Append("            }\r\n");
            #endregion

            /*
             * 其他
             */
            #region 给实体对象绑定数据
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 对象实体绑定数据\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            public "+ns+".Model."+className+" ReaderBind(IDataReader dataReader)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                "+ns+".Model."+className+" model = new "+ns+".Model."+className+"();\r\n");
            sb.Append("                object ojb;\r\n");

            /*
             * 遍历读取每个属性进行绑定
             */
            foreach (DataRow row in dataTable.Rows)
            {
                //char 或者 text 类型不需要检查是否为空，直接转为字符串
                if (row["类型"].ToString().Contains("char") || row["类型"].ToString().Contains("text"))   
                {
                    sb.Append("                model."+row["字段名"]+ " = dataReader[\"" + row["字段名"] + "\"].ToString();\r\n");
                }
                else  //其他类型的数据需要检查是否为空对象
                {
                    sb.Append("                ojb = dataReader[\""+row["字段名"]+"\"];\r\n");
                    sb.Append("                if (ojb != null && ojb != DBNull.Value)\r\n");
                    sb.Append("                {\r\n");
                    sb.Append("                    model." + row["字段名"] + " = "+Tool.ConvertSqlTypeToNETType(row["类型"].ToString())+".Parse(ojb.ToString());\r\n");
                    sb.Append("                }\r\n");
                }
            }
            sb.Append("                return model;\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            #region 获取满足条件的元组个数
            sb.Append("            /// <summary>\r\n");
            sb.Append("            /// 获取满足条件的元组个数\r\n");
            sb.Append("            /// </summary>\r\n");
            sb.Append("            /// <param name=\"cond\"></param>\r\n");
            sb.Append("            /// <returns>返回获取满足条件的元组个数</returns>\r\n");
            sb.Append("            public int CalcCount(string cond)\r\n");
            sb.Append("            {\r\n");
            sb.Append("                string sql = \"select count(1) from ["+tableName+"]\";\r\n");
            sb.Append("                if (!string.IsNullOrEmpty(cond))\r\n");
            sb.Append("                {\r\n");
            sb.Append("                    sql += \" where \" + cond;\r\n");
            sb.Append("                }\r\n");
            sb.Append("                MSSQLHelper h = new MSSQLHelper();\r\n");
            sb.Append("                h.CreateCommand(sql);\r\n");
            sb.Append("                return int.Parse(h.ExecuteScalar());\r\n");
            sb.Append("            }\r\n\r\n");
            #endregion

            /*
             * 结尾
             */
            #region 结尾
            sb.Append("        }\r\n");
            sb.Append("    }\r\n\r\n");
            #endregion

            //关闭数据库
            sqlConnection.Close();
            return sb.ToString();
            #endregion
        }
    }
}