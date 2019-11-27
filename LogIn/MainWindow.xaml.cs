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

    /// <summary>
    /// Default Constructor
    /// </summary>
    private MainWindow()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Was passieren soll wenn der Anmelde-Button gedrückt wird
    /// Die Daten werden überprüft
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btn_Anmelden_Click(object sender, RoutedEventArgs e)
    {
      bool correct = checkLogInData(txt_Benutzer.Text.Trim(), txt_Password.Password);

      if (!correct)
        MessageBox.Show("Die von Ihnen eingebenen Daten sind noch korrekt!", "Anmeldung", MessageBoxButton.OK, MessageBoxImage.Error);
      else
        Close();

      _correctLogIn = correct;

    }

    /// <summary>
    /// Die Anmeldeversuch wird abgebrochen und die Anwendung wird geschlossen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btn_Abbruch_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Überprüfung ob die eingebenen Daten stimmen
    /// </summary>
    /// <param name="benutzer"></param>
    /// <param name="passwort"></param>
    /// <returns></returns>
    private bool checkLogInData(string benutzer, string passwort)
    {
      bool correct = false;

      correct = teLogIn.teLogIn.Instance.checkLogIn(benutzer, passwort);

      return correct;
    }
  }
}
