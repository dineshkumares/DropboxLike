﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using ClientWorker;

namespace Client
{
    public partial class SigninForm : Form
    {
        Common common = new Common();
        public SigninForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = maskedTextBox1.Text;
            autheticateUser(email, password);           
        }
       
        public void autheticateUser(string email, string password)
        {
            if (!common.isEmailPwdNull(email, password))
            {
                if (common.validateEmail(email))
                {
                    NewUser login = new NewUser();

                    if (login.newRegister(email, password))
                    {
                        this.Hide();
                        ClientForm clientForm = new ClientForm(email);
                        clientForm.Show();

                    }
                    else
                    {
                        this.Hide();
                        SigninForm sf = new SigninForm();
                        sf.Show();

                        MessageBox.Show("LoginId or Password Is wrong"); //if user Name is not available in database

                    }
                }
                else
                {
                    MessageBox.Show("Please Enter valid emailID");
                }

            }
            else
            {
                MessageBox.Show("Please Enter Login Id and Password");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm sf = new LoginForm();
            sf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
