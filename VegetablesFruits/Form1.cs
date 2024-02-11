using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegetablesFruits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string server = textBox1.Text;
            string database = textBox2.Text;

            string connectionString = $@"Data Source={server};Initial Catalog={database};Integrated Security=SSPI";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Подключение успешно установлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 form = new Form2(server, database);
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("Запись успешно добавлена в таблицу!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
