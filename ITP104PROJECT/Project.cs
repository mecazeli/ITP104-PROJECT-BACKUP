using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace ITP104PROJECT
{
    public partial class Project : Form
    {

        //public static string connection = "server=localhost; user=root; password=; database=company; port=3306";
        //public static string connection = "server=localhost; user=root; password=091203; database=company;";
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        public MySqlConnection conn;
        public Admin _admin;

        public Project()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideEmp.Click += new EventHandler(btnSide_Click);
            btnSideProj.Click += new EventHandler(btnSide_Click);
            btnSettings.Click += new EventHandler(btnSide_Click);
            btnLogout.Click += new EventHandler(btnSide_Click);
        }

        public Project(Admin admin) : this()
        {
            _admin = admin;
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
                        MessageBox.Show("You are already on the Project.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "btnSettings":
                        this.Hide();
                        Settings settingsForm = new Settings(_admin);
                        settingsForm.Show();
                        this.Hide();
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



        private void Project_Load(object sender, EventArgs e)
        {
            ViewProjectAndTasks();
            PopulateDepartmentComboBox();
            PopulateEmployee();
            PopulateProjects();

            if (_admin != null)
            {
                lblName.Text = _admin.name;
            }

        }

        private void PopulateDepartmentComboBox()
        {
            try
            {
                string query = "SELECT departmentId, departmentName FROM department";
                DataTable dep = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dep);
                    }
                }

                cbDepartment.DataSource = dep;
                cbDepartment.ValueMember = "departmentId";
                cbDepartment.DisplayMember = "departmentName";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void PopulateEmployee()
        {
            try
            {
                string query = "SELECT e.employeeId, e.employeeName FROM employee e";
                DataTable employees = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(employees);
                    }
                }
                cbEmployee.DataSource = employees;
                cbEmployee.ValueMember = "employeeId";
                cbEmployee.DisplayMember = "employeeName";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error populating employee comboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void PopulateProjects()
        {
            try
            {
                string query = "SELECT p.projectId, p.projectName FROM project p";
                DataTable projects = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(projects);
                    }
                }

                cbmProject.DataSource = projects;
                cbmProject.ValueMember = "projectId";
                cbmProject.DisplayMember = "projectName";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error populating project comboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void ViewProjectAndTasks()
        {;
            dgvProject.Rows.Clear();
            dgvProject.Columns.Clear();

            dgvProject.ColumnCount = 7;
            dgvProject.Columns[0].Name = "Project ID";
            dgvProject.Columns[1].Name = "Project Name";
            dgvProject.Columns[2].Name = "Project Start Date";
            dgvProject.Columns[3].Name = "Project End Date";
            dgvProject.Columns[4].Name = "Task ID";
            dgvProject.Columns[5].Name = "Task Name";
            dgvProject.Columns[6].Name = "Employee ID";

            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.Name = "Project Status";
            statusColumn.HeaderText = "Project Status";
            statusColumn.Items.AddRange("Pending", "In Progress", "Completed");
            dgvProject.Columns.Add(statusColumn);


            try
            {
               
                conn.Open();

               
                string query = @"
             SELECT 
                p.projectId,
                p.projectName,
                p.startDate AS ProjectStartDate,
                p.endDate AS ProjectEndDate,
                t.taskId,
                t.taskName,
                t.employeeId,
                p.status AS projectStatus
            FROM 
                project p
            LEFT JOIN 
                task t ON p.projectId = t.projectId;
           ";

              
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

              
                DataTable projectTaskTable = new DataTable();
                projectTaskTable.Load(reader);

              
                if (projectTaskTable.Rows.Count > 0)
                {
                    foreach (DataRow row in projectTaskTable.Rows)
                    {
                        
                        int rowIndex = dgvProject.Rows.Add(
                            row["projectId"],
                            row["projectName"],
                            row["ProjectStartDate"],
                            row["ProjectEndDate"],
                            row["taskId"] != DBNull.Value ? row["taskId"] : null,
                            row["taskName"] != DBNull.Value ? row["taskName"] : null,
                            row["employeeId"] != DBNull.Value ? row["employeeId"] : null
                        );

                       
                        dgvProject.Rows[rowIndex].Cells["Project Status"].Value = row["projectStatus"] != DBNull.Value
                            ? row["projectStatus"].ToString()
                            : "Pending";
                    }
                }
                else
                {
                    MessageBox.Show("No projects found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void AddProject()
        {
            string projName = txtProjName.Text.Trim(); 
            string selectedDepId = GetSelectedDepartmentId(); 
            DateTime targetDate = projectTargetDate.Value;

            if (string.IsNullOrEmpty(projName) || string.IsNullOrEmpty(selectedDepId))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsProjectNameExists(projName))
            {
                MessageBox.Show("Project name already exists. Please choose a different name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = @"
                         INSERT INTO project (projectName, departmentId, startDate, endDate, status)
                         VALUES (@projectName, @departmentId, @startDate, @endDate, 'Pending');";

                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@projectName", projName);
                command.Parameters.AddWithValue("@departmentId", selectedDepId);
                command.Parameters.AddWithValue("@startDate", DateTime.Now);
                command.Parameters.AddWithValue("@endDate", targetDate);

                command.ExecuteNonQuery();
                MessageBox.Show("Project added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
         

                txtProjName.Text = string.Empty;
                cbDepartment.SelectedItem = -1;
                projectTargetDate.Value = DateTime.Now;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding project: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void DeleteProject()
        {
            if (dgvProject.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a project to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowCell = dgvProject.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvProject.Rows[selectedRowCell];
            string projectId = selectedRow.Cells[0].Value?.ToString(); // Change index if `projectId` is not in the first column

            if (string.IsNullOrEmpty(projectId))
            {
                MessageBox.Show("Invalid project selected. Make sure the project ID exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = "DELETE FROM project WHERE projectId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@id", projectId);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Project deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching project found to delete. Please verify the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void UpdateProject()
        {

        }

        private string GetSelectedDepartmentId()
        {
            if (cbDepartment.SelectedIndex == -1 || cbDepartment.SelectedValue == null)
            {
                return null;
            }
            return cbDepartment.SelectedValue.ToString();
        }

        private string GetSelectedEmployeeId()
        {
            if(cbEmployee.SelectedIndex == -1 || cbEmployee.SelectedValue == null)
            {
                return null;
            }
            return cbEmployee.SelectedValue.ToString();
        }


        private string GetSelectedProjectId()
        {
            if (cbmProject.SelectedIndex == -1 || cbmProject.SelectedValue == null)
            {
                return null;
            }
            return cbmProject.SelectedValue.ToString();
        }


        public bool IsProjectNameExists(string projectName)
        {
            try
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM project WHERE projectName = @name";
                MySqlCommand command = new MySqlCommand(checkQuery, conn);
                command.Parameters.AddWithValue("@name", projectName);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;

            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while checking the project name: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
           
        }


        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            DeleteProject();
            ViewProjectAndTasks();
        }

        private void btnUpdateProject_Click(object sender, EventArgs e)
        {

        }


        // +==============================================================+

        private void AddTask()
        {
            string taskName = txtTask.Text.Trim();
            string selectedEmpId = GetSelectedEmployeeId();
            string selectedProjectId = GetSelectedProjectId();
            DateTime taskTargetTime = taskTargetDate.Value;

            if (string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(selectedEmpId) || string.IsNullOrEmpty(selectedProjectId))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsTaskNameExits(taskName))
            {
                MessageBox.Show("Task name already exists. Please choose a different name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsProjectValid(selectedProjectId))
            {
                MessageBox.Show("The selected project is either completed or does not exist.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = @"
                   INSERT INTO task (taskName, employeeId, projectId, deadline)
                   VALUES (@taskName, @employeeId, @projectId, @deadline);";

                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@taskName", taskName);
                command.Parameters.AddWithValue("@employeeId", selectedEmpId);
                command.Parameters.AddWithValue("@projectId", selectedProjectId);
                command.Parameters.AddWithValue("@deadline", taskTargetTime);

                command.ExecuteNonQuery();

                MessageBox.Show("Task added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTask.Text = string.Empty;
                cbEmployee.SelectedIndex = -1;
                taskTargetDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }



        private void DeleteTask()
        {
            
            if (dgvProject.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            int selectedRowCell = dgvProject.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvProject.Rows[selectedRowCell];
            string taskId = selectedRow.Cells[3].Value?.ToString(); 
            if (string.IsNullOrEmpty(taskId))
            {
                MessageBox.Show("Invalid task selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

             
                string query = "DELETE FROM task WHERE taskId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

              
                command.Parameters.AddWithValue("@id", taskId);

             
                int rowsAffected = command.ExecuteNonQuery();

              
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching task found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void UpdateTask()
        {

        }

      
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask();
            ViewProjectAndTasks();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            AddProject();
            ViewProjectAndTasks();
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            DeleteTask();
            ViewProjectAndTasks();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {

        }

        public bool IsTaskNameExits(string taskName)
        {
            try
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM task WHERE taskName = @name";
                MySqlCommand command = new MySqlCommand(checkQuery, conn);
                command.Parameters.AddWithValue("@name", taskName);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while checking the task name: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private bool IsProjectValid(string projectId)
        {
            bool isValid = false;

            try
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM project
                    WHERE projectId = @projectId AND status != 'Completed';";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@projectId", projectId);

                int count = Convert.ToInt32(command.ExecuteScalar());
                isValid = count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating project: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return isValid;
        }

    }
}
