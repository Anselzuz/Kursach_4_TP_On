using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_TP_Core.Forms.Admin
{
    public partial class AdminActions : Form
    {
        public AdminActions()
        {
            InitializeComponent();
        }

        //Проверка информации об отделении
        private void button1_Click(object sender, EventArgs e)
        {
            Admin_ admin = new();

            MessageBox.Show(admin.CheckDepartment());
        }

        //Закрыть/открыть отделение
        private void button4_Click(object sender, EventArgs e)
        {
            Admin_ admin = new();

            if (admin.OpenCloseDep())
                MessageBox.Show("Отделение открыто!");
            else
                MessageBox.Show("Отделение закрыто!");
        }

        //Добавить оператора
        private void button2_Click(object sender, EventArgs e)
        {
            CreateOperator crOp = new(this);
            crOp.Show();
            Hide();
        }

        //Добавить почтальона
        private void button5_Click(object sender, EventArgs e)
        {
            CreatePostman crPost = new(this);
            crPost.Show();
            Hide();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Удалить работника
        private void button6_Click(object sender, EventArgs e)
        {
            DeleteWorker delWor = new(this);
            delWor.Show();
            Hide();
        }
    }
}
