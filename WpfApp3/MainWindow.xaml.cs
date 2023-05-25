using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomDBConnection myConnection = new CustomDBConnection();
        
        public MainWindow()
        {
            InitializeComponent();
            myConnection.ConnectionString = @"Data Source=DESKTOP-CSA0P33\SQLEXPRESS;Initial Catalog=FruitsVeg;Integrated Security=True";
            myConnection.Query = @"Select * from Fru_Veg";
            try
            {
                myConnection.Open();
                MessageBox.Show("connection established");
                myConnection.Execute();
                while (myConnection.Read())
                {
                    lbName.Items.Add(myConnection.Reader[1]);
                    lbType.Items.Add(myConnection.Reader[2]);
                    lbColor.Items.Add(myConnection.Reader[3]);
                    lbKK.Items.Add(myConnection.Reader[4]);
                }
            }
            catch
            {
                MessageBox.Show("Connection not established");
            }
            finally
            {
                myConnection.Close();
            }
        }

    }
}
