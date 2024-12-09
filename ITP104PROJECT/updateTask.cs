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
    public partial class updateTask : Form
    {
        public Project tasks;
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        public updateTask(Project taskForm)
        {
            InitializeComponent();
            tasks = taskForm;
            LoadProjects();
            LoadEmployees();
        }

        private void updateTask_Load(object sender, EventArgs e)
        {

        }

        private void LoadProjects()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT projectId, projectName FROM project";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable projects = new DataTable();
                            projects.Load(reader);
                            cbProject.DataSource = projects;
                            cbProject.DisplayMember = "projectName";
                            cbProject.ValueMember = "projectId";
                            cbProject.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadEmployees()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT employeeId, employeeName FROM employee";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable employees = new DataTable();
                            employees.Load(reader);
                            cbEmployee.DataSource = employees;
                            cbEmployee.DisplayMember = "employeeName";
                            cbEmployee.ValueMember = "employeeId";
                            cbEmployee.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetDateTimePickerToNow()
        {

            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.MinDate = DateTime.Now.Date;
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            int taskId;
            if (!int.TryParse(txtTaskId.Text, out taskId))
            {
                MessageBox.Show("Please enter a valid Task ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT endDate, deadline, employeeId FROM task WHERE taskId = @taskId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@taskId", taskId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dateTimePicker.Value = Convert.ToDateTime(reader["deadline"]);
                                cbProject.SelectedValue = reader["projectId"].ToString();
                                cbEmployee.SelectedValue = reader["employeeId"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Task not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching task details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RefreshTaskGrid(string message = "")
        {
            if (tasks != null)
            {
                tasks.ViewProjectAndTasks();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int taskId;
            if (!int.TryParse(txtTaskId.Text, out taskId))
            {
                MessageBox.Show("Please enter a valid Task ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime newDeadline = dateTimePicker.Value;
            object newProjectId = cbProject.SelectedValue;
            object newEmployeeId = cbEmployee.SelectedValue;

            if (newProjectId == null)
            {
                MessageBox.Show("Please select a valid project.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newEmployeeId == null)
            {
                MessageBox.Show("Please select a valid employee.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE task SET deadline = @newDeadline, projectId = @newProjectId, employeeId = @newEmployeeId WHERE taskId = @taskId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newDeadline", newDeadline);
                        cmd.Parameters.AddWithValue("@newProjectId", newProjectId);
                        cmd.Parameters.AddWithValue("@newEmployeeId", newEmployeeId);
                        cmd.Parameters.AddWithValue("@taskId", taskId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(
                                $"Task updated successfully.\nTask ID: {taskId}",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            RefreshTaskGrid("Task data refreshed after update.");
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
                    MessageBox.Show($"Error updating task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
