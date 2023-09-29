using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void itemQuanLyPhong_Click(object sender, EventArgs e)
        {
            QuanLyPhong quanLyPhong = new QuanLyPhong();
            quanLyPhong.ShowDialog();
        }

        private void itemTrangChu_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.ShowDialog();
        }

        private void itemQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            QuanLyNguoiDung quanLyNguoiDung = new QuanLyNguoiDung();
            quanLyNguoiDung.ShowDialog();
        }

        private void toDoListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToDoList toDoList = new ToDoList();
            toDoList.ShowDialog();
        }
    }
}
