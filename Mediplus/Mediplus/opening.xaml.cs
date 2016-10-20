using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mediplus
{
    /// <summary>
    /// Interaction logic for opening.xaml
    /// </summary>
    public partial class opening : UserControl
    {
        public opening()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source = SHUBHAM-PC; Initial Catalog = mediplusFC; Integrated Security=true;";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            injectionVulnerable injvul = new injectionVulnerable();
            injvul.setConnString = connectionString;
            injectionProtected injpro = new injectionProtected();
            injpro.setConnString = connectionString;
            if (btn.Name == "vul")    
                (this.Parent as Grid).Children.Add(injvul);
            else
                (this.Parent as Grid).Children.Add(injpro);
        }

        private void saveString_Click(object sender, RoutedEventArgs e)
        {
            connectionString = connectStringInput.Text;
        }
    }
      
}
