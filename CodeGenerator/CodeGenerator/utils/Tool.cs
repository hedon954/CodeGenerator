using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// 工具类
/// </summary>
namespace CodeGenerator
{
    public class Tool
    {
        /// <summary>
        /// 过滤 sql 语句中的非法字符
        /// </summary>
        /// <param name="value"></param>
        public static string GetSafeSQL(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            value = Regex.Replace(value, @";", string.Empty);
            value = Regex.Replace(value, @"'", string.Empty);
            value = Regex.Replace(value, @"&", string.Empty);
            value = Regex.Replace(value, @"%20", string.Empty);
            value = Regex.Replace(value, @"--", string.Empty);
            value = Regex.Replace(value, @"==", string.Empty);
            value = Regex.Replace(value, @"<", string.Empty);
            value = Regex.Replace(value, @">", string.Empty);
            value = Regex.Replace(value, @"%", string.Empty);
            return value;
        }


        /// <summary>
        /// 将数据库中的类型转换为.NET数据类型
        /// </summary>
        /// <param name="sqlTypeString"></param>
        /// <returns></returns>
        public static string ConvertSqlTypeToNETType(string sqlTypeString)
        {
            string[] SqlTypeNames = new string[] { "int", "varchar","bit" ,"datetime","decimal","float","image","money",
"ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
"real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary"};

            string[] DotNetTypes = new string[] {"int", "string","bool" ,"DateTime?","Decimal","Double","Byte[]","Single",
"string","string","DateTime","Int16","string","Int64","Byte[]","string","string","Decimal",
"Single","Single", "Object","Byte[]","Byte","Guid","Byte[]"};

            int i = Array.IndexOf(SqlTypeNames, sqlTypeString.ToLower());

            return DotNetTypes[i];

        }


        /// <summary>
        /// 获取数据库字段的默认值
        /// </summary>
        /// <returns></returns>
        public static string getDbFieldDefaultValue(string v)
        {
            string str = "";
            //取时间
            if (v.Contains("getdate()"))
            {
                str = " = DateTime.Now";
            }
            //取数字
            str = getRegexResult(@"\(\((\d+)\)\)", v, "num");
            //取字符串
            if (str == "")
            {
                str = getRegexResult(@"\(N?'(.+)'\)", v, "string");
            }
            return str;
        }

        /// <summary>
        /// 根据正则表达式获取结果
        /// </summary>
        /// <param name="pat">正则表达式</param>
        /// <param name="v">要匹配的内容</param>
        /// <param name="type">要匹配的类型 | num 数字 | string 字符串）</param>
        /// <returns></returns>
        private static string getRegexResult(string pat, string v, string type)
        {
            string str = "";
            //创建正则表达式对象
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            //进行匹配
            Match m = r.Match(v);
            int matchCount = 0;
            //检查匹配结果
            if (m.Success)
            {
                ++matchCount;
                Group g = m.Groups[1];
                //检查数据类型
                if (type == "num")
                {
                    str = " = " + g.Value;
                }
                else if (type == "string")
                {
                    str = " = \"" + g.Value + "\"";
                }
            }
            //返回结果
            return str;
        }
    }
}