﻿namespace CodeGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelRight = new System.Windows.Forms.Panel();
            this.preview_textEditorControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.view_model_button = new System.Windows.Forms.Button();
            this.view_dal_button = new System.Windows.Forms.Button();
            this.generate_button = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.preview_groupBox = new System.Windows.Forms.GroupBox();
            this.copyright_label = new System.Windows.Forms.Label();
            this.others_groupBox = new System.Windows.Forms.GroupBox();
            this.browser_button = new System.Windows.Forms.Button();
            this.path_textBox = new System.Windows.Forms.TextBox();
            this.path_label = new System.Windows.Forms.Label();
            this.namespace_textBox = new System.Windows.Forms.TextBox();
            this.namespace_label = new System.Windows.Forms.Label();
            this.table_prefix_textBox = new System.Windows.Forms.TextBox();
            this.table_prefix_label = new System.Windows.Forms.Label();
            this.author_textBox = new System.Windows.Forms.TextBox();
            this.author_label = new System.Windows.Forms.Label();
            this.DB_operator_groupBox = new System.Windows.Forms.GroupBox();
            this.all_to_left_button = new System.Windows.Forms.Button();
            this.to_left_button = new System.Windows.Forms.Button();
            this.to_right_button = new System.Windows.Forms.Button();
            this.all_to_right_button = new System.Windows.Forms.Button();
            this.Right_listBox = new System.Windows.Forms.ListBox();
            this.Left_listBox = new System.Windows.Forms.ListBox();
            this.DB_connector_button = new System.Windows.Forms.Button();
            this.DB_name_textBox = new System.Windows.Forms.TextBox();
            this.DB_name_label = new System.Windows.Forms.Label();
            this.DB_password_textBox = new System.Windows.Forms.TextBox();
            this.DB_password_label = new System.Windows.Forms.Label();
            this.DB_username_textBox = new System.Windows.Forms.TextBox();
            this.DB_username_label = new System.Windows.Forms.Label();
            this.DB_address_textBox = new System.Windows.Forms.TextBox();
            this.DB_address_label = new System.Windows.Forms.Label();
            this.DB_type_textBox = new System.Windows.Forms.TextBox();
            this.DB_type_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxDataBase = new System.Windows.Forms.GroupBox();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.preview_groupBox.SuspendLayout();
            this.others_groupBox.SuspendLayout();
            this.DB_operator_groupBox.SuspendLayout();
            this.groupBoxDataBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.preview_textEditorControl);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelRight.Location = new System.Drawing.Point(342, 30);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(526, 668);
            this.panelRight.TabIndex = 1;
            // 
            // preview_textEditorControl
            // 
            this.preview_textEditorControl.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.preview_textEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preview_textEditorControl.AutoScroll = true;
            this.preview_textEditorControl.BackColor = System.Drawing.Color.DimGray;
            this.preview_textEditorControl.CreateBackupCopy = true;
            this.preview_textEditorControl.Encoding = ((System.Text.Encoding)(resources.GetObject("preview_textEditorControl.Encoding")));
            this.preview_textEditorControl.IsIconBarVisible = false;
            this.preview_textEditorControl.Location = new System.Drawing.Point(3, 3);
            this.preview_textEditorControl.Name = "preview_textEditorControl";
            this.preview_textEditorControl.ShowEOLMarkers = true;
            this.preview_textEditorControl.ShowSpaces = true;
            this.preview_textEditorControl.ShowTabs = true;
            this.preview_textEditorControl.ShowVRuler = true;
            this.preview_textEditorControl.Size = new System.Drawing.Size(520, 662);
            this.preview_textEditorControl.TabIndex = 0;
            // 
            // view_model_button
            // 
            this.view_model_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.view_model_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.view_model_button.FlatAppearance.BorderSize = 0;
            this.view_model_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_model_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.view_model_button.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.view_model_button.Location = new System.Drawing.Point(13, 24);
            this.view_model_button.Margin = new System.Windows.Forms.Padding(13);
            this.view_model_button.Name = "view_model_button";
            this.view_model_button.Size = new System.Drawing.Size(132, 23);
            this.view_model_button.TabIndex = 4;
            this.view_model_button.Text = "预览 Model";
            this.view_model_button.UseVisualStyleBackColor = false;
            this.view_model_button.Click += new System.EventHandler(this.view_model_button_Click);
            // 
            // view_dal_button
            // 
            this.view_dal_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.view_dal_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.view_dal_button.FlatAppearance.BorderSize = 0;
            this.view_dal_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_dal_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.view_dal_button.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.view_dal_button.Location = new System.Drawing.Point(164, 24);
            this.view_dal_button.Margin = new System.Windows.Forms.Padding(0, 13, 3, 3);
            this.view_dal_button.Name = "view_dal_button";
            this.view_dal_button.Size = new System.Drawing.Size(132, 23);
            this.view_dal_button.TabIndex = 5;
            this.view_dal_button.Text = "预览 DAL";
            this.view_dal_button.UseVisualStyleBackColor = false;
            this.view_dal_button.Click += new System.EventHandler(this.view_dal_button_Click);
            // 
            // generate_button
            // 
            this.generate_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.generate_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generate_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.generate_button.Location = new System.Drawing.Point(13, 23);
            this.generate_button.Margin = new System.Windows.Forms.Padding(60, 13, 13, 13);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(283, 23);
            this.generate_button.TabIndex = 6;
            this.generate_button.Text = "批量生成";
            this.generate_button.UseVisualStyleBackColor = false;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Controls.Add(this.preview_groupBox);
            this.panelLeft.Controls.Add(this.copyright_label);
            this.panelLeft.Controls.Add(this.others_groupBox);
            this.panelLeft.Controls.Add(this.DB_operator_groupBox);
            this.panelLeft.Controls.Add(this.groupBoxDataBase);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelLeft.Location = new System.Drawing.Point(8, 30);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(334, 668);
            this.panelLeft.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.generate_button);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 574);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成";
            // 
            // preview_groupBox
            // 
            this.preview_groupBox.Controls.Add(this.view_model_button);
            this.preview_groupBox.Controls.Add(this.view_dal_button);
            this.preview_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.preview_groupBox.Location = new System.Drawing.Point(12, 506);
            this.preview_groupBox.Name = "preview_groupBox";
            this.preview_groupBox.Size = new System.Drawing.Size(306, 58);
            this.preview_groupBox.TabIndex = 4;
            this.preview_groupBox.TabStop = false;
            this.preview_groupBox.Text = "预览";
            // 
            // copyright_label
            // 
            this.copyright_label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.copyright_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.copyright_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.copyright_label.Location = new System.Drawing.Point(0, 647);
            this.copyright_label.Name = "copyright_label";
            this.copyright_label.Size = new System.Drawing.Size(334, 21);
            this.copyright_label.TabIndex = 3;
            this.copyright_label.Text = "Copyright © 2020     Hedon.   All Rights Reserved";
            this.copyright_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // others_groupBox
            // 
            this.others_groupBox.Controls.Add(this.browser_button);
            this.others_groupBox.Controls.Add(this.path_textBox);
            this.others_groupBox.Controls.Add(this.path_label);
            this.others_groupBox.Controls.Add(this.namespace_textBox);
            this.others_groupBox.Controls.Add(this.namespace_label);
            this.others_groupBox.Controls.Add(this.table_prefix_textBox);
            this.others_groupBox.Controls.Add(this.table_prefix_label);
            this.others_groupBox.Controls.Add(this.author_textBox);
            this.others_groupBox.Controls.Add(this.author_label);
            this.others_groupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.others_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.others_groupBox.Location = new System.Drawing.Point(12, 373);
            this.others_groupBox.Name = "others_groupBox";
            this.others_groupBox.Size = new System.Drawing.Size(306, 124);
            this.others_groupBox.TabIndex = 2;
            this.others_groupBox.TabStop = false;
            this.others_groupBox.Text = "其他项";
            // 
            // browser_button
            // 
            this.browser_button.BackColor = System.Drawing.Color.Transparent;
            this.browser_button.BackgroundImage = global::CodeGenerator.Properties.Resources.compare;
            this.browser_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.browser_button.FlatAppearance.BorderSize = 0;
            this.browser_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browser_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.browser_button.Location = new System.Drawing.Point(251, 80);
            this.browser_button.Name = "browser_button";
            this.browser_button.Size = new System.Drawing.Size(45, 33);
            this.browser_button.TabIndex = 10;
            this.browser_button.UseVisualStyleBackColor = false;
            this.browser_button.Click += new System.EventHandler(this.browser_button_Click);
            // 
            // path_textBox
            // 
            this.path_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.path_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.path_textBox.ForeColor = System.Drawing.Color.White;
            this.path_textBox.Location = new System.Drawing.Point(68, 85);
            this.path_textBox.Name = "path_textBox";
            this.path_textBox.Size = new System.Drawing.Size(177, 23);
            this.path_textBox.TabIndex = 9;
            this.path_textBox.Text = "\\\\Mac\\Home\\Desktop";
            // 
            // path_label
            // 
            this.path_label.AutoSize = true;
            this.path_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.path_label.Location = new System.Drawing.Point(10, 88);
            this.path_label.Name = "path_label";
            this.path_label.Size = new System.Drawing.Size(56, 17);
            this.path_label.TabIndex = 8;
            this.path_label.Text = "生成路径";
            this.path_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namespace_textBox
            // 
            this.namespace_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.namespace_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.namespace_textBox.ForeColor = System.Drawing.Color.White;
            this.namespace_textBox.Location = new System.Drawing.Point(68, 55);
            this.namespace_textBox.Name = "namespace_textBox";
            this.namespace_textBox.Size = new System.Drawing.Size(228, 23);
            this.namespace_textBox.TabIndex = 7;
            this.namespace_textBox.Text = "WebApplication";
            // 
            // namespace_label
            // 
            this.namespace_label.AutoSize = true;
            this.namespace_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.namespace_label.Location = new System.Drawing.Point(10, 59);
            this.namespace_label.Name = "namespace_label";
            this.namespace_label.Size = new System.Drawing.Size(56, 17);
            this.namespace_label.TabIndex = 6;
            this.namespace_label.Text = "命名空间";
            this.namespace_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // table_prefix_textBox
            // 
            this.table_prefix_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.table_prefix_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.table_prefix_textBox.ForeColor = System.Drawing.Color.White;
            this.table_prefix_textBox.Location = new System.Drawing.Point(234, 23);
            this.table_prefix_textBox.Name = "table_prefix_textBox";
            this.table_prefix_textBox.Size = new System.Drawing.Size(62, 23);
            this.table_prefix_textBox.TabIndex = 5;
            this.table_prefix_textBox.Text = "tb_";
            // 
            // table_prefix_label
            // 
            this.table_prefix_label.AutoSize = true;
            this.table_prefix_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.table_prefix_label.Location = new System.Drawing.Point(190, 27);
            this.table_prefix_label.Name = "table_prefix_label";
            this.table_prefix_label.Size = new System.Drawing.Size(44, 17);
            this.table_prefix_label.TabIndex = 4;
            this.table_prefix_label.Text = "表前缀";
            this.table_prefix_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // author_textBox
            // 
            this.author_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.author_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.author_textBox.ForeColor = System.Drawing.Color.White;
            this.author_textBox.Location = new System.Drawing.Point(68, 23);
            this.author_textBox.Name = "author_textBox";
            this.author_textBox.Size = new System.Drawing.Size(110, 23);
            this.author_textBox.TabIndex = 3;
            this.author_textBox.Text = "Hedon";
            // 
            // author_label
            // 
            this.author_label.AutoSize = true;
            this.author_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.author_label.Location = new System.Drawing.Point(10, 27);
            this.author_label.Name = "author_label";
            this.author_label.Size = new System.Drawing.Size(56, 17);
            this.author_label.TabIndex = 2;
            this.author_label.Text = "创建作者";
            this.author_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DB_operator_groupBox
            // 
            this.DB_operator_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DB_operator_groupBox.Controls.Add(this.all_to_left_button);
            this.DB_operator_groupBox.Controls.Add(this.to_left_button);
            this.DB_operator_groupBox.Controls.Add(this.to_right_button);
            this.DB_operator_groupBox.Controls.Add(this.all_to_right_button);
            this.DB_operator_groupBox.Controls.Add(this.Right_listBox);
            this.DB_operator_groupBox.Controls.Add(this.Left_listBox);
            this.DB_operator_groupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_operator_groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.DB_operator_groupBox.Location = new System.Drawing.Point(12, 165);
            this.DB_operator_groupBox.Name = "DB_operator_groupBox";
            this.DB_operator_groupBox.Size = new System.Drawing.Size(306, 193);
            this.DB_operator_groupBox.TabIndex = 1;
            this.DB_operator_groupBox.TabStop = false;
            this.DB_operator_groupBox.Text = "表操作";
            // 
            // all_to_left_button
            // 
            this.all_to_left_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.all_to_left_button.FlatAppearance.BorderSize = 0;
            this.all_to_left_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.all_to_left_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.all_to_left_button.Location = new System.Drawing.Point(129, 139);
            this.all_to_left_button.Name = "all_to_left_button";
            this.all_to_left_button.Size = new System.Drawing.Size(49, 29);
            this.all_to_left_button.TabIndex = 5;
            this.all_to_left_button.Text = "<<";
            this.all_to_left_button.UseVisualStyleBackColor = false;
            this.all_to_left_button.Click += new System.EventHandler(this.all_to_left_button_Click);
            // 
            // to_left_button
            // 
            this.to_left_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.to_left_button.FlatAppearance.BorderSize = 0;
            this.to_left_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.to_left_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.to_left_button.Location = new System.Drawing.Point(129, 102);
            this.to_left_button.Name = "to_left_button";
            this.to_left_button.Size = new System.Drawing.Size(49, 29);
            this.to_left_button.TabIndex = 4;
            this.to_left_button.Text = "<";
            this.to_left_button.UseVisualStyleBackColor = false;
            this.to_left_button.Click += new System.EventHandler(this.to_left_button_Click);
            // 
            // to_right_button
            // 
            this.to_right_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.to_right_button.FlatAppearance.BorderSize = 0;
            this.to_right_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.to_right_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.to_right_button.Location = new System.Drawing.Point(129, 65);
            this.to_right_button.Name = "to_right_button";
            this.to_right_button.Size = new System.Drawing.Size(49, 29);
            this.to_right_button.TabIndex = 3;
            this.to_right_button.Text = ">";
            this.to_right_button.UseVisualStyleBackColor = false;
            this.to_right_button.Click += new System.EventHandler(this.to_right_button_Click);
            // 
            // all_to_right_button
            // 
            this.all_to_right_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.all_to_right_button.FlatAppearance.BorderSize = 0;
            this.all_to_right_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.all_to_right_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.all_to_right_button.Location = new System.Drawing.Point(129, 29);
            this.all_to_right_button.Name = "all_to_right_button";
            this.all_to_right_button.Size = new System.Drawing.Size(49, 29);
            this.all_to_right_button.TabIndex = 2;
            this.all_to_right_button.Text = ">>";
            this.all_to_right_button.UseVisualStyleBackColor = false;
            this.all_to_right_button.Click += new System.EventHandler(this.all_to_right_button_Click);
            // 
            // Right_listBox
            // 
            this.Right_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.Right_listBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Right_listBox.ForeColor = System.Drawing.Color.White;
            this.Right_listBox.FormattingEnabled = true;
            this.Right_listBox.ItemHeight = 17;
            this.Right_listBox.Location = new System.Drawing.Point(185, 19);
            this.Right_listBox.Name = "Right_listBox";
            this.Right_listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Right_listBox.Size = new System.Drawing.Size(111, 157);
            this.Right_listBox.TabIndex = 1;
            this.Right_listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Right_listBox_MouseDoubleClick);
            // 
            // Left_listBox
            // 
            this.Left_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.Left_listBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Left_listBox.ForeColor = System.Drawing.Color.White;
            this.Left_listBox.FormattingEnabled = true;
            this.Left_listBox.ItemHeight = 17;
            this.Left_listBox.Location = new System.Drawing.Point(12, 20);
            this.Left_listBox.Name = "Left_listBox";
            this.Left_listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.Left_listBox.Size = new System.Drawing.Size(111, 157);
            this.Left_listBox.TabIndex = 0;
            this.Left_listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Left_listBox_MouseDoubleClick);
            // 
            // DB_connector_button
            // 
            this.DB_connector_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.DB_connector_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DB_connector_button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(41)))), ((int)(((byte)(91)))));
            this.DB_connector_button.FlatAppearance.BorderSize = 0;
            this.DB_connector_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DB_connector_button.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_connector_button.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.DB_connector_button.Location = new System.Drawing.Point(164, 98);
            this.DB_connector_button.Margin = new System.Windows.Forms.Padding(0);
            this.DB_connector_button.Name = "DB_connector_button";
            this.DB_connector_button.Size = new System.Drawing.Size(132, 23);
            this.DB_connector_button.TabIndex = 11;
            this.DB_connector_button.Text = "连接数据库";
            this.DB_connector_button.UseVisualStyleBackColor = false;
            this.DB_connector_button.Click += new System.EventHandler(this.DB_connector_button_Click);
            // 
            // DB_name_textBox
            // 
            this.DB_name_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.DB_name_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_name_textBox.ForeColor = System.Drawing.Color.White;
            this.DB_name_textBox.Location = new System.Drawing.Point(54, 98);
            this.DB_name_textBox.Name = "DB_name_textBox";
            this.DB_name_textBox.Size = new System.Drawing.Size(100, 23);
            this.DB_name_textBox.TabIndex = 9;
            this.DB_name_textBox.Text = "db_test";
            // 
            // DB_name_label
            // 
            this.DB_name_label.AutoSize = true;
            this.DB_name_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_name_label.Location = new System.Drawing.Point(10, 101);
            this.DB_name_label.Name = "DB_name_label";
            this.DB_name_label.Size = new System.Drawing.Size(44, 17);
            this.DB_name_label.TabIndex = 8;
            this.DB_name_label.Text = "数据库";
            this.DB_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DB_password_textBox
            // 
            this.DB_password_textBox.AccessibleDescription = "";
            this.DB_password_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.DB_password_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_password_textBox.ForeColor = System.Drawing.Color.White;
            this.DB_password_textBox.Location = new System.Drawing.Point(196, 65);
            this.DB_password_textBox.Name = "DB_password_textBox";
            this.DB_password_textBox.PasswordChar = '*';
            this.DB_password_textBox.Size = new System.Drawing.Size(100, 23);
            this.DB_password_textBox.TabIndex = 7;
            this.DB_password_textBox.Text = "sa";
            // 
            // DB_password_label
            // 
            this.DB_password_label.AutoSize = true;
            this.DB_password_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_password_label.Location = new System.Drawing.Point(161, 69);
            this.DB_password_label.Name = "DB_password_label";
            this.DB_password_label.Size = new System.Drawing.Size(32, 17);
            this.DB_password_label.TabIndex = 6;
            this.DB_password_label.Text = "密码";
            // 
            // DB_username_textBox
            // 
            this.DB_username_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.DB_username_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_username_textBox.ForeColor = System.Drawing.Color.White;
            this.DB_username_textBox.Location = new System.Drawing.Point(54, 65);
            this.DB_username_textBox.Name = "DB_username_textBox";
            this.DB_username_textBox.Size = new System.Drawing.Size(100, 23);
            this.DB_username_textBox.TabIndex = 5;
            this.DB_username_textBox.Text = "sa";
            // 
            // DB_username_label
            // 
            this.DB_username_label.AutoSize = true;
            this.DB_username_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_username_label.Location = new System.Drawing.Point(10, 69);
            this.DB_username_label.Name = "DB_username_label";
            this.DB_username_label.Size = new System.Drawing.Size(44, 17);
            this.DB_username_label.TabIndex = 4;
            this.DB_username_label.Text = "登录名";
            this.DB_username_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DB_address_textBox
            // 
            this.DB_address_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.DB_address_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_address_textBox.ForeColor = System.Drawing.Color.White;
            this.DB_address_textBox.Location = new System.Drawing.Point(196, 29);
            this.DB_address_textBox.Name = "DB_address_textBox";
            this.DB_address_textBox.Size = new System.Drawing.Size(100, 23);
            this.DB_address_textBox.TabIndex = 3;
            this.DB_address_textBox.Text = ".";
            // 
            // DB_address_label
            // 
            this.DB_address_label.AutoSize = true;
            this.DB_address_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_address_label.Location = new System.Drawing.Point(161, 33);
            this.DB_address_label.Name = "DB_address_label";
            this.DB_address_label.Size = new System.Drawing.Size(32, 17);
            this.DB_address_label.TabIndex = 2;
            this.DB_address_label.Text = "地址";
            // 
            // DB_type_textBox
            // 
            this.DB_type_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
            this.DB_type_textBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_type_textBox.ForeColor = System.Drawing.Color.White;
            this.DB_type_textBox.Location = new System.Drawing.Point(54, 32);
            this.DB_type_textBox.Name = "DB_type_textBox";
            this.DB_type_textBox.ReadOnly = true;
            this.DB_type_textBox.Size = new System.Drawing.Size(100, 23);
            this.DB_type_textBox.TabIndex = 1;
            this.DB_type_textBox.Text = "SqlServer";
            // 
            // DB_type_label
            // 
            this.DB_type_label.AutoSize = true;
            this.DB_type_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DB_type_label.Location = new System.Drawing.Point(10, 33);
            this.DB_type_label.Name = "DB_type_label";
            this.DB_type_label.Size = new System.Drawing.Size(32, 17);
            this.DB_type_label.TabIndex = 0;
            this.DB_type_label.Text = "类型";
            this.DB_type_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(161, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 10;
            // 
            // groupBoxDataBase
            // 
            this.groupBoxDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDataBase.Controls.Add(this.DB_connector_button);
            this.groupBoxDataBase.Controls.Add(this.label3);
            this.groupBoxDataBase.Controls.Add(this.DB_name_textBox);
            this.groupBoxDataBase.Controls.Add(this.DB_name_label);
            this.groupBoxDataBase.Controls.Add(this.DB_password_textBox);
            this.groupBoxDataBase.Controls.Add(this.DB_password_label);
            this.groupBoxDataBase.Controls.Add(this.DB_username_textBox);
            this.groupBoxDataBase.Controls.Add(this.DB_username_label);
            this.groupBoxDataBase.Controls.Add(this.DB_address_textBox);
            this.groupBoxDataBase.Controls.Add(this.DB_address_label);
            this.groupBoxDataBase.Controls.Add(this.DB_type_textBox);
            this.groupBoxDataBase.Controls.Add(this.DB_type_label);
            this.groupBoxDataBase.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxDataBase.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBoxDataBase.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDataBase.Name = "groupBoxDataBase";
            this.groupBoxDataBase.Size = new System.Drawing.Size(306, 138);
            this.groupBoxDataBase.TabIndex = 0;
            this.groupBoxDataBase.TabStop = false;
            this.groupBoxDataBase.Text = "数据库";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(876, 706);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CodeGenerator";
            this.TitleColor = System.Drawing.Color.White;
            this.TitleOffset = new System.Drawing.Point(30, 0);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelRight.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.preview_groupBox.ResumeLayout(false);
            this.others_groupBox.ResumeLayout(false);
            this.others_groupBox.PerformLayout();
            this.DB_operator_groupBox.ResumeLayout(false);
            this.groupBoxDataBase.ResumeLayout(false);
            this.groupBoxDataBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TextBox DB_name_textBox;
        private System.Windows.Forms.Label DB_name_label;
        private System.Windows.Forms.TextBox DB_password_textBox;
        private System.Windows.Forms.Label DB_password_label;
        private System.Windows.Forms.TextBox DB_username_textBox;
        private System.Windows.Forms.Label DB_username_label;
        private System.Windows.Forms.TextBox DB_address_textBox;
        private System.Windows.Forms.Label DB_address_label;
        private System.Windows.Forms.TextBox DB_type_textBox;
        private System.Windows.Forms.Label DB_type_label;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox DB_operator_groupBox;
        private System.Windows.Forms.ListBox Right_listBox;
        private System.Windows.Forms.ListBox Left_listBox;
        private System.Windows.Forms.Button all_to_left_button;
        private System.Windows.Forms.Button to_left_button;
        private System.Windows.Forms.Button to_right_button;
        private System.Windows.Forms.Button all_to_right_button;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.Button view_dal_button;
        private System.Windows.Forms.Button view_model_button;
        internal System.Windows.Forms.Label copyright_label;
        private System.Windows.Forms.GroupBox others_groupBox;
        private System.Windows.Forms.Button browser_button;
        private System.Windows.Forms.TextBox path_textBox;
        private System.Windows.Forms.Label path_label;
        private System.Windows.Forms.TextBox namespace_textBox;
        private System.Windows.Forms.Label namespace_label;
        private System.Windows.Forms.TextBox table_prefix_textBox;
        private System.Windows.Forms.Label table_prefix_label;
        private System.Windows.Forms.TextBox author_textBox;
        private System.Windows.Forms.Label author_label;
        private ICSharpCode.TextEditor.TextEditorControl preview_textEditorControl;
        private System.Windows.Forms.Button DB_connector_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox preview_groupBox;
        private System.Windows.Forms.GroupBox groupBoxDataBase;
        private System.Windows.Forms.Label label3;
    }
}

