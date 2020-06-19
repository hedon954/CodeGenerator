using CodeGenerator.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Generator
{
    public class SqlFileGenerator
    {
        #region 生成数据表结构文档
        public static void GenerateSqlFile(string outputPath, string connStr, List<string> selectedItems, string dbName)
        {
            string sqlFileOutputPath = "";
            //检查生成路径的末尾是否为“\”
            if (outputPath.LastIndexOf("\\") > 0)
            {
                //如果不是以“\”结尾，则要补上
                sqlFileOutputPath = outputPath + "\\";
            }
            //如果是以“\”结尾，则直接在改路径下生成数据库表文档
            string filePath = sqlFileOutputPath + dbName + "数据库表结构文档.html";
            //声明文档流对象，采取覆盖模式
            StreamWriter sw = new StreamWriter(filePath, false);
            //生成文档
            sw.Write(SqlFileTemplate.GetSqlFileTemplate(connStr, selectedItems));
            //关闭文档流
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        #endregion
    }
}
