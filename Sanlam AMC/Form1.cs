using System;
using System.Data.SqlClient;

namespace Sanlam_AMC
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source=Bankai\\SQLEXPRESS;Initial Catalog=AMC;Integrated Security=True;");
            con.Open();
            String query = "INSERT INTO Client VALUES (@Number, @DateCreation, @Montant, @Nom, @Prenom,@CINouPPR, @Employeur, @Police, @Adresse, @Quartier, @CodePostal, @RIP,@Banque,@Agence,@DateConsultation, @DateDepot, @Beneficiaire)";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@Number", txtNum.Text);
            cmd.Parameters.AddWithValue("@DateCreation", date1.Value); 
            cmd.Parameters.AddWithValue("@Montant", Convert.ToDouble(txtMontant.Text));
            cmd.Parameters.AddWithValue("@Nom", txtNom.Text);
            cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text);
            cmd.Parameters.AddWithValue("@CINouPPR", txtcinppr.Text);
            cmd.Parameters.AddWithValue("@Employeur", txtemp.Text);
            cmd.Parameters.AddWithValue("@Police", txtpolice.Text);
            cmd.Parameters.AddWithValue("@Adresse", txtadess.Text);
            cmd.Parameters.AddWithValue("@Quartier", txtquartier.Text);
            cmd.Parameters.AddWithValue("@CodePostal", txtcodepostal.Text);
            cmd.Parameters.AddWithValue("@RIP", txtRIP.Text);
            cmd.Parameters.AddWithValue("@Banque", txtBanque.Text);
            cmd.Parameters.AddWithValue("@Agence", txtagence.Text);
            cmd.Parameters.AddWithValue("@DateConsultation", dateConsultation.Value);
            cmd.Parameters.AddWithValue("@DateDepot", datedepot.Value);
            cmd.Parameters.AddWithValue("@Beneficiaire", txtbeneficiaire.Text);
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rowsAffected} row(s) inserted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Succes");
            con.Close();*/

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string checkPrimaryKeyQuery = "SELECT COUNT(1) FROM Client WHERE Number = @Number";
                    using (SqlCommand checkPrimaryKeyCmd = new SqlCommand(checkPrimaryKeyQuery, con))
                    {
                        checkPrimaryKeyCmd.Parameters.AddWithValue("@Number", txtNumero.Text);
                        int primaryKeyExists = (int)checkPrimaryKeyCmd.ExecuteScalar();

                        if (primaryKeyExists > 0)
                        {
                            MessageBox.Show("Le numéro existe déjà.");
                            return;
                        }
                    }

                    // Check if the unique key already exists
                    string checkUniqueKeyQuery = "SELECT COUNT(1) FROM Client WHERE RIP = @RIP";
                    using (SqlCommand checkUniqueKeyCmd = new SqlCommand(checkUniqueKeyQuery, con))
                    {
                        checkUniqueKeyCmd.Parameters.AddWithValue("@RIP", txtRIP.Text);
                        int uniqueKeyExists = (int)checkUniqueKeyCmd.ExecuteScalar();

                        if (uniqueKeyExists > 0)
                        {
                            MessageBox.Show("Le RIP existe déjà.");
                            return;
                        }
                    }

                    string query = @"INSERT INTO Client (Number, DateCreation, Montant, Nom, Prenom, CINouPPR, Employeur, Police, Adresse, Quartier, CodePostal, RIP, Banque, Agence, DateConsultation, DateDepot, Beneficiaire)
                                     VALUES (@Number, @DateCreation, @Montant, @Nom, @Prenom, @CINouPPR, @Employeur, @Police, @Adresse, @Quartier, @CodePostal, @RIP, @Banque, @Agence, @DateConsultation, @DateDepot, @Beneficiaire)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Number", txtNumero.Text);
                        cmd.Parameters.AddWithValue("@DateCreation", date1.Value);
                        cmd.Parameters.AddWithValue("@Montant", Convert.ToDouble(txtMontant.Text));
                        cmd.Parameters.AddWithValue("@Nom", txtNom.Text);
                        cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text);
                        cmd.Parameters.AddWithValue("@CINouPPR", txtcinppr.Text);
                        cmd.Parameters.AddWithValue("@Employeur", txtemp.Text);
                        cmd.Parameters.AddWithValue("@Police", txtpolice.Text);
                        cmd.Parameters.AddWithValue("@Adresse", txtadess.Text);
                        cmd.Parameters.AddWithValue("@Quartier", txtquartier.Text);
                        cmd.Parameters.AddWithValue("@CodePostal", txtcodepostal.Text);
                        cmd.Parameters.AddWithValue("@RIP", txtRIP.Text);
                        cmd.Parameters.AddWithValue("@Banque", txtBanque.Text);
                        cmd.Parameters.AddWithValue("@Agence", txtagence.Text);
                        cmd.Parameters.AddWithValue("@DateConsultation", dateConsultation.Value);
                        cmd.Parameters.AddWithValue("@DateDepot", datedepot.Value);
                        cmd.Parameters.AddWithValue("@Beneficiaire", txtbeneficiaire.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) inserted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                    txtNom.Clear();
                    txtPrenom.Clear();
                    txtcinppr.Clear();
                    txtemp.Clear();
                    txtpolice.Clear();
                    txtadess.Clear();
                    txtquartier.Clear();
                    txtcodepostal.Clear();
                    txtRIP.Clear();
                    txtBanque.Clear();
                    txtagence.Clear();
                    txtbeneficiaire.Clear();

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            table.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
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
                        cmd.Parameters.AddWithValue("@Number", txtNumero.Text);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtNom.Text = reader["Nom"].ToString();
                            txtPrenom.Text = reader["Prenom"].ToString();
                            txtcinppr.Text = reader["CINouPPR"].ToString();
                            txtemp.Text = reader["Employeur"].ToString();
                            txtpolice.Text = reader["Police"].ToString();
                            txtadess.Text = reader["Adresse"].ToString();
                            txtquartier.Text = reader["Quartier"].ToString();
                            txtcodepostal.Text = reader["CodePostal"].ToString();
                            txtRIP.Text = reader["RIP"].ToString();
                            txtBanque.Text = reader["Banque"].ToString();
                            txtagence.Text = reader["Agence"].ToString();
                            txtMontant.Text = reader["Montant"].ToString();
                            if (reader["DateCreation"] != DBNull.Value)
                                date1.Value = Convert.ToDateTime(reader["DateCreation"]);
                            if (reader["DateConsultation"] != DBNull.Value)
                                dateConsultation.Value = Convert.ToDateTime(reader["DateConsultation"]);
                            if (reader["DateDepot"] != DBNull.Value)
                                datedepot.Value = Convert.ToDateTime(reader["DateDepot"]);

                            txtbeneficiaire.Text = reader["Beneficiaire"].ToString();
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

        private void btnmodif_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"UPDATE Client 
                             SET DateCreation = @DateCreation, Montant = @Montant, Nom = @Nom, Prenom = @Prenom, CINouPPR = @CINouPPR, 
                                 Employeur = @Employeur, Police = @Police, Adresse = @Adresse, Quartier = @Quartier, CodePostal = @CodePostal, 
                                 RIP = @RIP, Banque = @Banque, Agence = @Agence, DateConsultation = @DateConsultation, DateDepot = @DateDepot, 
                                 Beneficiaire = @Beneficiaire
                             WHERE Number = @Number";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Number", txtNumero.Text);
                        cmd.Parameters.AddWithValue("@DateCreation", date1.Value);
                        cmd.Parameters.AddWithValue("@Montant", Convert.ToDouble(txtMontant.Text));
                        cmd.Parameters.AddWithValue("@Nom", txtNom.Text);
                        cmd.Parameters.AddWithValue("@Prenom", txtPrenom.Text);
                        cmd.Parameters.AddWithValue("@CINouPPR", txtcinppr.Text);
                        cmd.Parameters.AddWithValue("@Employeur", txtemp.Text);
                        cmd.Parameters.AddWithValue("@Police", txtpolice.Text);
                        cmd.Parameters.AddWithValue("@Adresse", txtadess.Text);
                        cmd.Parameters.AddWithValue("@Quartier", txtquartier.Text);
                        cmd.Parameters.AddWithValue("@CodePostal", txtcodepostal.Text);
                        cmd.Parameters.AddWithValue("@RIP", txtRIP.Text);
                        cmd.Parameters.AddWithValue("@Banque", txtBanque.Text);
                        cmd.Parameters.AddWithValue("@Agence", txtagence.Text);
                        cmd.Parameters.AddWithValue("@DateConsultation", dateConsultation.Value);
                        cmd.Parameters.AddWithValue("@DateDepot", datedepot.Value);
                        cmd.Parameters.AddWithValue("@Beneficiaire", txtbeneficiaire.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record found to update.");
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

        private void btnVider_Click(object sender, EventArgs e)
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtcinppr.Clear();
            txtemp.Clear();
            txtpolice.Clear();
            txtadess.Clear();
            txtquartier.Clear();
            txtcodepostal.Clear();
            txtRIP.Clear();
            txtBanque.Clear();
            txtagence.Clear();
            txtbeneficiaire.Clear();
            txtNumero.Clear();
            txtMontant.Clear();
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Client WHERE Number = @Number";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Number", txtNumero.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                            txtNumero.Clear();

                        }
                        else
                        {
                            MessageBox.Show("No record found to delete.");
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
                    txtNom.Clear();
                    txtPrenom.Clear();
                    txtcinppr.Clear();
                    txtemp.Clear();
                    txtpolice.Clear();
                    txtadess.Clear();
                    txtquartier.Clear();
                    txtcodepostal.Clear();
                    txtRIP.Clear();
                    txtBanque.Clear();
                    txtagence.Clear();
                    txtbeneficiaire.Clear();
                    txtMontant.Clear();

                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
