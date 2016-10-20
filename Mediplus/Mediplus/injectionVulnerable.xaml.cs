using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Mediplus
{
    /// <summary>
    /// Interaction logic for injectionVulnerable.xaml
    /// </summary>
    public partial class injectionVulnerable : UserControl
    {
        
        public injectionVulnerable()
        {
            InitializeComponent();
        }

        string connectionString;

        public string setConnString
        {
            set { connectionString = value; }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                    //MessageBox.Show("Connection made");
                    string sql = "SELECT * FROM loginDetails WHERE username = '" + username.Text + "' AND passwd = '" + password.Text + "';";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                        MessageBox.Show("Login successful");
                    else
                        MessageBox.Show("Incorrect username or password");
                    command.Dispose();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}
