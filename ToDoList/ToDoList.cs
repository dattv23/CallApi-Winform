using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        int indexSelected = -1;
        string url = "http://127.0.0.1:3000/tasks";
        string urlMockApi = "https://65046c5bc8869921ae2505fa.mockapi.io/api/v1/tasks";

        public ToDoList()
        {
            InitializeComponent();
        }
        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexSelected = e.RowIndex;
        }

        /* 
            Task<string> là một loại đối tượng đại diện cho một tác vụ hoặc quá trình không đồng bộ (asynchronous). 
            Nó thường được sử dụng khi bạn muốn thực hiện một hoạt động không đồng bộ, chẳng hạn như gửi yêu cầu HTTP đến
            một API và đợi cho đến khi kết quả trả về.
         */

        public async Task<string> getData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(urlMockApi);

                    if (response.IsSuccessStatusCode) // 200
                    {
                        // Read the content of the response as a string
                        string res = await response.Content.ReadAsStringAsync();
                        return res;
                    }
                    else
                    {
                        MessageBox.Show($"Failed to fetch data. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public async Task<string> addData(string task)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonTask = JsonConvert.SerializeObject(new Task(0, "Open", DateTime.Now.ToString("dd-MM-yyyy"), "Low", task));
                    StringContent content = new StringContent(jsonTask, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(urlMockApi, content);
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

        public async Task<string> updateData(int indexSelected)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    int id = int.Parse(dgvTasks.Rows[indexSelected].Cells[0].Value.ToString());
                    string jsonTask = JsonConvert.SerializeObject(new Task(
                    int.Parse(dgvTasks.Rows[indexSelected].Cells[0].Value.ToString()),
                        dgvTasks.Rows[indexSelected].Cells[1].Value.ToString(),
                        dgvTasks.Rows[indexSelected].Cells[2].Value.ToString(),
                        dgvTasks.Rows[indexSelected].Cells[3].Value.ToString(),
                        dgvTasks.Rows[indexSelected].Cells[4].Value.ToString()));
                    StringContent content = new StringContent(jsonTask, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync($"{urlMockApi}/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string res = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Update data success.");
                        return res;
                    }
                    else
                    {
                        MessageBox.Show($"Update data failed. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public async Task<string> deleteData(int indexSelected)
        {
            try
            {
                int id = int.Parse(dgvTasks.Rows[indexSelected].Cells[0].Value.ToString());
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{urlMockApi}/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        string res = await response.Content.ReadAsStringAsync();
                        return res;
                    }
                    else
                    {
                        MessageBox.Show($"Delete data failed. Status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string res = await getData();
                List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(res);
                dgvTasks.Rows.Clear();

                // Add each task to the DataGridView
                foreach (var task in tasks)
                {
                    dgvTasks.Rows.Add(task.id, task.done, task.dueDate, task.priority, task.task);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string res = await addData(txtInput.Text);
                Task task = JsonConvert.DeserializeObject<Task>(res);
                dgvTasks.Rows.Add(task.id, task.done, task.dueDate, task.priority, task.task);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {
                string res = await updateData(indexSelected);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string res = await deleteData(indexSelected);
                dgvTasks.Rows.RemoveAt(indexSelected);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

    }
}
