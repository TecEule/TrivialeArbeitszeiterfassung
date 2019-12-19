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
using System.Windows.Shapes;
using teLogIn;

namespace LogIn
{
  /// <summary>
  /// Interaction logic for FirstLogin.xaml
  /// </summary>
  public partial class FirstLogin : Window
  {
    public FirstLogin()
    {
      InitializeComponent();
    }

    private void btn_Cancel_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = false;
      Close();
    }

    private void btn_Register_Click(object sender, RoutedEventArgs e)
    {
      AccountModelView account = new AccountModelView();
      account.Username = txt_User.Text;
      account.Password = teCrypt.Instance.EncryptString(txt_Password.Text, txt_Key.Text);



      teLogIn.JsonFile.Instance.CreateFile(account);

      this.DialogResult = true; 
      Close();
    }
  }
}
