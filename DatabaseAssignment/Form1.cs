using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAssignment
{
    public partial class Form1 : Form
    {
        DBConnection db;
        System.Data.DataSet ds;
        System.Data.DataRow dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String search = textBox1.Text;
            int flag = 0;
            for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                dr = ds.Tables[0].Rows[i];
                String title=dr.ItemArray.GetValue(1).ToString();
                String Author= dr.ItemArray.GetValue(2).ToString();
                String Publisher= dr.ItemArray.GetValue(3).ToString();
                
                if (title==search)
                {
                    String result = "title = " + title + "\n Author = " + Author + "\n Publisher = " + Publisher;
                    MessageBox.Show(result);
                    flag = 1;return;
                }
            }
            if(flag==0)
            {
                MessageBox.Show("Entered Book is not Available");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String title = textBox2.Text;
            String Author = textBox3.Text;
            String Publisher = textBox4.Text;
            dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1];
            String index= dr.ItemArray.GetValue(0).ToString();
            int ind= int.Parse(index);
            ind += 1;

            object[] values = { ind,title, Author, Publisher };
            ds.Tables[0].Rows.Add(values);
            listBox1.Items.Clear();
            //db.UpdateDatabase(ds);
            MessageBox.Show("Book added successfully");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(" id \t\t title \t\t Author \t\t Publisher");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                String index= dr.ItemArray.GetValue(0).ToString();
                String title = dr.ItemArray.GetValue(1).ToString();
                String Author = dr.ItemArray.GetValue(2).ToString();
                String Publisher = dr.ItemArray.GetValue(3).ToString();
                    String result =  index+"\t"+title + "\t" + Author + "\t" + Publisher;
                    listBox1.Items.Add(result);
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String deleteposition = textBox5.Text;
            int pos = int.Parse(deleteposition);
            if(pos<0||pos>=ds.Tables[0].Rows.Count)
            {
                MessageBox.Show("Enter a valid position between 0 and " + (ds.Tables[0].Rows.Count - 1));
                return;
            }
            ds.Tables[0].Rows.RemoveAt(pos);
            //db.UpdateDatabase(ds);
            listBox1.Items.Clear();
            MessageBox.Show("Book removed successfully");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new DBConnection();
            db.ConnectionString = Properties.Settings.Default.ConnectionString;
            db.SqlString = Properties.Settings.Default.SQL;
            ds = db.getConnection;

        }
    }
}
