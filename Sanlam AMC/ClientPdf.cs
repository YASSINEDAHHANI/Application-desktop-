using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Exceptions;

namespace Sanlam_AMC
{
    public partial class ClientPdf : Form
    {
        public ClientPdf()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Client WHERE Number = @Number";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Number", Num.Text);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            cinouppr.Text = reader["CINouPPR"].ToString();
                            frais.Text = reader["Montant"].ToString();
                            if (reader["DateCreation"] != DBNull.Value)
                                date.Value = Convert.ToDateTime(reader["DateCreation"]);
                        }
                        else
                        {
                            MessageBox.Show("No record found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = Num.Text.Trim();
            float montantDesFrais = float.Parse(frais.Text.Trim());
            string convention = Conv.Text.Trim();
            string typeDossier = type.Text.Trim();
            DateTime date = dateSoins.Value;

            // Save data to database
            using (SqlConnection con = new SqlConnection("Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;"))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO ClientFile (Number, MontantDesFrais, Convention, TypeDossier, DateSoins) VALUES (@Number, @MontantDesFrais, @Convention, @TypeDossier, @DateSoins)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Number", number);
                    cmd.Parameters.AddWithValue("@MontantDesFrais", montantDesFrais);
                    cmd.Parameters.AddWithValue("@Convention", convention);
                    cmd.Parameters.AddWithValue("@TypeDossier", typeDossier);
                    cmd.Parameters.AddWithValue("@DateSoins", date);
                    cmd.ExecuteNonQuery();

                    // Notify the user
                    MessageBox.Show("Data saved successfully.");

                    // Generate PDF
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "PDF files (*.pdf)|*.pdf",
                        FilterIndex = 2
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        GeneratePDF(filePath, number, montantDesFrais, convention, typeDossier, date);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void GeneratePDF(string filePath, string number, float montantDesFrais, string convention, string typeDossier, DateTime date)
        {
            try
            {
                // Check if the file path is valid
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("File path is empty or null.");
                    return;
                }

                string directory = System.IO.Path.GetDirectoryName(filePath);
                if (!System.IO.Directory.Exists(directory))
                {
                    MessageBox.Show("Directory does not exist: " + directory);
                    return;
                }

                // Generate the PDF
                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    document.SetFont(font);

                    // Add Title
                    Paragraph title = new Paragraph("Client File Information")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20);
                    document.Add(title);

                    // Add Information
                    document.Add(new Paragraph("Number: " + number));
                    document.Add(new Paragraph("Montant des Frais: " + montantDesFrais));
                    document.Add(new Paragraph("Convention: " + convention));
                    document.Add(new Paragraph("Type Dossier: " + typeDossier));
                    document.Add(new Paragraph("Date Soins: " + date.ToString("d")));
                }

                MessageBox.Show("PDF Exported Successfully.");
            }
            catch (PdfException ex)
            {
                MessageBox.Show("An error occurred while generating the PDF: " + ex.Message + "\nStack Trace: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error occurred: " + ex.Message + "\nStack Trace: " + ex.StackTrace);
            }
        }
    }
}
