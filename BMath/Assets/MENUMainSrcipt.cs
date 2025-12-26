using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using System.IO;
using TMPro;

public class MENUMainSrcipt : MonoBehaviour
{
    public static string username = "";
    public GameObject masodMENUPanel;
    public GameObject SettingPanel;
    public List<GameObject> Nevvalasztasraszukseges;
    public List<GameObject> MasodMenuhezszuksegesdolgok;
    public List<GameObject> SettingsMindeneleme;
    public GameObject Nevtabla;
    public GameObject indulas, kozep, rendeshely;
    public TMP_Text wrongUsernameTXT, UsernameKiiratasa;
    public GameObject WrongTextUzenet;
    public GameObject Usernameee;
    public Slider Hangallitas;
    public static Slider Hangallitas2;
    public AudioClip Zene;
    public static AudioClip Zene2;
    public static AudioSource Hang;
    public static bool Wifi = false, adatoklekerve = false,mostani=false;
    private float WifiCheckTime = 0, maxTime = 2,retrycheck=30,retryTimercheck=0;
    public GameObject NowWifiPanel;
    public GameObject LoadingingFrissites;

    public string Radicals = "Radicalsssss";
    public GameObject RadicalsMenu;
    public GameObject RadicalsLeaderboardPanel;
    public TMP_Dropdown DropDown;

    public string RLeaderboard = "Leaderboard____________";
    public GameObject PlacePrefab;
    public GameObject Leaderboard;
    public GameObject teteje, alja;
    private List<GameObject> Prefabs = new List<GameObject>();
    public Sprite FirsPlaceTrofea;
    private float jelenlegi=0;
    public static float elozoClick = 0;
    private bool LeaderBoarMegnyitasa = true;
    private GameObject sajat;
    private int sajathelyezes = 0;
    public Color Sotetites;
    public string RLeaderboard2 = "Leaderboard____________";

    public string Radicalss = "EndRadicalsssss";

