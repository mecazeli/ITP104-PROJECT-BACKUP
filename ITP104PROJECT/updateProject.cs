using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITP104PROJECT
{
    public partial class updateProject : Form
    {
        public Project project;
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        public updateProject(Project projectForm)
        {
            InitializeComponent();
            project = projectForm;
            LoadDepartments();
            
        }

        private void updateProject_Load(object sender, EventArgs e)
        {
        }

        private void SetDateTimePickerToNow()
        {
          
            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.MinDate = DateTime.Now.Date; 
        }

        private void LoadDepartments()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT departmentId, departmentName FROM department";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable departments = new DataTable();
                            departments.Load(reader);
                            cbDepartment.DataSource = departments;
                            cbDepartment.DisplayMember = "departmentName";
                            cbDepartment.ValueMember = "departmentId";
                            cbDepartment.SelectedIndex = -1;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            int projId;
            if (!int.TryParse(txtProjId.Text, out projId))
            {
                MessageBox.Show("Please enter a valid Project ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT startDate, departmentId FROM project WHERE projectId = @projId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@projId", projId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dateTimePicker.Value = Convert.ToDateTime(reader["startDate"]);
                                cbDepartment.SelectedValue = reader["departmentId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Employee not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching employee details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void RefreshProjectGrid(string message = "")
        {
            if (project != null)
            {
                project.ViewProjectAndTasks();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int projId;
            if (!int.TryParse(txtProjId.Text, out projId))
            {
                MessageBox.Show("Please enter a valid Project ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime newStartDate = dateTimePicker.Value; 
            object newDepartment = cbDepartment.SelectedValue;

            if (newDepartment == null)
            {
                MessageBox.Show("Please select a department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE project SET startDate = @newStartDate, departmentId = @newDepartment WHERE projectId = @projId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newStartDate", newStartDate);
                        cmd.Parameters.AddWithValue("@newDepartment", newDepartment);
                        cmd.Parameters.AddWithValue("@projId", projId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                  $"Project updated successfully.\nProject ID: {projId}",
                                  "Success",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                            RefreshProjectGrid("Project data refreshed after update.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please check the details and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
