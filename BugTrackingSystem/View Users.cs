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
    public partial class ViewUsers : Form
    {
        //connecting to mysql database
        MySqlConnection conn = new MySqlConnection("datasource=localhost; port=3306; username=root; database=bugtrack; password=; SslMode=none;");
        MySqlDataAdapter ad;
        DataSet dt;
        public ViewUsers()
        {
            InitializeComponent();
        }

        //action when view users button is clicked
        private void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                //sql query to select data from database
                string query = "select * from users u, roles r, user_roles ur where u.id = ur.user_id and r.id = ur.role_id";
                ad= new MySqlDataAdapter(query, conn);
                conn.Open();
                dt = new DataSet();
                ad.Fill(dt, "users");
                dataGridView1.DataSource = dt.Tables["users"];
                dataGridView1.Columns["password"].Visible = false;
                dataGridView1.Columns["id1"].Visible = false;
                dataGridView1.Columns["id2"].Visible = false;
                dataGridView1.Columns["user_id"].Visible = false;
                dataGridView1.Columns["role_id"].Visible = false;
                conn.Close();

            }
            catch (Exception)
            {
            }
        }

        //action when delete button is clicked
        private void btndelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selected_uid = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                //sql query to delete users
                string query = "DELETE from users where id=" + int.Parse(selected_uid);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("User deleted!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Something's wrong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Error connecting to database" + x.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
