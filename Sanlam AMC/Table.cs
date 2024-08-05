using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Sanlam_AMC
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void Table_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;");
            LoadDataGridView();

        }
        private void FilterDataGridView(string searchValue)
        {
            // Make sure to handle database connection properly
            using (SqlConnection con = new SqlConnection("Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;"))
            {
                try
                {
                    con.Open();

                    string query = "SELECT * FROM Client WHERE Nom LIKE @SearchValue OR Prenom LIKE @SearchValue OR Number LIKE @SearchValue";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SearchValue", $"%{searchValue}%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de la recherche : " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
        private void LoadDataGridView()
        {
            using (SqlConnection con = new SqlConnection("Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;"))
            {
                try
                {
                    con.Open();

                    string query = "SELECT * FROM Client";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors du chargement des données : " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void exportexel()
        {

        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView(txtSearch.Text.Trim());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0)
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "ExportedData";

                try
                {
                    // Adding column headers
                    for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                    }

                    // Adding rows
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                        }
                    }

                    // Save the excel file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FilterIndex = 2
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Export Successful");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    excelApp.Quit();
                    workbook = null;
                    excelApp = null;
                }
            }
            else
            {
                MessageBox.Show("No record to export");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClientPdf clientPdf=new ClientPdf();
            clientPdf.Show();

        }

    }

}
