using CodeGenerator.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Generator
{
    public class MSSQLHelperGenerator
    {
        #region 生成数据库操作助手类
        /// <summary>
        /// 生成数据库操作助手类
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="author"></param>
        /// <param name="outputPath"></param>
        /// <param name="tablePrefix"></param>
        /// <param name="connStr"></param>
        public static void GenerateMSSQLHelper(string ns, string outputPath, string connStr)
        {
            string helperOutputPath = "";

            //检查生成路径的末尾是否为“\”
            if (outputPath.LastIndexOf("\\") == 0)
            {
                //如果路径最后是“\”，则在该路径下的 DAL 文件夹下建立 MSSQLHelper 文件
                helperOutputPath = outputPath + "DAL\\";
            }
            else
            {
                //如果路径不是以“\”结尾，则需要补上
                helperOutputPath = outputPath + "\\DAL\\";
            }

            //检查 DAL 文件夹是否存在
            if (!Directory.Exists(helperOutputPath))
            {
                //不存在则创建
                Directory.CreateDirectory(helperOutputPath);
            }


            //定义文件路径
            string filePath = helperOutputPath + "MSSQLHelper.cs";
            //声明文档流对象，采取覆盖模式
            StreamWriter sw = new StreamWriter(filePath, false);
            //生成文档
            sw.Write(MSSQLHelperTemplate.GETMSSQLHelperTemplate(ns, connStr));
            //关闭文档流
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        #endregion
    }
}
