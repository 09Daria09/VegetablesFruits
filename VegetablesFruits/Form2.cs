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
    public partial class Form2 : Form
    {
        string Server = null;
        string DatabaseName = null;
        public Form2(string server, string databaseName)
        {
            this.Server = server;
            this.DatabaseName = databaseName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Fruits_Vegetables";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Name FROM Fruits_Vegetables";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT DISTINCT Color FROM Fruits_Vegetables";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1 * FROM Fruits_Vegetables ORDER BY Calories DESC";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt; 
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1 * FROM Fruits_Vegetables ORDER BY Calories ASC";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = @"
SELECT TOP 1 *, ABS(Calories - (SELECT AVG(Calories) FROM Fruits_Vegetables)) AS Difference
FROM Fruits_Vegetables
ORDER BY Difference ASC";
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt; 
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT COUNT(*) FROM Fruits_Vegetables WHERE Type = 'Овощ'";
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show($"Количество овощей: {result}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT COUNT(*) FROM Fruits_Vegetables WHERE Type = 'Фрукт'";
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show($"Количество фруктов: {result}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string selectedColor = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(selectedColor))
            {
                MessageBox.Show("Пожалуйста, введите цвет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Type, COUNT(*) AS Quantity FROM Fruits_Vegetables WHERE Color = @Color GROUP BY Type";
                command.Parameters.AddWithValue("@Color", selectedColor);

                SqlDataReader reader = command.ExecuteReader();
                string message = "";
                bool hasResults = false; 

                while (reader.Read())
                {
                    hasResults = true; 
                    message += $"{reader["Type"]}: {reader["Quantity"]}\n";
                }

                if (!hasResults)
                {
                    MessageBox.Show($"Продукты заданного цвета '{selectedColor}' не найдены.", "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(message, "Количество по цвету", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
                textBox1.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = @"
            SELECT Type, Color, COUNT(*) AS Quantity
            FROM Fruits_Vegetables
            GROUP BY Type, Color
            ORDER BY Type, Color";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connect != null && connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                command.Dispose();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int maxCalories))
            {
                MessageBox.Show("Введите корректное значение калорийности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Fruits_Vegetables WHERE Calories < @MaxCalories ORDER BY Type, Calories";
                command.Parameters.AddWithValue("@MaxCalories", maxCalories);

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (connect != null && connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out int minCalories))
            {
                MessageBox.Show("Введите корректное значение калорийности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Fruits_Vegetables WHERE Calories > @MinCalories ORDER BY Type, Calories";
                command.Parameters.AddWithValue("@MinCalories", minCalories);

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt; 
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (connect != null && connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox4.Text, out int minCalories) || !int.TryParse(textBox5.Text, out int maxCalories))
            {
                MessageBox.Show("Введите корректные значения калорийности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (minCalories > maxCalories)
            {
                MessageBox.Show("Минимальная калорийность не может быть больше максимальной.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection connect = new SqlConnection($@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Fruits_Vegetables WHERE Calories >= @MinCalories AND Calories <= @MaxCalories ORDER BY Type, Calories";
                command.Parameters.AddWithValue("@MinCalories", minCalories);
                command.Parameters.AddWithValue("@MaxCalories", maxCalories);

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt; 
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (connect != null && connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string selectedColor = comboBox1.SelectedItem.ToString();

            string connectionString = $@"Data Source={Server};Initial Catalog={DatabaseName};Integrated Security=SSPI";
            SqlConnection connect = null;
            SqlCommand command = null;
            SqlDataAdapter adapter = null;
            DataTable dataTable = new DataTable();

            try
            {
                connect = new SqlConnection(connectionString);
                connect.Open();
                command = new SqlCommand($"SELECT * FROM Fruits_Vegetables WHERE Color = @Color ORDER BY Type, Color", connect);
                command.Parameters.AddWithValue("@Color", selectedColor);

                adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connect != null)
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                    connect.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
        }

    }
}

