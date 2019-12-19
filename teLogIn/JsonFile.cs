using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teLogIn;


namespace teLogIn
{
  public class JsonFile
  {

    private static JsonFile _instance;
    public static JsonFile Instance
    {
      get
      {
        if (_instance == null)
          _instance = new JsonFile();

        return _instance;
      }
    }


    string _filePath = @"D:\account.json";

    public bool existFile()
    {
      bool exists = false;
      if(File.Exists(_filePath))
      {
        exists = true;
      }

      return exists;
    }

    public void CreateFile(AccountModelView account)
    {
      if(account != null)
      {
        Accounts accounts = new Accounts();

        accounts.Konten = new List<AccountModelView>();
        accounts.Konten.Add(account);

        List<Accounts> list = new List<Accounts>();
        list.Add(accounts);

        string filePath = "";
        using (StreamWriter file = File.CreateText(_filePath))
        {
          JsonSerializer serializer = new JsonSerializer();
          //serialize object directly into file stream
          serializer.Serialize(file, list);
        }
      }
    }

    private List<Accounts> loadFromFile(string filePath)
    {
      List<Accounts> list;
      using (StreamReader sr = new StreamReader(filePath))
      {
        string file = sr.ReadToEnd();
        list = JsonConvert.DeserializeObject<List<Accounts>>(file);
      }

      return list;
    }

    private string getPasswordFromUser(string user, List<Accounts> accounts)
    {
      string pw = string.Empty;
     
      foreach (AccountModelView item in accounts[0].Konten)
      {
        if(item.Username.Equals(user))
        {
          pw = item.Password;
          break;
        }
      }
      return pw;
    }



    public T readUserPasswordFromFile<T>(string user,string key, T defaultValue) where T : IConvertible
    {
      T retValue = defaultValue;
      string readValue = string.Empty;

      var accounts = loadFromFile(_filePath);
      readValue = getPasswordFromUser(user, accounts);

      readValue = teCrypt.Instance.DecryptString(readValue, key);

      try
      {
         retValue = (T)Convert.ChangeType(readValue, typeof(T));
      }
      catch(InvalidCastException invalidCastException)
      {

      }
      catch(Exception ex)
      {

      }
      


      return retValue;
    }



  }



}
