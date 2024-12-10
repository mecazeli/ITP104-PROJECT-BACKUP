using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProjectName.My_Classes;
using System.Diagnostics;
using MySqlConnector;
using System.IO;


namespace ITP104PROJECT
{
    public partial class Settings : Form
    {

        private Admin _admin;
        public static string connection = "server=localhost; user=root; password=; database=company; port=3306;";
        public MySqlConnection conn;
        


        public Settings()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            //btnDashboard.Click += new EventHandler(btnSide_Click);
            //btnSideDep.Click += new EventHandler(btnSide_Click);
            //btnSideProj.Click += new EventHandler(btnSide_Click);
            //btnSideEmp.Click += new EventHandler(btnSide_Click);
            //btnSettings.Click += new EventHandler(btnSide_Click);
            //btnLogout.Click += new EventHandler(btnSide_Click);
        }
        public Settings(Admin admin) : this()
        {
            _admin = admin;

            if (admin == null)
            {
                MessageBox.Show("Error: Admin object is null. Returning to Dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                switch (clickedButton.Name)
                {
                    case "btnDashboard":
                        this.Hide();
                        Dashboard dashboardForm = new Dashboard(_admin);
                        dashboardForm.Show();
                        break;
                    case "btnSideDep":
                        this.Hide();
                        Departments departmentsForm = new Departments(_admin);
                        departmentsForm.Show();

                        break;
                    case "btnSideEmp":
                        this.Hide();
                        Employees employeesForm = new Employees(_admin);
                        employeesForm.Show();
                        break;
                    case "btnSideProj":
                        this.Hide();
                        Project projectForm = new Project(_admin);
                        projectForm.Show();
                        break;
                    case "btnSettings":
                        MessageBox.Show("You are already on the Settings Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "btnLogout":
                        var result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Logging out...", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Login loginForm = new Login(_admin);
                            loginForm.Show();
                        }
                        break;
                }
            }
        }

        private void BackupDatabase(string backupFilePath)
        {
            try
            {
                string mysqldumpPath = @"C:\Program Files\MySQL\MySQL Workbench 8.0 CE\mysqldump.exe";

                string command = $@"""{mysqldumpPath}"" --user=root --host=localhost company --result-file=""{backupFilePath}"" --no-tablespaces --skip-column-statistics";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",

                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine(command);
                        }
                    }
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error during backup: {error}", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Backup completed successfully!\nOutput: {output}", "Backup",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void RestoreDatabase(string backupFilePath)
        {
            try
            {
                string command = $@"mysql --user=root --password= --host=localhost company < ""{backupFilePath}""";
            
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine(command);
                        }
                    }
                    process.WaitForExit();
                }
                MessageBox.Show("Database restored successfully!", "Restore", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during restore: {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        
        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL Files (.sql)|.sql";
                sfd.Title = "Save Database Backup";
                sfd.FileName = "company_backup.sql";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = sfd.FileName;
                    MessageBox.Show(backupFilePath);
                    BackupDatabase(backupFilePath);
                }
            }
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBackPath.Text))
             {
                if (Path.GetExtension(txtBackPath.Text).ToLower() != ".sql")
                {
                    MessageBox.Show("The file must be a .sql file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RestoreDatabase(txtBackPath.Text);
            } else
            {
                MessageBox.Show("Please Browse a Path for Restoring");
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.Filter = "SQL Files (*.sql)|*.sql";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBackPath.Text = ofd.FileName;
            }
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to change the username?",
                "Confirm Username Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _admin.username = txtNewUsername.Text;
                MessageBox.Show("Username changed successfully!");
                LoadAdminDetails();
            }
            else
            {
                MessageBox.Show("Username change canceled.");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to change the password?",
                "Confirm Password Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _admin.password = txtNewPassword.Text;
                MessageBox.Show("Password changed successfully!");
                LoadAdminDetails();
            }
            else
            {
                MessageBox.Show("Password change canceled.");
            }
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            LoadAdminDetails();

            if (_admin != null)
            {
                lblName.Text = _admin.name;
            }
        }

        private void LoadAdminDetails()
        {
            if (_admin == null)
            {
                MessageBox.Show("No admin details to display.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");

            dt.Rows.Add(_admin.name, _admin.age, _admin.gender, _admin.username, _admin.password);

            dgvAdmin.DataSource = dt;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
