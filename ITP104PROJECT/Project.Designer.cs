namespace ITP104PROJECT
{
    partial class Project
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.lblTargetDate = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblProjName = new System.Windows.Forms.Label();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblProject = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnSideProj = new System.Windows.Forms.Button();
            this.btnSideEmp = new System.Windows.Forms.Button();
            this.btnSideDep = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDepFooter = new System.Windows.Forms.Panel();
            this.btnUpdateProject = new System.Windows.Forms.Button();
            this.projectTargetDate = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAddEmplyoee = new System.Windows.Forms.Label();
            this.panelDepLFooter = new System.Windows.Forms.Panel();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.taskTargetDate = new System.Windows.Forms.DateTimePicker();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbmProject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.panel7.SuspendLayout();
            this.panelSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDepFooter.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelDepLFooter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProject
            // 
            this.dgvProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProject.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProject.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProject.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProject.EnableHeadersVisualStyles = false;
            this.dgvProject.Location = new System.Drawing.Point(194, 61);
            this.dgvProject.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.RowHeadersWidth = 51;
            this.dgvProject.Size = new System.Drawing.Size(1176, 423);
            this.dgvProject.TabIndex = 1;
            // 
            // lblTargetDate
            // 
            this.lblTargetDate.AutoSize = true;
            this.lblTargetDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetDate.Location = new System.Drawing.Point(86, 132);
            this.lblTargetDate.Name = "lblTargetDate";
            this.lblTargetDate.Size = new System.Drawing.Size(92, 22);
            this.lblTargetDate.TabIndex = 6;
            this.lblTargetDate.Text = "Target Date";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(86, 95);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(94, 22);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "Department";
            // 
            // lblProjName
            // 
            this.lblProjName.AutoSize = true;
            this.lblProjName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjName.Location = new System.Drawing.Point(75, 58);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(107, 22);
            this.lblProjName.TabIndex = 4;
            this.lblProjName.Text = "Project Name";
            // 
            // btnAddProject
            // 
            this.btnAddProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnAddProject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddProject.Location = new System.Drawing.Point(182, 164);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(94, 35);
            this.btnAddProject.TabIndex = 3;
            this.btnAddProject.Text = "ADD";
            this.btnAddProject.UseVisualStyleBackColor = false;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(91)))), ((int)(((byte)(94)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lblProject);
            this.panel7.Controls.Add(this.btnSearch);
            this.panel7.Controls.Add(this.txtSearch);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(194, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1176, 61);
            this.panel7.TabIndex = 9;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Trebuchet MS", 25F);
            this.lblProject.ForeColor = System.Drawing.Color.White;
            this.lblProject.Location = new System.Drawing.Point(13, 7);
            this.lblProject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(472, 43);
            this.lblProject.TabIndex = 2;
            this.lblProject.Text = "Project and Task Management";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.btnSearch.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.btnSearch.Location = new System.Drawing.Point(1074, 11);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 33);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(850, 17);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 26);
            this.txtSearch.TabIndex = 0;
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(91)))), ((int)(((byte)(94)))));
            this.panelSideBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSideBar.Controls.Add(this.lblName);
            this.panelSideBar.Controls.Add(this.lblAdmin);
            this.panelSideBar.Controls.Add(this.btnLogout);
            this.panelSideBar.Controls.Add(this.btnSettings);
            this.panelSideBar.Controls.Add(this.btnSideProj);
            this.panelSideBar.Controls.Add(this.btnSideEmp);
            this.panelSideBar.Controls.Add(this.btnSideDep);
            this.panelSideBar.Controls.Add(this.btnDashboard);
            this.panelSideBar.Controls.Add(this.pictureBox1);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Margin = new System.Windows.Forms.Padding(2);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(194, 700);
            this.panelSideBar.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(39, 156);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(111, 20);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Jessa Cariñaga";
            // 
            // lblAdmin
            // 
            this.lblAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.ForeColor = System.Drawing.Color.White;
            this.lblAdmin.Location = new System.Drawing.Point(70, 176);
            this.lblAdmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(49, 18);
            this.lblAdmin.TabIndex = 8;
            this.lblAdmin.Text = "Admin";
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 492);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(193, 42);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Location = new System.Drawing.Point(0, 439);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(193, 42);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnSideProj
            // 
            this.btnSideProj.FlatAppearance.BorderSize = 0;
            this.btnSideProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideProj.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideProj.ForeColor = System.Drawing.Color.White;
            this.btnSideProj.Location = new System.Drawing.Point(0, 385);
            this.btnSideProj.Margin = new System.Windows.Forms.Padding(2);
            this.btnSideProj.Name = "btnSideProj";
            this.btnSideProj.Size = new System.Drawing.Size(193, 42);
            this.btnSideProj.TabIndex = 5;
            this.btnSideProj.Text = "Projects";
            this.btnSideProj.UseVisualStyleBackColor = true;
            // 
            // btnSideEmp
            // 
            this.btnSideEmp.FlatAppearance.BorderSize = 0;
            this.btnSideEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideEmp.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideEmp.ForeColor = System.Drawing.Color.White;
            this.btnSideEmp.Location = new System.Drawing.Point(0, 332);
            this.btnSideEmp.Margin = new System.Windows.Forms.Padding(2);
            this.btnSideEmp.Name = "btnSideEmp";
            this.btnSideEmp.Size = new System.Drawing.Size(193, 42);
            this.btnSideEmp.TabIndex = 4;
            this.btnSideEmp.Text = "Employees";
            this.btnSideEmp.UseVisualStyleBackColor = true;
            // 
            // btnSideDep
            // 
            this.btnSideDep.FlatAppearance.BorderSize = 0;
            this.btnSideDep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideDep.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideDep.ForeColor = System.Drawing.Color.White;
            this.btnSideDep.Location = new System.Drawing.Point(2, 279);
            this.btnSideDep.Margin = new System.Windows.Forms.Padding(2);
            this.btnSideDep.Name = "btnSideDep";
            this.btnSideDep.Size = new System.Drawing.Size(190, 42);
            this.btnSideDep.TabIndex = 3;
            this.btnSideDep.Text = "Departments";
            this.btnSideDep.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 224);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(190, 42);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ITP104PROJECT.Properties.Resources.Businesswoman_free_icons_designed_by_Freepik;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(46, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 103);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelDepFooter
            // 
            this.panelDepFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.panelDepFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDepFooter.Controls.Add(this.btnUpdateProject);
            this.panelDepFooter.Controls.Add(this.projectTargetDate);
            this.panelDepFooter.Controls.Add(this.btnDeleteProject);
            this.panelDepFooter.Controls.Add(this.cbDepartment);
            this.panelDepFooter.Controls.Add(this.txtProjName);
            this.panelDepFooter.Controls.Add(this.lblTargetDate);
            this.panelDepFooter.Controls.Add(this.panel4);
            this.panelDepFooter.Controls.Add(this.lblDepartment);
            this.panelDepFooter.Controls.Add(this.lblProjName);
            this.panelDepFooter.Controls.Add(this.btnAddProject);
            this.panelDepFooter.Controls.Add(this.panelDepLFooter);
            this.panelDepFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDepFooter.Location = new System.Drawing.Point(194, 484);
            this.panelDepFooter.Margin = new System.Windows.Forms.Padding(2);
            this.panelDepFooter.Name = "panelDepFooter";
            this.panelDepFooter.Size = new System.Drawing.Size(1176, 216);
            this.panelDepFooter.TabIndex = 10;
            // 
            // btnUpdateProject
            // 
            this.btnUpdateProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnUpdateProject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateProject.Location = new System.Drawing.Point(379, 164);
            this.btnUpdateProject.Name = "btnUpdateProject";
            this.btnUpdateProject.Size = new System.Drawing.Size(93, 35);
            this.btnUpdateProject.TabIndex = 35;
            this.btnUpdateProject.Text = "UPDATE";
            this.btnUpdateProject.UseVisualStyleBackColor = false;
            this.btnUpdateProject.Click += new System.EventHandler(this.btnUpdateProject_Click);
            // 
            // projectTargetDate
            // 
            this.projectTargetDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectTargetDate.Location = new System.Drawing.Point(182, 133);
            this.projectTargetDate.MinDate = new System.DateTime(2024, 12, 7, 14, 16, 16, 0);
            this.projectTargetDate.Name = "projectTargetDate";
            this.projectTargetDate.Size = new System.Drawing.Size(291, 25);
            this.projectTargetDate.TabIndex = 34;
            this.projectTargetDate.Value = new System.DateTime(2024, 12, 7, 14, 16, 16, 0);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnDeleteProject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteProject.Location = new System.Drawing.Point(281, 164);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(93, 35);
            this.btnDeleteProject.TabIndex = 30;
            this.btnDeleteProject.Text = "DELETE";
            this.btnDeleteProject.UseVisualStyleBackColor = false;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // cbDepartment
            // 
            this.cbDepartment.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(183, 92);
            this.cbDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(291, 28);
            this.cbDepartment.TabIndex = 28;
            // 
            // txtProjName
            // 
            this.txtProjName.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjName.Location = new System.Drawing.Point(183, 58);
            this.txtProjName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(291, 25);
            this.txtProjName.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(91)))), ((int)(((byte)(94)))));
            this.panel4.Controls.Add(this.lblAddEmplyoee);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(526, 36);
            this.panel4.TabIndex = 24;
            // 
            // lblAddEmplyoee
            // 
            this.lblAddEmplyoee.AutoSize = true;
            this.lblAddEmplyoee.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold);
            this.lblAddEmplyoee.ForeColor = System.Drawing.Color.White;
            this.lblAddEmplyoee.Location = new System.Drawing.Point(238, 2);
            this.lblAddEmplyoee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddEmplyoee.Name = "lblAddEmplyoee";
            this.lblAddEmplyoee.Size = new System.Drawing.Size(236, 29);
            this.lblAddEmplyoee.TabIndex = 3;
            this.lblAddEmplyoee.Text = "Create New Project";
            // 
            // panelDepLFooter
            // 
            this.panelDepLFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDepLFooter.Controls.Add(this.cbmProject);
            this.panelDepLFooter.Controls.Add(this.label1);
            this.panelDepLFooter.Controls.Add(this.btnUpdateTask);
            this.panelDepLFooter.Controls.Add(this.taskTargetDate);
            this.panelDepLFooter.Controls.Add(this.btnDeleteTask);
            this.panelDepLFooter.Controls.Add(this.btnAddTask);
            this.panelDepLFooter.Controls.Add(this.label2);
            this.panelDepLFooter.Controls.Add(this.label6);
            this.panelDepLFooter.Controls.Add(this.txtTask);
            this.panelDepLFooter.Controls.Add(this.label7);
            this.panelDepLFooter.Controls.Add(this.cbEmployee);
            this.panelDepLFooter.Controls.Add(this.panel5);
            this.panelDepLFooter.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDepLFooter.Location = new System.Drawing.Point(526, 0);
            this.panelDepLFooter.Margin = new System.Windows.Forms.Padding(2);
            this.panelDepLFooter.Name = "panelDepLFooter";
            this.panelDepLFooter.Size = new System.Drawing.Size(648, 214);
            this.panelDepLFooter.TabIndex = 29;
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnUpdateTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTask.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateTask.Location = new System.Drawing.Point(383, 144);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(93, 35);
            this.btnUpdateTask.TabIndex = 34;
            this.btnUpdateTask.Text = "UPDATE";
            this.btnUpdateTask.UseVisualStyleBackColor = false;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // taskTargetDate
            // 
            this.taskTargetDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskTargetDate.Location = new System.Drawing.Point(101, 91);
            this.taskTargetDate.MinDate = new System.DateTime(2024, 12, 7, 14, 16, 4, 0);
            this.taskTargetDate.Name = "taskTargetDate";
            this.taskTargetDate.Size = new System.Drawing.Size(201, 25);
            this.taskTargetDate.TabIndex = 33;
            this.taskTargetDate.Value = new System.DateTime(2024, 12, 7, 14, 16, 4, 0);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTask.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteTask.Location = new System.Drawing.Point(284, 144);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(93, 35);
            this.btnDeleteTask.TabIndex = 32;
            this.btnDeleteTask.Text = "DELETE";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(112)))), ((int)(((byte)(133)))));
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddTask.Location = new System.Drawing.Point(185, 144);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(93, 35);
            this.btnAddTask.TabIndex = 31;
            this.btnAddTask.Text = "ADD";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Target Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label6.Location = new System.Drawing.Point(315, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "Employee";
            // 
            // txtTask
            // 
            this.txtTask.Font = new System.Drawing.Font("Trebuchet MS", 11F);
            this.txtTask.Location = new System.Drawing.Point(59, 54);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(243, 25);
            this.txtTask.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label7.Location = new System.Drawing.Point(14, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Task";
            // 
            // cbEmployee
            // 
            this.cbEmployee.Font = new System.Drawing.Font("Trebuchet MS", 11F);
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(401, 54);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(235, 28);
            this.cbEmployee.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(91)))), ((int)(((byte)(94)))));
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(646, 35);
            this.panel5.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(240, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Assign Task";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.label1.Location = new System.Drawing.Point(319, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Project";
            // 
            // cbmProject
            // 
            this.cbmProject.Font = new System.Drawing.Font("Trebuchet MS", 11F);
            this.cbmProject.FormattingEnabled = true;
            this.cbmProject.Location = new System.Drawing.Point(401, 91);
            this.cbmProject.Name = "cbmProject";
            this.cbmProject.Size = new System.Drawing.Size(235, 28);
            this.cbmProject.TabIndex = 36;
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1370, 700);
            this.Controls.Add(this.dgvProject);
            this.Controls.Add(this.panelDepFooter);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panelSideBar);
            this.Name = "Project";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.Project_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelSideBar.ResumeLayout(false);
            this.panelSideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDepFooter.ResumeLayout(false);
            this.panelDepFooter.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelDepLFooter.ResumeLayout(false);
            this.panelDepLFooter.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Label lblProjName;
        private System.Windows.Forms.Label lblTargetDate;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSideProj;
        private System.Windows.Forms.Button btnSideEmp;
        private System.Windows.Forms.Button btnSideDep;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDepFooter;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAddEmplyoee;
        private System.Windows.Forms.Panel panelDepLFooter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DateTimePicker taskTargetDate;
        private System.Windows.Forms.DateTimePicker projectTargetDate;
        private System.Windows.Forms.Button btnUpdateProject;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbmProject;
        private System.Windows.Forms.Label label1;
    }
}