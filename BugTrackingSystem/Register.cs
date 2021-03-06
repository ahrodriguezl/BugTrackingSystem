﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BugTrackingSystem
{
    public partial class Register : Form
    {
        //connecting to mysql database
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; database=bugtrack; password=; SslMode=none;");
        MySqlCommand myCommand;
        public Register()
        {
            InitializeComponent();
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            //validation to check if any field is empty 
            if (txtname.Text == "")
            {
                lblname.Text = "Please enter your name ";
            }
            else if (txtemail.Text == "")
            {
                lblemail.Text = " Please enter your email ";
            }
            else if (txtuname.Text == "")
            {
                lblusername.Text = " Please enter a username ";
            }
            else if (txtpass.Text == "")
            {
                lblpass.Text = "Please enter a password ";
            }
            else{
                string name = txtname.Text;
                string email = txtemail.Text;
                string uname = txtuname.Text;
                string pass = txtpass.Text;
                try
                {
                    string myInsertQuery = "INSERT INTO users (name, email, username, password) Values('" + name + "','" + email + "', '" + uname + "', '" + pass + "')";
                    myCommand = new MySqlCommand(myInsertQuery);
                    myCommand.Connection = con;
                    con.Open();
                    if (myCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("User registered successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error connecting to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                myCommand.Connection.Close();
            }
        }
        }
    }
