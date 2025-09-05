using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace guia1unidad3
{
    public partial class Form1 : Form           
    {
        SqlConnection conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=BookWorld;Trusted_Connection=True;");
        public Form1()
        {
            InitializeComponent();
        }
        private void MostrarRegistros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("SELECT * FROM ventas", conexion);
                DataSet d = new DataSet();
                comando.Fill(d,"ventas");
                dataGridView1.DataSource = d.Tables["ventas"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MessageBox.Show("Conexión exitosa");
            conexion.Close();
            MessageBox.Show("Conexión cerrada");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                    textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO ventas VALUES (@fecha_venta, @cliente,@id_producto,@cantidad," +
                    " @precio_unitario,@tipo_venta,@metodo_pago)", conexion);
                    comando.Parameters.AddWithValue("@fecha_venta", textBox1.Text);
                    comando.Parameters.AddWithValue("@cliente", textBox2.Text);
                    comando.Parameters.AddWithValue("@id_producto", Convert.ToInt32(textBox4.Text));
                    comando.Parameters.AddWithValue("@cantidad", Convert.ToInt32(textBox5.Text));
                    comando.Parameters.AddWithValue("@precio_unitario", Convert.ToDecimal(textBox3.Text));
                    comando.Parameters.AddWithValue("@tipo_venta", comboBox1.Text);
                    comando.Parameters.AddWithValue("@metodo_pago", textBox6.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Agregado exitosamente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
                MostrarRegistros();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                    textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("UPDATE ventas set fecha_venta = @fecha_venta,cliente = @cliente," +
                        "id_producto = @id_producto,cantidad = @cantidad,precio_unitario = @precio_unitario," +
                        "tipo_venta = @tipo_venta,metodo_pago = @metodo_pago WHERE id_venta = @id", conexion);
                    comando.Parameters.AddWithValue("@fecha_venta", textBox1.Text);
                    comando.Parameters.AddWithValue("@cliente", textBox2.Text);
                    comando.Parameters.AddWithValue("@id_producto", Convert.ToInt32(textBox3.Text));
                    comando.Parameters.AddWithValue("@cantidad", Convert.ToInt32(textBox4.Text));
                    comando.Parameters.AddWithValue("@precio_unitario", Convert.ToDecimal(textBox5.Text));
                    comando.Parameters.AddWithValue("@tipo_venta", comboBox1.Text);
                    comando.Parameters.AddWithValue("@metodo_pago", textBox6.Text);
                    comando.Parameters.AddWithValue("@id",textBox7.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Agregado exitosamente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
                MostrarRegistros();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text == "")
                {
                    MessageBox.Show("Por favor, ingresar el codigo.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM ventas WHERE id_venta ="+textBox7.Text, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Eliminado exitosamente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
                MostrarRegistros();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
    }
}

// LAB-A-PC27\SQLEXPRESS