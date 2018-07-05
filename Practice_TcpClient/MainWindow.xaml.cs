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

namespace Practice_TcpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> result;

        public MainWindow()
        {
            InitializeComponent();

            tbMessage.Text = "Hello World";
            tbPort.Text = "22222";
            tbServer.Text = "10.1.10.130";
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client cli = new Practice_TcpClient.client(tbServer.Text, Convert.ToInt32(tbPort.Text));

                result = cli.Request(tbMessage.Text);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            if(result != null)
            {
                //MessageBox.Show(result.Count.ToString());
                MessageBox.Show("result = " + result[0]);
            }
            else
            {
                //Do nothing
            }
        }
    }
}
