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
    public partial class DeleteWorker : Form
    {
        public DeleteWorker(AdminActions actionsA)
        {
            InitializeComponent();
            this.actionsA = actionsA;
        }

        //Enter
        private void button1_Click(object sender, EventArgs e)
        {
            Admin_ admin = new();
            int result = admin.DeleteWorker(textBox1.Text);

            if (result == 1)
                MessageBox.Show("Работник " + textBox1.Text + " успешно удален.");
            else if (result == 2)
                MessageBox.Show("Этот работник не из вашего отделения.");
            else
                MessageBox.Show("Введен неправильный login.");

        }

        //Back
        private void button2_Click(object sender, EventArgs e)
        {
            actionsA.Show();
            Close();
        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private AdminActions actionsA;
    }
}
