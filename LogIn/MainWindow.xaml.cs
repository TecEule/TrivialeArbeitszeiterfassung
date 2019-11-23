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
using teLogIn;

namespace LogIn.Gui
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private bool _correctLogIn;
        public bool correctLogIn 
        {
            get
            {
                return _correctLogIn;
            }
        }

        private static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();

                return _instance;
            }
        }
        private MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Anmelden_Click(object sender, RoutedEventArgs e)
        {
            bool correct = checkLogInData(txt_Benutzer.Text.Trim(), txt_Password.Password);

            if (!correct)
                MessageBox.Show("Die von Ihnen eingebenen Daten sind noch korrekt!", "Anmeldung", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                Close();

            _correctLogIn = correct;

        }

        private void btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool checkLogInData(string benutzer, string passwort)
        {
            bool correct = false;

            correct = teLogIn.teLogIn.Instance.checkLogIn(benutzer, passwort);
            
            return correct;
        }
    }
}