    void Start()
    {
        //FajlDatabase.DeleteFile();
        Zene2 = Zene;
        Hangallitas2 = Hangallitas;
        if (masodMENUPanel.active)
        {
            masodMENUPanel.SetActive(false);
        }
        if (SettingPanel.active)
        {
            SettingPanel.SetActive(false);
        }
        fajlbolkiolvasniazadatokathavan();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Wifi);
        if (!Wifi|| !mostani)
        {
            if (WifiCheckTime > maxTime)
            {
                WifiCheckTime = 0;
                int r = Random.Range(0, Database.PingTarget.Count);
                StartCoroutine(Database.CheckInternetConnection1(isConnected =>
                {
                    Wifi = isConnected;
                }, r));
                //Debug.Log(Wifi);
                    StartCoroutine(Wifinezo());
            }
            else
            {
                WifiCheckTime += Time.deltaTime;
            }
        }
        else
        {
            if(retryTimercheck<retrycheck)
            {
                retryTimercheck += Time.deltaTime;
            }
            else
            {
                //Debug.Log("Megteltttt");
                Wifi = false;
                retryTimercheck = 0;
            }
        }
        if(LeaderBoardPlacesSript.mozoghate)
        {

            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            jelenlegi = elozoClick - click.y;
            Vector2 dir;
            dir.x = 0;
            dir.y = -jelenlegi;
            if(Leaderboard.transform.position.y<=teteje.transform.position.y&&jelenlegi>0)
            {
                Leaderboard.transform.position = teteje.transform.position;
                igazitas();
                return;
            }
            else
              if (Leaderboard.transform.position.y-Prefabs.Count*1.25f >= alja.transform.position.y && jelenlegi < 0)
            {
                igazitas();
                return;
            }
            Leaderboard.transform.Translate(dir.normalized * Mathf.Abs(jelenlegi*10) * Time.deltaTime / 3, Space.World);
            if (jelenlegi < 0)
            {
                float ertek = Leaderboard.transform.position.y;
                ertek -= teteje.transform.position.y;
                int ertek2 = (int)Mathf.Ceil(ertek / (1.25f));
                if(ertek2>0)
                    Prefabs[ertek2-1].SetActive(false);
            }
            else
            if (jelenlegi > 0)
            {
                float ertek = Leaderboard.transform.position.y;
                ertek -= teteje.transform.position.y;
                int ertek2 = (int)Mathf.Ceil(ertek / (1.25f));
                Prefabs[ertek2].SetActive(true);
            }
            igazitas();
        }
        else
        {
            elozoClick = 0;
        }
    }

    IEnumerator Wifinezo()
    {
        yield return new WaitForSeconds(2f);
        //Debug.Log(Wifi);
        if (Wifi)
        {
            //Debug.Log(FajlDatabase.username);
            if (FajlDatabase.username != "")
            {
                //Debug.Log("Most");
                if(Database.Pont[8]==0)
                {
                    //Debug.Log("Update");
                    Database.Pont[8] = 1;
                    FajlDatabase.WriteIntoTxtFile();
                    Database.UpdateDatabase(FajlDatabase.username);
                }
                else
                {
                    //Debug.Log("frissites");
                    Database.WriteIntoDatabase(FajlDatabase.username);
                }
                mostani = true;
            }
            if (!adatoklekerve)
            {
                AdatokLekerese();
            }
        }
    }
    public void LeaderboardFrissites()
    {
        StartCoroutine(Frissites(2));
    }
    IEnumerator Frissites(float a)
    {
        int r = Random.Range(0, Database.PingTarget.Count);
        StartCoroutine(Database.CheckInternetConnection1(isConnected =>
        {
            Wifi = isConnected;
        }, r));
        float Timer=0;
        while(Timer<a)
        {
            LoadingingFrissites.transform.rotation = Quaternion.Euler(LoadingingFrissites.transform.rotation.x, LoadingingFrissites.transform.rotation.y, Timer * 360);
            yield return Timer += Time.deltaTime;
        }
        //Debug.Log("111- "+Wifi);
        if (Wifi)
        {
            Database.WriteIntoDatabase(FajlDatabase.username);
            AdatokLekerese();
            RanglistaKerelem();
        }
        else
        {
            StartCoroutine(NoWifi());
        }
        /*yield return new WaitForSeconds(1);
        Debug.Log("2222- "+Wifi);*/
    }
    public void AdatokLekerese()
    {
        //Debug.Log("Le van kerve");
        adatoklekerve = true;

        Database.ReadFromDatabase();
    }
    public void startButton()
    {
        if (username != "")
        {
            UsernameKiiratasa.text = username;
            StartCoroutine(Move(0.8f, Nevtabla,indulas.transform.position,rendeshely.transform.position));
            for(int i=0;i< Nevvalasztasraszukseges.Count;i++)
            {
                Nevvalasztasraszukseges[i].SetActive(false);
            }
            for (int i = 0; i < MasodMenuhezszuksegesdolgok.Count; i++)
            {
                MasodMenuhezszuksegesdolgok[i].SetActive(true);
            }
            masodMENUPanel.SetActive(true);
        }
        else
        {
            StartCoroutine(Move(0.8f, Nevtabla, indulas.transform.position, kozep.transform.position));
            for (int i = 0; i < Nevvalasztasraszukseges.Count; i++)
            {
                Nevvalasztasraszukseges[i].SetActive(true);
            }
            for (int i = 0; i < MasodMenuhezszuksegesdolgok.Count; i++)
            {
                MasodMenuhezszuksegesdolgok[i].SetActive(false);
            }
            masodMENUPanel.SetActive(true);
        }
    }
    public void Exit()
    {
        FajlDatabase.WriteIntoTxtFile();
        //#if UNITY_STANDALONE
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void fajlbolkiolvasniazadatokathavan()
    {
        try
        {
            //FajlDatabase.DeleteFile();
            if (File.Exists(FajlDatabase.FilePath.ToString()))
            {
                string[] lines = FajlDatabase.ReadDataFromFile();
                Database.gamedata = lines[1];
                username = lines[2];
                FajlDatabase.password = lines[3];
                FajlDatabase.username = username;
                Database.ertekado();
                Debug.Log(Database.gamedata);
                return;
            }
            else
            {
                Database.FillGameDataString();
            }
        }
        catch
        {
            FajlDatabase.start();
            //FajlDatabase.DeleteFile();
            if (File.Exists(FajlDatabase.FilePath.ToString()))
            {
                string[] lines = FajlDatabase.ReadDataFromFile();
                Database.gamedata = lines[1];
                username = lines[2];
                FajlDatabase.password = lines[3];
                FajlDatabase.username = username;
                Database.ertekado();
                Debug.Log(Database.gamedata);
                return;
            }
            else
            {
                Database.FillGameDataString();
            }
        }
    }

    public void fajlletrehozas(TMP_InputField usernamek)
    {
        // LÉTEZIK-E MÁR ILYEN NEVÜ JÁTÉKOS
        if(Wifi)
        {
            if(Database.CheckIfThisUserExists(usernamek.text))
            {
                WrongTextUzenet.SetActive(true);
                if (Database.Pont[0] == 0)
                {
                    wrongUsernameTXT.text = "This name is already taken, come up with a more creative one";
                }
                else
                {
                    wrongUsernameTXT.text = "Ez a név már foglalt, találj ki egy kreatívabbat";
                }
                return;
            }
        }
        else
        {
                StartCoroutine(NoWifi());
                return;
        }
        if (usernamek.text.Length ==0)
        {
            WrongTextUzenet.SetActive(true);
            if(Database.Pont[0]==0)
            {
                wrongUsernameTXT.text = "Put your name on the board";
            }
            else
            {
                wrongUsernameTXT.text = "Ird be a nevedet a tablaba";
            }
            return;
        }
        else
        if (usernamek.text.Length>14)
        {
            WrongTextUzenet.SetActive(true);
            wrongUsernameTXT.text = "Tul hosszu";
            return;
        }

        username = usernamek.text;
        FajlDatabase.username = username;
        StartCoroutine(Move(0.8f, Nevtabla, kozep.transform.position, rendeshely.transform.position));
        for (int i = 0; i < Nevvalasztasraszukseges.Count; i++)
        {
            Nevvalasztasraszukseges[i].SetActive(false);
        }
        Usernameee.SetActive(true);
        StartCoroutine(valtas());
        UsernameKiiratasa.text = username;
        //Database.Pont[2] = 7.259f;
        FajlDatabase.WriteIntoTxtFile();
    }

    IEnumerator valtas()
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < MasodMenuhezszuksegesdolgok.Count; i++)
        {
            MasodMenuhezszuksegesdolgok[i].SetActive(true);
        }

    }
    public void fomenuhez()
    {
        masodMENUPanel.SetActive(false);
        SettingPanel.SetActive(false);
        wrongUsernameTXT.text = "";
        FajlDatabase.WriteIntoTxtFile();
    }

    public IEnumerator Move(float Timek,GameObject Targy,Vector3 Position1, Vector3 Position2)
    {
        float Timer = 0;
        while (Timer < Timek)
        {
            Targy.transform.position = Vector3.Lerp(Position1, Position2, Timer / Timek);
            yield return Timer += Time.deltaTime;
        }
        Targy.transform.position = Position2;
    }

    public void SettingButton()
    {
        for (int i = 0; i < SettingsMindeneleme.Count; i++)
        {
            SettingsMindeneleme[i].SetActive(true);
        }
        SettingPanel.SetActive(true);
    }

    public void hangallitas()
    {
        Database.Pont[1]=Hangallitas.value;
        if(Hang!=null)
        Hang.volume = Hangallitas.value;
        FajlDatabase.WriteIntoTxtFile();
    }

    public static void hangletrehozasa(GameObject Hely, AudioClip Zene)
    {
        Hang = Hely.AddComponent<AudioSource>();
        Hang.volume = Database.Pont[1];
        Hang.clip = Zene;
        Hang.loop = true;
        Hang.Play();
    }

    public void GoRadicalsMenu()
    {
        masodMENUPanel.SetActive(false);
        RadicalsMenu.SetActive(true);
    }
    public void masodMenuBack()
    {
        masodMENUPanel.SetActive(true);
        RadicalsMenu.SetActive(false);
    }
    public void GoRadicalsLeaderboard()
    {
        if (LeaderBoarMegnyitasa)
        {
            LeaderBoarMegnyitasa = false;
            StartCoroutine(leaderboardmegnyitasavarkoztatasa())
;            if (adatoklekerve)
            {
                RadicalsMenu.SetActive(false);
                RadicalsLeaderboardPanel.SetActive(true);
                RanglistaKerelem();
            }
            else
            {
                StartCoroutine(NoWifi());
            }
        }
    }
    IEnumerator leaderboardmegnyitasavarkoztatasa()
    {
        yield return new WaitForSeconds(1.2f);
        LeaderBoarMegnyitasa = true;
    }
    public void RadicalsLeaderBoardtoRadicalsMenu()
    {
        RadicalsMenu.SetActive(true);
        RadicalsLeaderboardPanel.SetActive(false);
    }

    public void RanglistaKerelem()
    {
        Leaderboard.transform.position = teteje.transform.position;
        for(int i=0;i<Prefabs.Count;i++)
        {
            Destroy(Prefabs[i]);
        }
        Prefabs.Clear();
        int index = DropDown.value;
        List<System.Tuple<float, string>> Ranglista = new List<System.Tuple<float, string>>();
        if(index==0)
        {
            Ranglista = Database.ElsoGame;
        }
        else
                    if (index == 1)
        {
            Ranglista = Database.MasodikGame;
        }
        else
                    if (index == 2)
        {
            Ranglista = Database.HarmadikGame;
        }
        else
                    if (index == 3)
        {
            Ranglista = Database.NegyedikGame;
        }
        else
                    if (index == 4)
        {
            Ranglista = Database.OtodikGame;
        }
        else
                    if (index == 5)
        {
            Ranglista = Database.HatodikGame;
        }
        StartCoroutine(LeaderboardKesleltetes(Ranglista));
        

    }
    IEnumerator LeaderboardKesleltetes(List<System.Tuple<float, string>> Ranglista)
    {
        sajat = null;
        int sorszam = 0;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < Ranglista.Count; i++)
        {
            if (Ranglista[i].Item1 != 0)
            {
                    Vector3 position = Leaderboard.transform.position;
                    position.y -= 1.25f * Leaderboard.transform.childCount;
                    position.x = -0.22f;
                    GameObject PlacePrefabss = Instantiate(PlacePrefab, position, Quaternion.identity);

                    PlacePrefabss.transform.parent = Leaderboard.transform;
                    Prefabs.Add(PlacePrefabss);
                    if (sorszam == 0)
                    {
                        PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().Trofea.SetActive(true);
                        PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().Trofea.GetComponent<Image>().sprite = FirsPlaceTrofea;
                        PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().Helyezes.text = "";
                    }
                    else
                    {
                        PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().Trofea.SetActive(false);
                        PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().Helyezes.text = (sorszam + 1) + ".";
                    }
                    PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().nev.text = Ranglista[i].Item2;
                    PlacePrefabss.GetComponent<LeaderBoardPlacesSript>().Pont.text = Ranglista[i].Item1.ToString();
                if (Ranglista[i].Item2 == FajlDatabase.username)
                {
                    PlacePrefabss.GetComponent<Image>().color = Sotetites;
                    sajathelyezes = sorszam;
                    sajat = PlacePrefabss;
                    igazitas();
                }
                sorszam++;
            }
        }
    }

    private void igazitas()
    {
        if(sajat!=null)
        {
            //float ertek = Leaderboard.transform.position.y-(1.25f*(sajathelyezes-1));
            /*ertek -= teteje.transform.position.y;
            int ertek2 = (int)Mathf.Ceil(ertek / (1.25f))-1;*/
            //Debug.Log(ertek);
            //Sajatrendeshelye.y = (Leaderboard.transform.position.y - 3) - sajathelyezes * 1.25f;
            float ertek = (Leaderboard.transform.position.y) - (sajathelyezes) * 1.25f;
            //Debug.Log(ertek);
            //Debug.Log(Sajatrendeshelye);
            if (ertek <= teteje.transform.position.y && ertek >= alja.transform.position.y)
            {
                //Debug.Log("benne");
                if(sajathelyezes!=0)
                {
                    sajat.transform.position = new Vector3(Prefabs[sajathelyezes-1].transform.position.x, Prefabs[sajathelyezes - 1].transform.position.y-1.25f, Prefabs[sajathelyezes - 1].transform.position.z);
                }
            }
            else
            {
                //Debug.Log("nincs benne");
                if (ertek < alja.transform.position.y)
                {
                    sajat.transform.position = new Vector3(sajat.transform.position.x, (alja.transform.position.y) + 1.25f / 2, 0);
                }
            }
        }

    }
    public void GoRadicalsGame(GameObject hova)
    {
        RadicalsMenu.SetActive(false);
        hova.SetActive(true);
    }
    IEnumerator NoWifi()
    {
        NowWifiPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        NowWifiPanel.SetActive(false);
    }

    public static bool Bennevane(Transform kulso, Vector3 belso)
    {
        if (belso.x >= (kulso.transform.position.x - kulso.transform.localScale.x / 2) && belso.x <= (kulso.localScale.x / 2 + kulso.position.x) && belso.y >= (kulso.position.y - kulso.localScale.y / 2) && belso.y <= (kulso.localScale.y / 2 + kulso.position.y))
        {
            return true;
        }
        return false;
    }
}
