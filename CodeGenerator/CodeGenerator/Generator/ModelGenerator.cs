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
    public class ModelGenerator
    {
        #region 生成 Model 文件
        /// <summary>
        /// 生成 Model文件
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="author"></param>
        /// <param name="outputPath"></param>
        /// <param name="tablePrefix"></param>
        /// <param name="connStr"></param>
        public static void GenerateModel(string ns, string author, string outputPath, string tablePrefix, string connStr,ListBox.ObjectCollection items)
        {
            string modelOutputPath = "";

            if (outputPath.LastIndexOf("\\") == 0)
            {
                //如果生成路径的最后一位是“\”，是在该路径下的 Model 文件夹下面建立 Model 文件
                modelOutputPath = outputPath + "Model\\";
            }
            else //没有反斜杠，则要补上
            {
                modelOutputPath = outputPath + "\\Model\\";
            }

            //检查 Model 文件夹是否存在，不存在则创建
            if (!Directory.Exists(modelOutputPath))
            {
                Directory.CreateDirectory(modelOutputPath);
            }

            string className = "";
            //遍历要生成的表，生成 Model 
            foreach (string tableName in items)
            {
                //去掉表名前缀
                className = tableName.Replace(tablePrefix, "");
                //将类名第一个字母大写
                className = className.Substring(0, 1).ToUpper() + className.Substring(1);
                //定义文件路径
                string filePath = modelOutputPath + className + ".cs";
                //声明文档流对象，采取覆盖模式
                StreamWriter sw = new StreamWriter(filePath, false);
                //生成文档
                sw.Write(ModelTemplate.GetModelTemplate(ns, tableName, author, className, connStr));
                //关闭文档流
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }

        }
        #endregion
    }
}
