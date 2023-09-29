using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ToDoList
{
    public partial class QuanLyNguoiDung : Form
    {
        string urlApi = "http://127.0.0.1:3000/users";

        public QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private async Task<string> AddUser(User user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonUser = JsonConvert.SerializeObject(user);
                    StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(urlApi, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string res = await response.Content.ReadAsStringAsync();
                        return res;
                    }
                    else
                    {
                        MessageBox.Show($"Add data failed. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }


        private async void btnThem_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                name = txtTen.Text,
                phone = txtSoDT.Text,
                email = txtEmail.Text,
                address = txtDiaChi.Text,
                gender = cbGioiTinh.SelectedIndex 
            };

            // Call the AddUser function and await the result
            string result = await AddUser(newUser);

            if (result != null)
            {
                // Handle the success case here (e.g., display a success message)
                dgvUser.Rows.Add(newUser.name, newUser.gender == 0 ? "Nữ" : "Nam", newUser.address, newUser.phone, newUser.email);
            }
        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            cbGioiTinh.SelectedIndex = 0;
        }

        private async Task<bool> LoadData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(urlApi);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<User> userList = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

                        // Assuming your DataGridView is named dgvUser
                        dgvUser.Rows.Clear(); // Clear existing data
                        foreach (User user in userList)
                        {
                            dgvUser.Rows.Add(user.name, user.gender == 0 ? "Nữ" : "Nam", user.address, user.phone, user.email);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed to retrieve user data. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }


        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task<bool> UpdateUser(User user)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonUser = JsonConvert.SerializeObject(user);
                    StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                    // Assuming you have the user's _id available (replace "userId" with the actual property name)
                    HttpResponseMessage response = await client.PutAsync(urlApi, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Handle the success case here (e.g., display a success message)
                        MessageBox.Show("User updated successfully!");

                        // Reload the data in the DataGridView to reflect the changes
                        await LoadData();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Update failed. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            User updatedUser = new User
            {
                name = txtTen.Text,
                phone = txtSoDT.Text,
                email = txtEmail.Text,
                address = txtDiaChi.Text,
                gender = cbGioiTinh.SelectedIndex
            };

            // Call the UpdateUser function and await the result
            await UpdateUser(updatedUser);
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUser.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvUser.Rows[e.RowIndex];

                // Assuming the order of columns in the DataGridView matches the User class properties
                txtTen.Text = selectedRow.Cells[0].Value.ToString();
                txtSoDT.Text = selectedRow.Cells[3].Value.ToString();
                txtEmail.Text = selectedRow.Cells[4].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[2].Value.ToString();

                int genderIndex = selectedRow.Cells[1].Value.ToString().Equals("Nam", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                cbGioiTinh.SelectedIndex = genderIndex;
            }
        }

        private async Task<bool> DeleteUserByPhone(string phone)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Construct the URL with the phone number as a query parameter
                    string apiUrl = $"{urlApi}?phone={phone}";

                    // Send a DELETE request to the constructed URL
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Handle the success case here (e.g., display a success message)
                        MessageBox.Show("User deleted successfully!");

                        // Reload the data in the DataGridView to reflect the changes
                        await LoadData();
                        return true;
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("User not found.");
                    }
                    else
                    {
                        MessageBox.Show($"Delete failed. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        private async void btnXoa_Click(object sender, EventArgs e)
        {
            await DeleteUserByPhone(txtSoDT.Text);
        }
    }
}
