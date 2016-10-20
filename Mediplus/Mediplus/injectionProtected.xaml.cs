using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Mediplus
{
    /// <summary>
    /// Interaction logic for injectionProtected.xaml
    /// </summary>
    public partial class injectionProtected : UserControl
    {
        public injectionProtected()
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
                    SqlCommand command = new SqlCommand(null, conn);
                    command.CommandText = "SELECT * FROM loginDetails WHERE username = @usrname AND passwd = @passwrd;";
                    SqlParameter usrnameParam = new SqlParameter("@usrname", System.Data.SqlDbType.VarChar,20);
                    SqlParameter passwrdParam = new SqlParameter("@passwrd", System.Data.SqlDbType.VarChar, 20);
                    usrnameParam.Value = username.Text;
                    passwrdParam.Value = password.Text;
                    command.Parameters.Add(usrnameParam);
                    command.Parameters.Add(passwrdParam);
                    command.Prepare();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                        MessageBox.Show("Login successful");
                    else
                        MessageBox.Show("Incorrect username or password");
                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
