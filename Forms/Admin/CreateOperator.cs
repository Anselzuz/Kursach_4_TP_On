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
    public partial class CreateOperator : Form
    {
        public CreateOperator(AdminActions actionsA)
        {
            InitializeComponent();
            this.actionsA = actionsA;
        }

        //Enter
        private void button1_Click(object sender, EventArgs e)
        {
            Admin_ admin = new();

            if (admin.CreateOperator(textBox1.Text, textBox2.Text))
                MessageBox.Show("Оператор " + textBox1.Text + " успешно создан.");
            else
                MessageBox.Show("Оператор с таким login уже существует.");

        }

        //Exit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Back
        private void button2_Click(object sender, EventArgs e)
        {
            actionsA.Show();
            Close();
        }

        private AdminActions actionsA;
    }
}