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
    public partial class CreatePostman : Form
    {
        public CreatePostman(AdminActions actionsA)
        {
            InitializeComponent();
            this.actionsA = actionsA;
        }

        //Enter
        private void button1_Click(object sender, EventArgs e)
        {
            Admin_ admin = new();

            if (admin.CreatePostman(textBox1.Text, textBox2.Text))
                MessageBox.Show("Почтальон " + textBox1.Text + " успешно создан.");
            else
                MessageBox.Show("Почтальон с таким login уже существует.");
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
