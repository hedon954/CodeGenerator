using CodeGenerator.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.Generator
{
    public class DalGenerator
    {
        #region 生成 DAL 文件
        /// <summary>
        /// 生成 DAL 文件
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="author"></param>
        /// <param name="outputPath"></param>
        /// <param name="tablePrefix"></param>
        /// <param name="connStr"></param>
        public static void GenerateDAL(string ns, string author, string outputPath, string tablePrefix, string connStr,ListBox.ObjectCollection items)
        {
            string dalOutputPath = "";

            //检查生成路径的末尾是否为“\”
            if (outputPath.LastIndexOf("\\") == 0)
            {
                //如果路径最后是“\”，则在该路径下的 DAL 文件夹下建立 DAL 文件
                dalOutputPath = outputPath + "DAL\\";
            }
            else
            {
                //如果路径不是以“\”结尾，则需要补上
                dalOutputPath = outputPath + "\\DAL\\";
            }

            //检查 DAL 文件夹是否存在
            if (!Directory.Exists(dalOutputPath))
            {
                //不存在则创建
                Directory.CreateDirectory(dalOutputPath);
            }

            string className = "";
            //遍历要生成的表，生成 DAL
            foreach (string tableName in items)
            {
                //去掉表名的前缀
                className = tableName.Replace(tablePrefix, "");
                //将类名的一个字母大写
                className = className.Substring(0, 1).ToUpper() + className.Substring(1);
                //定义文件路径
                string filePath = dalOutputPath + className + ".cs";
                //声明文档流对象，采取覆盖模式
                StreamWriter sw = new StreamWriter(filePath, false);
                //生成文档
                sw.Write(DALTemplate.GetDALTemplate(ns, tableName, author, className, connStr));
                //关闭文档流
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }
        #endregion
    }
}
