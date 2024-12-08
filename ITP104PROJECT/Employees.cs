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
using MySql.Data.MySqlClient;

namespace ITP104PROJECT
{
    public partial class Employees : Form
    {

        public Admin _admin;
        public static string connection = "server=localhost; user=root; password=liezel11; database=company;";
        //public static string connection = "server=localhost; user=root; password=091203; database=company";
        //public static string connection = "server=localhost; user=root; password=; database=company; port=3306";
        public MySqlConnection conn;
        public Employees()
        {
            InitializeComponent();
            conn = new MySqlConnection(connection);
            btnDashboard.Click += new EventHandler(btnSide_Click);
            btnSideDep.Click += new EventHandler(btnSide_Click);
            btnSideProj.Click += new EventHandler(btnSide_Click);
            btnSettings.Click += new EventHandler(btnSide_Click);
            btnLogout.Click += new EventHandler(btnSide_Click);
        }

        public Employees(Admin admin) :this() { 
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
                        MessageBox.Show("You are already on the Employee Form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         break;
                    case "btnSideProj":
                        this.Hide();
                        Project projectForm = new Project(_admin);
                        projectForm.Show();
                        break;

                    case "btnSettings":
                        this.Hide();
                        Settings settingsForm = new Settings(_admin);
                        settingsForm.Show();
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

     

        private void Employees_Load(object sender, EventArgs e)
        {
            PopulateDepartmentComboBox();
            PopulateGenderComboBox();

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

                comboEmpDep.DataSource = dep;
                comboEmpDep.ValueMember = "departmentId";   
                comboEmpDep.DisplayMember = "departmentName";

            }
            catch(Exception ex)
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

        private void PopulateGenderComboBox()
        {
            try
            {
                string query = "SHOW COLUMNS FROM employee WHERE Field = 'gender'";
                DataTable genderdt = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(genderdt);
                    }
                }

                if(genderdt.Rows.Count >0)
                {
                    string enumType = genderdt.Rows[0]["Type"].ToString();
                    enumType = enumType.Replace("enum(", "").Replace(")", "").Replace("'", "");

                    string[] genderValues = enumType.Split(',');

                    cmbGender.Items.Clear();
                    cmbGender.Items.AddRange(genderValues);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error populating gender options: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }



        public void ViewEmployees(String message)
        {
            conn.Close();
            dgvEmployees.Rows.Clear();

            dgvEmployees.ColumnCount = 9;
            dgvEmployees.Columns[0].Name = "Employee ID";
            dgvEmployees.Columns[1].Name = "Employee Name";
            dgvEmployees.Columns[2].Name = "Age";
            dgvEmployees.Columns[3].Name = "Gender";
            dgvEmployees.Columns[4].Name = "Address";
            dgvEmployees.Columns[5].Name = "Email";
            dgvEmployees.Columns[6].Name = "Position";
            dgvEmployees.Columns[7].Name = "Date Hired";
            dgvEmployees.Columns[8].Name = "Salary";
            dgvEmployees.Columns.Add("Department", "Department Name"); 

            try
            {
                conn.Open();

   
                string query = @"
                SELECT 
                   e.employeeId, e.employeeName, e.age, e.gender, e.address,
                   e.email, e.position, e.datehired, e.salary, d.departmentName
                FROM employee e
                JOIN department d ON e.departmentId = d.departmentId;
                ";

               
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable employeesTable = new DataTable();
                dataAdapter.Fill(employeesTable);

              
                if (employeesTable.Rows.Count > 0)
                {
                   
                    foreach (DataRow row in employeesTable.Rows)
                    {
                       
                        string formattedSalary = "₱" + Convert.ToDecimal(row["salary"]).ToString("N2");

                      
                        dgvEmployees.Rows.Add(
                            row["employeeId"],
                            row["employeeName"],
                            row["age"],
                            row["gender"],
                            row["address"],
                            row["email"],
                            row["position"],
                            row["datehired"],
                            formattedSalary, 
                            row["departmentName"] 
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No employees found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
           
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool ValidateEmployeeInput(string empName, string empAddress, string empAge, string empEmail, string empPosition, string empGender, string empSalary)
        {
            if (string.IsNullOrEmpty(empName) || string.IsNullOrEmpty(empAddress) || string.IsNullOrEmpty(empAge) ||
                string.IsNullOrEmpty(empEmail) || string.IsNullOrEmpty(empPosition) || string.IsNullOrEmpty(empGender) || string.IsNullOrEmpty(empSalary))
            {
                MessageBox.Show("You missed some inputs. Please Try Again.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        public bool IsEmployeeNameExists(string empName)
        {
            try
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM employee WHERE employeeName = @name";
                MySqlCommand command = new MySqlCommand(checkQuery, conn);
                command.Parameters.AddWithValue("@name", empName);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking the employee name: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AddingEmployee()
        {
            string empName = txtEmpName.Text.Trim();
            string empAddress = txtEmpAddress.Text.Trim();
            string empAge = txtEmpAge.Text.Trim();
            string empEmail = txtEmpEmail.Text.Trim();
            string empPosition = txtEmpPosition.Text.Trim();
            string empGender = GetSelectedGender();
            string depId = GetSelectedDepartmentId();
            string empSalary = txtEmpSalary.Text.Trim();
            DateTime dateHired = dateHiredPicker.Value;


            if (!ValidateEmployeeInput(empName, empAddress, empAge, empEmail, empPosition, empGender, empSalary))
            {
                MessageBox.Show("Please fill in all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsEmployeeNameExists(empName))
            {
                MessageBox.Show("This employee name already exists. Please use a different employee name.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrEmpty(depId))
            {
                MessageBox.Show("Please select a department for the employee.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            try
            {
                conn.Open();

                string query = "INSERT INTO employee (employeeName, address, age, email, position, gender, salary,dateHired,departmentId) " +
                               "VALUES (@name, @address, @age, @email, @position, @gender, @salary, @dateHired, @departmentId)";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@name", empName);
                command.Parameters.AddWithValue("@address", empAddress);
                command.Parameters.AddWithValue("@age", empAge);
                command.Parameters.AddWithValue("@email", empEmail);
                command.Parameters.AddWithValue("@position", empPosition);
                command.Parameters.AddWithValue("@gender", empGender);
                command.Parameters.AddWithValue("@salary", empSalary);
                command.Parameters.AddWithValue("@dateHired", dateHired);
                command.Parameters.AddWithValue("@departmentId", depId); 

                command.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpName.Text = string.Empty;
                txtEmpAddress.Text = string.Empty;
                txtEmpAge.Text = string.Empty;
                txtEmpEmail.Text = string.Empty;
                txtEmpPosition.Text = string.Empty;
                txtEmpSalary.Text = string.Empty;
                cmbGender.SelectedIndex = -1;
                dateHiredPicker.Value = DateTime.Now;
                comboEmpDep.SelectedIndex = -1;

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


        private void DeletingEmployee()
        {
            if(dgvEmployees.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            int selectedRowCell = dgvEmployees.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvEmployees.Rows[selectedRowCell];
            string empId = selectedRow.Cells[0].Value?.ToString();

            if (string.IsNullOrEmpty(empId))
            {
                MessageBox.Show("Invalid employee selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = "DELETE FROM employee WHERE employeeId = @id";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@id", empId);
                command.ExecuteNonQuery();
                MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
             

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

        private string GetSelectedDepartmentId()
        {
           if(comboEmpDep.SelectedIndex == -1 || comboEmpDep.SelectedValue == null)
            {
                return null;
            }
            return comboEmpDep.SelectedValue.ToString();
        }

        private string GetSelectedGender()
        {
            if(cmbGender.SelectedIndex == -1 || cmbGender.SelectedItem == null)
            {
                return null;
            }

            return cmbGender.SelectedItem.ToString();
        }


        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            ViewEmployees("Employee list displayed successfully.");
        }

        private void btnAddEmployees_Click(object sender, EventArgs e)
        {
            AddingEmployee();
            ViewEmployees(" ");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletingEmployee();
            ViewEmployees(" ");
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            updateEmployee updateForm = new updateEmployee(this);
            updateForm.ShowDialog();
        }

        //-------SEARCH FUNCTION--------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            SearchEmployees(searchTerm);
        }

        private void SearchEmployees(string searchTerm)
        {
            dgvEmployees.Rows.Clear();

            // Convert the search term to lower case for case-insensitive comparison
            string lowerSearchTerm = searchTerm.ToLower();

            try
            {
                conn.Open();

                // Use a parameterized query to prevent SQL injection
                string query = @"
            SELECT 
                e.employeeId, e.employeeName, e.age, e.gender, e.address,
                e.email, e.position, e.datehired, e.salary, d.departmentName
            FROM employee e
            JOIN department d ON e.departmentId = d.departmentId";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Check if any column contains the search term (case-insensitive)
                            if (reader["employeeId"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["employeeName"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["age"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["gender"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["address"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["email"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["position"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["datehired"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["salary"].ToString().ToLower().Contains(lowerSearchTerm) ||
                                reader["departmentName"].ToString().ToLower().Contains(lowerSearchTerm))
                            {
                                string formattedSalary = "₱" + Convert.ToDecimal(reader["salary"]).ToString("N2");

                                dgvEmployees.Rows.Add(
                                    reader["employeeId"],
                                    reader["employeeName"],
                                    reader["age"],
                                    reader["gender"],
                                    reader["address"],
                                    reader["email"],
                                    reader["position"],
                                    reader["datehired"],
                                    formattedSalary,
                                    reader["departmentName"]
                                );
                            }
                        }
                    }
                }

                if (dgvEmployees.Rows.Count == 0)
                {
                    MessageBox.Show("No employees found matching the search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}
     