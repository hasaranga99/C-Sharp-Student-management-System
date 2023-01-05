using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud
{
    public partial class Form1 : Form
    {
        Database db = new Database();
        string stid;
        string stname;
        DateTime dob;
        int age;
        int tp;

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetData("select * from work2");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            age = DateTime.Today.Year - dateTimePicker1.Value.Year;
            txt_age.Text = age.ToString();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                stid = txt_id.Text;
                stname = txt_name.Text;
                dob = dateTimePicker1.Value;
                age = Convert.ToInt32(txt_age.Text);
                tp = Convert.ToInt32(txt_tele.Text);
                string query = "insert into work2 values('" + stid + "','" + stname + "','" + dob + "','" + age + "','" + tp + "')";
                int line = db.save_del_update(query);
                if (line == 1)
                {
                    MessageBox.Show("Data inserted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data not inserted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check the fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                stid = txt_id.Text;
                stname = txt_name.Text;
                dob = dateTimePicker1.Value;
                age = Convert.ToInt32(txt_age.Text);
                tp = Convert.ToInt32(txt_tele.Text);

                DialogResult dr = MessageBox.Show("Do you want to update the select rows?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr.ToString() == "Yes")
                {
                    stid = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    string query = "update work2 set st_name = '" + stname + "',st_dob = '" + dob + "',st_age = '" + age + "',st_tele = '" + tp + "' where st_id = '" + stid + "'";
                    int line = db.save_del_update(query);
                    if (line == 1)
                    {
                        MessageBox.Show("Data updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data not updated ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check the fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_age.Clear();
            txt_tele.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells["st_id"].Value.ToString();
            txt_name.Text = dataGridView1.CurrentRow.Cells["st_name"].Value.ToString();

            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["st_dob"].Value.ToString();

            txt_age.Text = dataGridView1.CurrentRow.Cells["st_age"].Value.ToString();
            txt_tele.Text = dataGridView1.CurrentRow.Cells["st_tele"].Value.ToString();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete the select rows?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr.ToString() == "Yes")
                {
                    stid = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    string query = "delete from work2 where st_id = '" + stid + "'";
                    int line = db.save_del_update(query);
                    if (line == 1)
                    {
                        MessageBox.Show("Data delete successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data not deleted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check the fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_idSearch.Text.Length > 0)
                {
                    if (rd_id.Checked == true)
                    {
                        dataGridView1.DataSource = db.GetData("select * from work2 where st_id = '" + txt_idSearch.Text + "'");
                    }

                }
                if (txt_nameSearch.Text.Length > 0)
                {

                    if (rd_name.Checked == true)
                    {
                        dataGridView1.DataSource = db.GetData("select * from work2 where st_name = '" + txt_nameSearch.Text + "'");
                    }
                }
                else
                {
                    dataGridView1.DataSource = db.GetData("select * from work2");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Please check the fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    
}

