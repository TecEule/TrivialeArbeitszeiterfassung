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

    private bool existFile(string fileName)
    {
      bool exists = false;
      string filePath = _filePath + fileName +".json";
      if(Directory.Exists(filePath))
      {
        exists = true;
      }

      return exists;
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



    public T readUserPasswordFromFile<T>(string user, T defaultValue) where T : IConvertible
    {
      T retValue = defaultValue;
      string readValue = string.Empty;

      var accounts = loadFromFile(_filePath);
      readValue = getPasswordFromUser(user, accounts);

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
