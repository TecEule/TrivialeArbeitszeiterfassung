using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace teLogIn
{
  public class teCrypt
  {

    private static teCrypt _instance;
    public static teCrypt Instance
    {
      get
      {
        if (_instance == null)
          _instance = new teCrypt();

        return _instance;
      }
    }

    private byte[] doExtendKey(string key, int newKeyLength)
    {
      byte[] bkey = new byte[newKeyLength];
      byte[] tmpKey = Encoding.UTF8.GetBytes(key);

      for (int i = 0; i < key.Length; i++)
      {
        bkey[i] = tmpKey[i];
      }

      return bkey;
    }

    private byte[] doCreateBlockSize(int newBlockSize)
    {
      byte[] block = new byte[newBlockSize];

      for (byte i = 0; i < newBlockSize; i++)
      {
        block[i] = i;
      }

      return block;
    }


    public string EncryptString(string klarText, string key)
    {
      string chiffre = string.Empty;

      Aes AESCrypto = Aes.Create();
      //AESCrypto.Padding = PaddingMode.Zeros;
      AESCrypto.Key = doExtendKey(key, 32);
      AESCrypto.IV = doCreateBlockSize(16);

      MemoryStream mStream = new MemoryStream();
      CryptoStream cStream = new CryptoStream(mStream, AESCrypto.CreateEncryptor(), CryptoStreamMode.Write);

      byte[] plainBytes = Encoding.UTF8.GetBytes(klarText);
      cStream.Write(plainBytes, 0, plainBytes.Length);
      cStream.FlushFinalBlock();

      byte[] EncryptedBytes = mStream.ToArray();
      chiffre = Convert.ToBase64String(EncryptedBytes);

      mStream.Close();
      cStream.Close();

      return chiffre;
    }

    public string DecryptString(string chiffre, string key)
    {
      string plaintext = string.Empty;

      Aes AESCrypto = Aes.Create();
      //AESCrypto.Padding = PaddingMode.Zeros;
      AESCrypto.Key = doExtendKey(key, 32);
      AESCrypto.IV = doCreateBlockSize(16);

      MemoryStream mStream = new MemoryStream();
      CryptoStream cStream = new CryptoStream(mStream, AESCrypto.CreateDecryptor(), CryptoStreamMode.Write);

      try
      {
        byte[] encryptedBytes = Convert.FromBase64String(chiffre);
        cStream.Write(encryptedBytes, 0, encryptedBytes.Length);
        cStream.FlushFinalBlock();

        byte[] plainBytes = mStream.ToArray();
        plaintext = Encoding.UTF8.GetString(plainBytes);
      }
      catch (Exception ex)
      {
        //cStream.FlushFinalBlock();
      }
      finally
      {
        mStream.Close();
        //cStream.Close();
      }

      return plaintext;
    }
  }
}
