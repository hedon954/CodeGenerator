using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinClass;
using CodeGenerator.Generator;
using CodeGenerator.Template;
using FastColoredTextBoxNS;
using ICSharpCode.TextEditor.Document;


namespace CodeGenerator
{
   
    public partial class MainForm : Skin_Metro
    {
        // 定义两个变量，用来临时存储左右两边的表选择框
        List<string> listLeft = new List<string>();
        List<string> listRight = new List<string>();


        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 软件启动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            preview_textEditorControl.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            preview_textEditorControl.Encoding = System.Text.Encoding.Default;
            preview_textEditorControl.Encoding = Encoding.GetEncoding("GB2312");

            //获取之前选择的路径
            path_textBox.Text = Properties.Settings.Default.generateUrl;

            
        }

        /// <summary>
        /// 软件关闭时记录一些数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //存放生成路径
            Properties.Settings.Default.generateUrl = path_textBox.Text.Trim();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 软件启动时，设置焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            //启动的时候，重点提示要处理的数据库
            DB_name_textBox.Focus();
        }


        /// <summary>
        /// 点击“连接”按钮  =》 连接数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DB_connector_button_Click(object sender, EventArgs e)
        {
            //1. 清空表选择框里的所有表
            Left_listBox.Items.Clear();
            Right_listBox.Items.Clear();
            //同时将临时变量清空
            listLeft.Clear();
            listRight.Clear();
            SqlConnection sqlConnection = null;
            try
            {
                //2. 拼接生成数据库的连接字符串
                string connstr = getConnstr();
                //3. 连接数据库
                sqlConnection = new SqlConnection(connstr);
                sqlConnection.Open();     //打开数据库
                //3. 查询所有的表
                string sql = "SELECT name FROM sysobjects WHERE xtype = 'U' AND OBJECTPROPERTY (id, 'IsMSShipped') = 0 AND name !='sysdiagrams' order by name";     //定义 sql语句 =》 查询数据库中所有表名
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                //遍历结果，将其添加到左边的数据库表选择框对应的临时变量listLeft
                while (sqlDataReader.Read())
                {
                    listLeft.Add(sqlDataReader["name"].ToString());
                }

                //4. 将查询到的表填充到左边的表选择框中
                foreach (var item in listLeft.ToArray())
                {
                    Left_listBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();    //关闭数据库
            }
        }

        /// <summary>
        /// 获取数据库的连接字符串
        /// </summary>
        /// <returns></returns>
        private string getConnstr()
        {
            string address = Tool.GetSafeSQL(DB_address_textBox.Text.Trim());
            string username = Tool.GetSafeSQL(DB_username_textBox.Text.Trim());
            string password = Tool.GetSafeSQL(DB_password_textBox.Text.Trim());
            string database = Tool.GetSafeSQL(DB_name_textBox.Text.Trim());
            string connStr = "server="+ address + ";uid="+ username + ";pwd="+ password + ";database="+database+";Connect Timeout=10"+";";
            return connStr;
        }

        /// <summary>
        /// 一次性将左边所有表转移到右边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void all_to_right_button_Click(object sender, EventArgs e)
        {
            //遍历左边的选择表，在临时变量的层面上进行转移
            foreach (string item in Left_listBox.Items)
            {
                listRight.Add(item);    //右边+
                listLeft.Remove(item);  //左边-
            }

            //排序
            listLeft.Sort();
            listRight.Sort();

            //将临时变量里面的数据添加到表选择框中
            Right_listBox.Items.Clear();         //清空右表
            foreach (var item in listRight)
            {
                Right_listBox.Items.Add(item);   //逐个添加
            }
            Left_listBox.Items.Clear();         //清空左表
        }

        /// <summary>
        /// 一次性将右边所有表转移到左边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void all_to_left_button_Click(object sender, EventArgs e)
        {
            //遍历右边的选择表，在临时变量的层面上进行转移
            foreach (string item in Right_listBox.Items)
            {
                listLeft.Add(item);//左边+
                listRight.Remove(item);//右边-
            }

            //排序
            listLeft.Sort();
            listRight.Sort();

            //将临时变量里面的数据添加到表选择框中
            Left_listBox.Items.Clear();         //清空左表
            foreach (var item in listLeft)
            {
                Left_listBox.Items.Add(item);   //逐个添加
            }
            Right_listBox.Items.Clear();        //清空右表
            
        }

        /// <summary>
        /// 只将左边选中的选项移动到右边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void to_right_button_Click(object sender, EventArgs e)
        {
            leftToRight();
        }


        /// <summary>
        /// 只将右边选中的选项移动到左边
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void to_left_button_Click(object sender, EventArgs e)
        {
            rightToLeft();
        }

        private void leftToRight()
        {
            //遍历转移
            foreach (string item in Left_listBox.SelectedItems)
            {
                listRight.Add(item);   //右边+
                listLeft.Remove(item); //左边-
            }

            //排序
            listRight.Sort();
            listLeft.Sort();

            //显示左边的选择框
            Left_listBox.Items.Clear();
            foreach (var item in listLeft)
            {
                Left_listBox.Items.Add(item);
            }

            //显示右边的选择框
            Right_listBox.Items.Clear();
            foreach (var item in listRight)
            {
                Right_listBox.Items.Add(item);
            }
        }


        private void rightToLeft()
        {
            //遍历转移
            foreach (string item in Right_listBox.SelectedItems)
            {
                listLeft.Add(item);   //左边+
                listRight.Remove(item); //右边-
            }

            //排序
            listRight.Sort();
            listLeft.Sort();

            //显示左边的选择框
            Left_listBox.Items.Clear();
            foreach (var item in listLeft)
            {
                Left_listBox.Items.Add(item);
            }

            //显示右边的选择框
            Right_listBox.Items.Clear();
            foreach (var item in listRight)
            {
                Right_listBox.Items.Add(item);
            }
        }

        /// <summary>
        /// 双击转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Left_listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            leftToRight();
        }

        /// <summary>
        /// 双击转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Right_listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            rightToLeft();
        }

        /// <summary>
        /// 点击预览按钮  =》 设置输出路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browser_button_Click(object sender, EventArgs e)
        {
            string pathStr = selectPath();
            path_textBox.Text = pathStr;
        }


        private string selectPath()
        {
            //定义一个空路径
            string path = string.Empty;
            //实例化一个文件浏览器对话框
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            //选择路径
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }

            return path;
        }

        /// <summary>
        /// 预览即将要生成的 Model 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_model_button_Click(object sender, EventArgs e)
        {
            //1. 判断右边是否有表
            if (Right_listBox.Items.Count <= 0)
            {
                MessageBox.Show("请选择要生成的表！");
                return;
            }

            //2. 预览
            if (Right_listBox.SelectedItems.Count <= 0)
            {
                //如果没有选中的，则默认预览第一个
                showModelPreview(Right_listBox.Items[0].ToString());
            }
            else
            {
                //如果有多个选中的，则默认预览选中中的第一个
                showModelPreview(Right_listBox.SelectedItems[0].ToString());
            }
        }

        
        /// <summary>
        /// 预览 Model
        /// </summary>
        /// <param name="tableName"></param>
        private void showModelPreview(string tableName)
        {
            
            //2. 获取表名
            //tableName = Right_listBox.Items[0].ToString();

            //3. 获取“其他项”里面的信息

            //3.1 获取命名空间
            string ns = namespace_textBox.Text.Trim();  //命名空间
            //3.1.1 判断“命名空间是否不为空”
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间！");
                return;
            }

            //3.2 获取表前缀
            string tablePrefix = table_prefix_textBox.Text.Trim();
            //3.2.1 去掉前缀
            string className = tableName.Replace(tablePrefix, "");
            //3.2.2 将类名第一个字母进行大写
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);

            //3.3 获取作者信息
            string author = author_textBox.Text.Trim();
            //4. 获取连接字符串
            string connStr = getConnstr();
            //5. 获取 Model 模板代码
            preview_textEditorControl.Text = ModelTemplate.GetModelTemplate(ns, tableName, author, className, connStr);
        }

        /// <summary>
        /// 点击“预览 DAL”按钮 =》 预览 DAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_dal_button_Click(object sender, EventArgs e)
        {
            //1. 判断右边选择框中有没有表
            if(Right_listBox.Items.Count <= 0)
            {
                MessageBox.Show("请选择要生成的表！");
                return;
            }
            //2. 预览
            if (Right_listBox.SelectedItems.Count <= 0)
            {
                //如果没有选中的，则默认预览第一个
                showDALPreview(Right_listBox.Items[0].ToString());
            }
            else
            {
                //如果有多个选中的，则默认预览选中中的第一个
                showDALPreview(Right_listBox.SelectedItems[0].ToString());
            }
        }

        /// <summary>
        /// 预览DAL
        /// </summary>
        private void showDALPreview(string tableName)
        {
            //2. 获取表名
            //tableName = Right_listBox.Items[0].ToString();

            //3. 获取“其他项”里面的信息

            //3.1 获取命名空间
            string ns = namespace_textBox.Text.Trim();  //命名空间
            //3.1.1 判断“命名空间是否不为空”
            if (string.IsNullOrEmpty(ns))
            {
                MessageBox.Show("请输入命名空间！");
                return;
            }

            //3.2 获取表前缀
            string tablePrefix = table_prefix_textBox.Text.Trim();
            //3.2.1 去掉前缀
            string className = tableName.Replace(tablePrefix, "");
            //3.2.2 将类名第一个字母进行大写
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);

            //3.3 获取作者信息
            string author = author_textBox.Text.Trim();
            //4. 获取连接字符串
            string connStr = getConnstr();
            //5. 获取 Model 模板代码
            preview_textEditorControl.Text =DALTemplate.GetDALTemplate(ns, tableName, author, className, connStr);
        }

        /// <summary>
        /// 点击“批量生成按钮” =》 批量生成 Model、DAL、数据库结构表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generate_button_Click(object sender, EventArgs e)
        {
            //1. 判断是否选择了表
            if(Right_listBox.Items.Count <= 0)
            {
                MessageBox.Show("请选择要生成的表！");
                return;
            }

            //2. 判断要生成的路径是否为空
            string outputPath = path_textBox.Text.Trim();
            if (outputPath.ToString() == "")
            {
                //如果是空值，则给一个默认路径
                outputPath = "\\\\Mac\\Home\\Desktop";
                path_textBox.Text = outputPath;

            }

            //3. 判断要生成的路径是否存在
            if (!Directory.Exists(outputPath)){
                try
                {
                    //如果路径不存在，则自动生成路径
                    Directory.CreateDirectory(outputPath);
                }
                catch(Exception)
                {
                    //出错
                    MessageBox.Show("路径不存在！请选择正确的生成目录！");
                    return;
                }
            }

            //4. 判断命名空间是否为空
            if(namespace_textBox.Text.Trim().ToString() == "")
            {
                MessageBox.Show("请输入命名空间！");
                return;
            }

            //5. 获取基本信息
            string connStr = getConnstr();
            string tablePrefix = table_prefix_textBox.Text.Trim();
            string author = author_textBox.Text.Trim();
            string ns = namespace_textBox.Text.Trim();
            string dbName = DB_name_textBox.Text.Trim();

            //6. 生成 Model
            ModelGenerator.GenerateModel(ns,author,outputPath,tablePrefix,connStr,Right_listBox.Items);
            //7. 生成 DAL
            DalGenerator.GenerateDAL(ns, author, outputPath, tablePrefix, connStr,Right_listBox.Items);
            //8. 生成数据库操作助手类
            MSSQLHelperGenerator.GenerateMSSQLHelper(ns, outputPath, connStr);
            //9. 生成 数据库文档
            SqlFileGenerator.GenerateSqlFile(outputPath, connStr, listRight, dbName);


            //10. 告知生成成功
            string successMsg = "恭喜你！生成成功！";
            MessageBox.Show(successMsg);

            //11. 打开生成后的目录
            System.Diagnostics.Process.Start(outputPath);
        }
    }
}
