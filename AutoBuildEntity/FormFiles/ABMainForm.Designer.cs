namespace AutoBuildEntity.FormFiles
{
    partial class ABMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMainForm));
            this.tv_DBList = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建临时链接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建临时连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn_Build = new System.Windows.Forms.Button();
            this.cbx_Folder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_DBList
            // 
            this.tv_DBList.CheckBoxes = true;
            this.tv_DBList.ImageIndex = 0;
            this.tv_DBList.ImageList = this.imageList1;
            this.tv_DBList.Location = new System.Drawing.Point(12, 28);
            this.tv_DBList.Name = "tv_DBList";
            this.tv_DBList.SelectedImageIndex = 0;
            this.tv_DBList.Size = new System.Drawing.Size(233, 417);
            this.tv_DBList.TabIndex = 0;
            this.tv_DBList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_DBList_AfterCheck);
            this.tv_DBList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_DBList_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "table.png");
            this.imageList1.Images.SetKeyName(3, "file.png");
            this.imageList1.Images.SetKeyName(4, "add.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建临时链接ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建临时链接ToolStripMenuItem
            // 
            this.新建临时链接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建临时连接ToolStripMenuItem});
            this.新建临时链接ToolStripMenuItem.Name = "新建临时链接ToolStripMenuItem";
            this.新建临时链接ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.新建临时链接ToolStripMenuItem.Text = "数据源";
            // 
            // 新建临时连接ToolStripMenuItem
            // 
            this.新建临时连接ToolStripMenuItem.Name = "新建临时连接ToolStripMenuItem";
            this.新建临时连接ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建临时连接ToolStripMenuItem.Text = "新建临时连接";
            this.新建临时连接ToolStripMenuItem.Click += new System.EventHandler(this.新建临时连接ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(261, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(653, 417);
            this.tabControl1.TabIndex = 2;
            // 
            // btn_Build
            // 
            this.btn_Build.Location = new System.Drawing.Point(920, 404);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(105, 41);
            this.btn_Build.TabIndex = 3;
            this.btn_Build.Text = "生成";
            this.btn_Build.UseVisualStyleBackColor = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // cbx_Folder
            // 
            this.cbx_Folder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Folder.FormattingEnabled = true;
            this.cbx_Folder.Location = new System.Drawing.Point(916, 162);
            this.cbx_Folder.Name = "cbx_Folder";
            this.cbx_Folder.Size = new System.Drawing.Size(121, 20);
            this.cbx_Folder.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(921, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择文件夹";
            // 
            // ABMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Folder);
            this.Controls.Add(this.btn_Build);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tv_DBList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ABMainForm";
            this.Text = "实体自动生成";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_DBList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建临时链接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建临时连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.ComboBox cbx_Folder;
        private System.Windows.Forms.Label label1;
    }
}