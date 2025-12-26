using UnityEngine;
//using MySql.Data.MySqlClient;
using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Globalization;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using UnityEngine.Networking;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.Data.SqlClient;

public class Database : MonoBehaviour
{
    public List<string> PingTargets = new List<string>();
    public static List<string> PingTarget = new List<string>();
    public static string url = "https://towerdefense.rs/";
    public static string gamedata = ""; //string amiben a jatekos adatai lesznek, kiveve jelszo email nev, azok kulon
    public static List<string> Usergamedatas = new List<string>();
    public static List<string> UserNames = new List<string>();


    public static float[] Pont = new float[15];

    private void Start()
    {
        for (int i = 0; i < PingTargets.Count; i++)
        {
            PingTarget.Add(PingTargets[i]);
        }
    }

    public static void ertekado()
    {

        gamedata = gamedata.Replace('.', ',');
        string input = gamedata;
        string[] parts = input.Split('|');
        int j = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i] != "")
            {
                Pont[j] = float.Parse(parts[i]);
                j++;
            }
        }


    }
    public static void FillGameDataString()
    {
        string Points = "|0|0,5|0|0|0|0|0|0|0|0|";//MAP[0] = 0; MAP[1] = 0; MAP[2] = 0; MAP[3] = 0; MAP[4] = 0; MAP[5] = 0; MAP[6] = 0; MAP[7] = 0; MAP[8] = 0; MAP[9] = 0;




        gamedata = Points
        ;


        ertekado();

    }

   /* public static void InsertPlayTime(string username, float playtime)
    {
        try
        {
            String username1 = HttpUtility.UrlEncode(username);
            String playtime1 = HttpUtility.UrlEncode(playtime.ToString());


            string response = SendPost(url + "InsertPlayTime.php", String.Format("username={0}&playtime={1}", username1, playtime1));

            Console.WriteLine(response);
        }
        catch (Exception error1)
        {
            //hiba dobas
            Console.WriteLine(error1.Message);
        }
    }*/
    public static void transforms()
    {

        string Points = "|" + Pont[0].ToString() + "|" + Pont[1].ToString() + "|" + Pont[2].ToString() + "|" + Pont[3].ToString() + "|" + Pont[4].ToString() + "|" + Pont[5].ToString() + "|" + Pont[6].ToString() + "|" + Pont[7].ToString() + "|" + Pont[8].ToString() + "|" + Pont[9].ToString() + "|";//MAP[0] = 0; MAP[1] = 0; MAP[2] = 0; MAP[3] = 0; MAP[4] = 0; MAP[5] = 0; MAP[6] = 0; MAP[7] = 0; MAP[8] = 0; MAP[9] = 0;




        gamedata = Points
        ;
    }

    public static IEnumerator CheckInternetConnection1(Action<bool> action, int randomNumber)
    {
        UnityWebRequest request = new UnityWebRequest(PingTarget[randomNumber]);
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log(PingTarget[randomNumber]);
            action(false);
        }
        else
        {
            action(true);
        }
    }
    //MOVED TO PHP !!!!
    public static void UpdateDatabase(string nickname) //itt updatelunk mikor mar regisztralt az ember
    {
        transforms();
        String username1 = HttpUtility.UrlEncode(nickname);
        String gamedata1 = HttpUtility.UrlEncode(gamedata);

        string response = SendPost(url + "BMathInsertUser.php", String.Format("username={0}&gamedata={1}", username1, gamedata1));

    }
    

    //**MOVED TO PHP !!!!
    public static void WriteIntoDatabase(string nickname) //adatbazisba iras
    {
        FajlDatabase.WriteIntoTxtFile();
        WebClient client = new WebClient();
        NameValueCollection UserInfo = new NameValueCollection();
        UserInfo.Add("username", nickname);
        UserInfo.Add("gamedata", gamedata);

        byte[] InsertUser = client.UploadValues(url + "Feltoltes.php", "POST", UserInfo);

        client.Headers.Add("Content-Type", "binary/octet-stream");

    }



    public static List<Tuple<float, string>> ElsoGame = new List<Tuple<float, string>>();
    public static List<Tuple<float, string>> MasodikGame = new List<Tuple<float, string>>();
    public static List<Tuple<float, string>> HarmadikGame = new List<Tuple<float, string>>();
    public static List<Tuple<float, string>> NegyedikGame = new List<Tuple<float, string>>();
    public static List<Tuple<float, string>> OtodikGame = new List<Tuple<float, string>>();
    public static List<Tuple<float, string>> HatodikGame = new List<Tuple<float, string>>();
    //dataList.Add(Tuple.Create(1, "First"));
    //olvasas az adatbazisbol

    //MOVED TO PHP !!!!
    public static void ReadFromDatabase()
    {
        ElsoGame.Clear();
        MasodikGame.Clear();
        HarmadikGame.Clear();
        NegyedikGame.Clear(); ;
        OtodikGame.Clear();
        HatodikGame.Clear();

        string asd = SendPost(url + "BmathSelectAllData.php", String.Format(""));

        Usergamedatas= JsonConvert.DeserializeObject<List<string>>(asd);
        /*for (int i=0; i < Usergamedatas.Count; i++)
        {
            Debug.Log(Usergamedatas[i]);
        }*/

        string asd2 = SendPost(url + "BMathInsertUsername.php", String.Format(""));

        UserNames = JsonConvert.DeserializeObject<List<string>>(asd2);
        /*for (int i = 0; i < UserNames.Count; i++)
        {
            Debug.Log(UserNames[i]);
        }*/

        for(int i=0;i<UserNames.Count;i++)
        {
            ertekadas(UserNames[i], Usergamedatas[i]);
        }
        ElsoGame.Sort();
        //MasodikGame.Sort();
        MasodikGame = MasodikGame.OrderByDescending(x => x).ToList();
        HarmadikGame.Sort();
        NegyedikGame.Sort();
        OtodikGame.Sort();
        HatodikGame.Sort();
    }

    public static void ertekadas(string nev,string gamdata)
    {
        gamdata = gamdata.Replace('.', ',');
        float[] Pont2 = new float[15];
        string input = gamdata;
        string[] parts = input.Split('|');
        int j = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i] != "")
            {
                //Debug.Log(parts[i]);
                Pont2[j] = float.Parse(parts[i]);
                j++;
            }
        }

        ElsoGame.Add(Tuple.Create(Pont2[2], nev));
        MasodikGame.Add(Tuple.Create(Pont2[3], nev));
        HarmadikGame.Add(Tuple.Create(Pont2[4], nev));
        NegyedikGame.Add(Tuple.Create(Pont2[5], nev));
        OtodikGame.Add(Tuple.Create(Pont2[6], nev));
        HatodikGame.Add(Tuple.Create(Pont2[7], nev));

    }

    //torles az adatbazisbol

    //MOVED TO PHP !!!!
    /*public static void DeleteUserFromDB(string nickname, string password)
    {
        try
        {
            String username = HttpUtility.UrlEncode(nickname);
            String password_ = HttpUtility.UrlEncode(password);


            string response = SendPost(url + "DeleteUser.php", String.Format("username={0}&password_={1}", username, password_));

            Console.WriteLine(response);
        }
        catch (Exception error1)
        {
            //hiba dobas
            Console.WriteLine(error1.Message);
        }


    }

    // MOVED TO PHP !!!!
    public static int CheckIfThisExists(string username, string email)
    {
        String username1 = HttpUtility.UrlEncode(username);
        String email1 = HttpUtility.UrlEncode(email);

        string response = SendPost(url + "CheckIfThisExists.php", String.Format("username={0}&email={1}", username1, email1));

        return Convert.ToInt32(response);
    }

    public static void SendComplaint(string content)
    {
        try
        {
            String content1 = HttpUtility.UrlEncode(content);
            String currentime = HttpUtility.UrlEncode(DateTime.UtcNow.ToString());


            string response = SendPost(url + "SendComplaint.php", String.Format("content={0}&timedata={1}", content1, currentime));

        }
        catch (Exception error1)
        {
            //hiba dobas
        }


    }

    // MOVED TO PHP !!!!
    public static void UpdateUserPassword(string nickname, string email, string newpassword)
    {

        String username = HttpUtility.UrlEncode(nickname);
        String newpassword1 = HttpUtility.UrlEncode(newpassword);
        String email1 = HttpUtility.UrlEncode(email);

        string response = SendPost(url + "UpdateUserPassword.php", String.Format("username={0}&newpassword={1}&email={2}", username, newpassword1, email1));

        Console.WriteLine(response);

    }*/


    //MOVED TO PHP !!!!
    public static bool CheckIfThisUserExists(string username)
    {
        String username1 = HttpUtility.UrlEncode(username);

        string response = SendPost(url + "BMathCheckUsername.php", String.Format("username={0}", username1));
        // Console.WriteLine(response);
        if (response == "1")
        {
            return true;
        }
        else
        {
            return false;
        }




    }






    public static string SendPost(string url, string postData)
    {
        string webpageContent = string.Empty;

        try
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;

            using (Stream webpageStream = webRequest.GetRequestStream())
            {
                webpageStream.Write(byteArray, 0, byteArray.Length);
            }

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    webpageContent = reader.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            //throw or return an appropriate response/exception
        }

        return webpageContent;
    }

    /*public static string FetchUsernameThroughEmail(string email)
    {
        String email1 = HttpUtility.UrlEncode(email);


        //The username is stored in this string - ebben a stringben lesz a username
        string username = SendPost(url + "FetchUsernameThroughEmail.php", String.Format("email={0}", email1));

        return username;

    }

    public static string ChangeUsernameThroughOldUsernameAndPassword(string oldname, string password, string newname)
    {
        String oldname1 = HttpUtility.UrlEncode(oldname);
        String newn1 = HttpUtility.UrlEncode(newname);
        String pass1 = HttpUtility.UrlEncode(password);

        //The response is stored in this string - ebben a stringben lesz a valasz
        string username = SendPost(url + "ChangeUsernameThroughOldUsernameAndPassword.php", String.Format("oldname={0}&newname={1}&password={2}", oldname1, newn1, pass1));

        return username;

    }*/
}
