using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game200IQ : MonoBehaviour
{
    public GameObject RadicalsMenuOpsion, Game, end, start;
    public TMP_Text TimeCounter;
    public GameObject TimeFelirat, CorrectFelirat, InCorrectFelirat, TimeValue, CorrectValue, inCorrectValue;
    public TMP_Text VeglegesTime, VeglegesHelyes, veglegesHelytelen,feladatokmutatas;
    public List<GameObject> Jatekok = new List<GameObject>();

    public string elso1 = "1-----------------";
    public GameObject Game10;
    public Image Button1, Button2, Button3;
    public Image TaskPicture;
    public TMP_Text FirstButton;
    public TMP_Text SecuendButton;
    private int jelenlegifeladat = 0;
    public string elso2 = "1-----------------";


    public string Masodik1 = "2-----------------";
    public TMP_Text Valasz;
    public List<Masodiknak> taskok2 = new List<Masodiknak>();
    public GameObject TaskMutato2;
    public GameObject Valaszhatter;
    private int Jelenlegifeladat2 = 0;
    public string Masodik2 = "2-----------------";

    public string Harmadik1 = "3-----------------";
    public TMP_Text Valasz3;
    public TMP_Text Valasz32;
    public List<Masodiknak> taskok3 = new List<Masodiknak>();
    public GameObject TaskMutato3;
    public GameObject Valaszhatter3;
    private int Jelenlegifeladat3 = 0,valasz=5;
    public string harmadik2 = "3-----------------";

    public string Negyedik1 = "44-----------------";
    public List<Negyediknek> Taskok4 = new List<Negyediknek>();
    public GameObject Helpbutton,helpPanel;
    public List<GameObject> answrsButton = new List<GameObject>();
    public GameObject Valaszhatter41, Valaszhatter42, Valaszhatter43;
    public TMP_Text Valasz41, Valasz42, Valasz43;
    private int[] szamok4 = new int[10];
    private int kesze = 0,szamfajta4=0;
    public string Negyedik2 = "44-----------------";

    public string Otodik1 = "55-----------------";
    public List<Otodiknek> Taskok5 = new List<Otodiknek>();
    public GameObject ValaszButton1, ValaszButton2, ValaszButton3;
    public GameObject ValaszButtonImage1, ValaszButtonImage2, ValaszButtonImage3;
    public GameObject TaskMutato;
    private int[] szamok5 = new int[10];
    private int szamfajta5 = 0;
    public string Otodik2 = "55-----------------";


    public static int helyesvalaszok = 0, helytelenvalaszok = 0;
    public bool Meheteazidozito = false;
    private float ido;
    private int feladatok = 0;
    private int[] FeladatokVolteMar = new int[7];
    private int[] szamok = new int[7];


    [System.Serializable]
    public class Masodiknak
    {
        public Sprite Task;
        public string megoldas;

    }

    [System.Serializable]
    public class Negyediknek
    {
        public List<int> valaszok = new List<int>();
        public List<string> megoldas = new List<string>();

    }

    [System.Serializable]
    public class Otodiknek
    {
        public Sprite Task;
        public Sprite Megoldas;

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Meheteazidozito)
        {
            ido = ido + Time.deltaTime;
            ido = (float)System.Math.Round(ido, 3);
            TimeCounter.text = ido.ToString();
        }
    }

    public void Back()
    {
        ujra();
        RadicalsMenuOpsion.SetActive(true);
        Game.SetActive(false);
        end.SetActive(false);
        start.SetActive(true);

        gameObject.SetActive(false);
    }
    public void Retry()
    {
        ujra();
        end.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
        koviTask();
    }

    public void StartButton()
    {
        ujra();
        end.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
        koviTask();
    }

    public static void BoxcolliderBeallitas(BoxCollider Box)
    {
        Box.center = new Vector3(0, 0, 0);
        Box.size=new Vector3(1.26f, 1.4f, 1);
    }
    private void ujra()
    {
        ValaszButton1.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        ValaszButton2.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        ValaszButton3.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        Valaszhatter41.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        Valaszhatter42.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        Valaszhatter43.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        kesze = 0;
        Valasz41.text = "";
        Valasz42.text = "";
        Valasz43.text = "";
        for (int i=0;i< answrsButton.Count;i++)
        {
            answrsButton[i].SetActive(true);
            if (answrsButton[i].GetComponent<Mozgatas>().EredetiHely != new Vector3(0, 0, 0))
            {
                answrsButton[i].transform.position = answrsButton[i].GetComponent<Mozgatas>().EredetiHely;
            }
            if(answrsButton[i].GetComponentInParent<BoxCollider>())
            {
                answrsButton[i].GetComponent<BoxCollider>().enabled = false;
            }
            answrsButton[i].AddComponent<BoxCollider>();
            BoxcolliderBeallitas(answrsButton[i].GetComponent<BoxCollider>());
        }
        helpPanel.SetActive(false);
        Helpbutton.SetActive(true);
        Valaszhatter.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        Valaszhatter3.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        valasz = 5;
        Valasz3.text = valasz.ToString();
        Valasz32.text = valasz.ToString();
        TimeFelirat.SetActive(false); CorrectFelirat.SetActive(false); InCorrectFelirat.SetActive(false); TimeValue.SetActive(false); CorrectValue.SetActive(false); inCorrectValue.SetActive(false);
        Meheteazidozito = true;
        Valasz.text = "";
        Button1.color =Game10.GetComponent<Game10>().simpla;
        Button2.color = Game10.GetComponent<Game10>().simpla;
        Button3.color = Game10.GetComponent<Game10>().simpla;
        for (int i=0;i< FeladatokVolteMar.Length;i++)
        {
            FeladatokVolteMar[i] = 0;
        }
        for (int i = 0; i < szamok.Length; i++)
        {
            szamok[i] = 0;
        }
        for (int i = 0; i < szamok4.Length; i++)
        {
            szamok4[i] = 0;
        }
        for (int i = 0; i < szamok5.Length; i++)
        {
            szamok5[i] = 0;
        }
        feladatok = 0;
        helyesvalaszok = 0;
        helytelenvalaszok = 0;
        ido = 0;
    }
    private IEnumerator Vege()
    {
        Game.SetActive(false);
        end.SetActive(true);
        VeglegesTime.text = ido.ToString();
        veglegesHelytelen.text = Jatekok.Count+"/" + helytelenvalaszok;
        VeglegesHelyes.text = Jatekok.Count+"/" + helyesvalaszok;
        if ((Database.Pont[7] == 0 || Database.Pont[7] > ido) && helyesvalaszok == Jatekok.Count && helytelenvalaszok == 0)
        {
            Database.Pont[7] = ido;
            FajlDatabase.WriteIntoTxtFile();
        }
        TimeFelirat.SetActive(true);
        TimeValue.transform.position = TimeFelirat.transform.position;
        TimeValue.SetActive(true);
        StartCoroutine(Move(0.8f, TimeValue, TimeValue.transform.position, new Vector3(TimeValue.transform.position.x, TimeValue.transform.position.y - 2, TimeValue.transform.position.z)));
        yield return new WaitForSeconds(1.2f);
        CorrectFelirat.SetActive(true);
        InCorrectFelirat.SetActive(true);
        CorrectValue.transform.position = CorrectFelirat.transform.position;
        inCorrectValue.transform.position = InCorrectFelirat.transform.position;
        CorrectValue.SetActive(true);
        inCorrectValue.SetActive(true);
        StartCoroutine(Move(0.8f, CorrectValue, CorrectValue.transform.position, new Vector3(CorrectValue.transform.position.x, CorrectValue.transform.position.y - 1.5f, CorrectValue.transform.position.z)));
        StartCoroutine(Move(0.8f, inCorrectValue, inCorrectValue.transform.position, new Vector3(inCorrectValue.transform.position.x, inCorrectValue.transform.position.y - 1.5f, inCorrectValue.transform.position.z)));

    }

    public IEnumerator Move(float Timek, GameObject Targy, Vector3 Position1, Vector3 Position2)
    {
        float Timer = 0;
        while (Timer < Timek)
        {
            Targy.transform.position = Vector3.Lerp(Position1, Position2, Timer / Timek);
            yield return Timer += Time.deltaTime;
        }
        Targy.transform.position = Position2;

    }

    public void koviTask()
    {
        if(feladatok==Jatekok.Count)
        {
          StartCoroutine(Vege());
            return;
        }
        for(int i=0;i<Jatekok.Count;i++)
        {
            Jatekok[i].SetActive(false);
        }
        feladatok++;
        feladatokmutatas.text = Jatekok.Count+ "/"+feladatok;
        int random = -1;
        while(random==-1)
        {
            random = Random.Range(0, Jatekok.Count);
            if(FeladatokVolteMar[random]==1)
            {
                random = -1;
            }
        }
        FeladatokVolteMar[random] = 1;
        Jatekok[random].SetActive(true);

        if(random==0)
        {
            Elsojatek();
        }
        else
        {
            int randommilyenszam = -1;
            while (randommilyenszam == -1)
            {
                randommilyenszam = Random.Range(0, taskok2.Count);
                if (szamok[randommilyenszam] == 1)
                {
                    randommilyenszam = -1;
                }
            }
            szamok[randommilyenszam] = 1;
            if (random==1)
            {
                Masodikjatek(randommilyenszam);
            }
            else
                if(random==2)
            {
                harmadikGame(randommilyenszam);
            }
            else
                if(random==3)
            {
                Negyedikgame(randommilyenszam);
            }
            else
                if(random==4)
            {
                OtodikGame(randommilyenszam);
            }
        }
    }
    public void OtodikGame(int szamfajta)
    {
        szamfajta5 = szamfajta;
        TaskMutato.GetComponent<Image>().sprite = Taskok5[szamfajta].Task;
        int szamlalo = 0;
        while(szamlalo<3)
        {
            int random = Random.Range(0, Taskok5.Count);
            if(szamok5[random]==0)
            {
                szamok5[random] = 1;
                if(szamlalo==0)
                {
                    ValaszButtonImage1.transform.GetComponent<Image>().sprite = Taskok5[random].Megoldas;
                }
                else
                    if(szamlalo==1)
                {
                    ValaszButtonImage2.transform.GetComponent<Image>().sprite = Taskok5[random].Megoldas;
                }
                else
                    if(szamlalo==2)
                {
                    if(szamok5[szamfajta]==0)
                    {
                        ValaszButtonImage3.transform.GetComponent<Image>().sprite = Taskok5[szamfajta].Megoldas;
                    }
                    else
                    {
                        ValaszButtonImage3.transform.GetComponent<Image>().sprite = Taskok5[random].Megoldas;
                    }
                }
                szamlalo++;
            }
        }

    }
    
    public void Gomlenyomas5(int index)
    {
        if (Meheteazidozito)
        {
            Meheteazidozito = false;
            bool joe = false;
            if (index == 0)
            {
                if (ValaszButtonImage1.GetComponent<Image>().sprite == Taskok5[szamfajta5].Megoldas)
                {
                    joe = true;
                }
            }
            else
                        if (index == 1)
            {
                if (ValaszButtonImage2.GetComponent<Image>().sprite == Taskok5[szamfajta5].Megoldas)
                {
                    joe = true;
                }
            }
            else
                        if (index == 2)
            {
                if (ValaszButtonImage3.GetComponent<Image>().sprite == Taskok5[szamfajta5].Megoldas)
                {
                    joe = true;
                }
            }
            if (joe)
            {
                helyesvalaszok++;
            }
            else
            {
                helytelenvalaszok++;
            }
            if (ValaszButtonImage1.GetComponent<Image>().sprite == Taskok5[szamfajta5].Megoldas)
            {
                ValaszButton1.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
                ValaszButton2.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
                ValaszButton3.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
            }
            else
             if (ValaszButtonImage2.GetComponent<Image>().sprite == Taskok5[szamfajta5].Megoldas)
            {
                ValaszButton1.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
                ValaszButton2.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
                ValaszButton3.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
            }
            else
            if (ValaszButtonImage3.GetComponent<Image>().sprite == Taskok5[szamfajta5].Megoldas)
            {
                ValaszButton1.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
                ValaszButton2.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
                ValaszButton3.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
            }
            StartCoroutine(Kovifeladat());
        }
    }
    public void Negyedikgame(int szamfajta)
    {
        szamfajta4 = szamfajta;
        int random = 0, szamlalo = 0;
        while(szamlalo<Taskok4[szamfajta].valaszok.Count)
        {
            random = Random.Range(0, Taskok4[szamfajta].valaszok.Count);
            if(szamok4[random]==0)
            {
                szamok4[random] = 1;
                answrsButton[szamlalo].GetComponent<Mozgatas>().Value = Taskok4[szamfajta].valaszok[random];
                answrsButton[szamlalo].transform.GetChild(0).GetComponent< TMP_Text>().text = Taskok4[szamfajta].valaszok[random].ToString();
                szamlalo++;
            }
        }
    }
    public void Belerak(Vector3 Position,int index)
    {
        if (Meheteazidozito)
        {
            if (MENUMainSrcipt.Bennevane(Valaszhatter41.transform, Position))
            {
                if (Valasz41.text == "")
                {
                    kesze++;
                }
                else
                {
                    for (int i = 0; i < answrsButton.Count; i++)
                    {
                        if (answrsButton[i].GetComponent<Mozgatas>().Value.ToString() == Valasz41.text)
                        {
                            answrsButton[i].SetActive(true);
                            break;
                        }
                    }
                }
                Valasz41.text = answrsButton[index].GetComponent<Mozgatas>().Value.ToString();
                answrsButton[index].SetActive(false);
            }
            if (MENUMainSrcipt.Bennevane(Valaszhatter42.transform, Position))
            {
                if (Valasz42.text == "")
                {
                    kesze++;
                }
                else
                {
                    for (int i = 0; i < answrsButton.Count; i++)
                    {
                        if (answrsButton[i].GetComponent<Mozgatas>().Value.ToString() == Valasz42.text)
                        {
                            answrsButton[i].SetActive(true);
                            break;
                        }
                    }
                }
                Valasz42.text = answrsButton[index].GetComponent<Mozgatas>().Value.ToString();
                answrsButton[index].SetActive(false);
            }
            if (MENUMainSrcipt.Bennevane(Valaszhatter43.transform, Position))
            {
                if (Valasz43.text == "")
                {
                    kesze++;
                }
                else
                {
                    for (int i = 0; i < answrsButton.Count; i++)
                    {
                        if (answrsButton[i].GetComponent<Mozgatas>().Value.ToString() == Valasz43.text)
                        {
                            answrsButton[i].SetActive(true);
                            break;
                        }
                    }
                }
                Valasz43.text = answrsButton[index].GetComponent<Mozgatas>().Value.ToString();
                answrsButton[index].SetActive(false);
            }
            if (kesze == 3)
            {
                Meheteazidozito = false;
                if (Valasz41.text == Taskok4[szamfajta4].megoldas[0] && Valasz42.text == Taskok4[szamfajta4].megoldas[1] && Valasz43.text == Taskok4[szamfajta4].megoldas[2])
                {
                    helyesvalaszok++;
                    StartCoroutine(helyes4());
                }
                else
                {
                    helytelenvalaszok++;
                    StartCoroutine(helytelen4());
                }
            }
        }
    }

    IEnumerator helytelen4()
    {
        if(Valasz41.text == Taskok4[szamfajta4].megoldas[0])
        {
            Valaszhatter41.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        }
        else
        {
            Valaszhatter41.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
        }
        if (Valasz42.text == Taskok4[szamfajta4].megoldas[1])
        {
            Valaszhatter42.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        }
        else
        {
            Valaszhatter42.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
        }
        if (Valasz43.text == Taskok4[szamfajta4].megoldas[2])
        {
            Valaszhatter43.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        }
        else
        {
            Valaszhatter43.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
        }
        yield return new WaitForSeconds(1.5f);
        for(int i=0;i<answrsButton.Count;i++)
        {
            answrsButton[i].SetActive(true);
        }
        Valasz41.text = Taskok4[szamfajta4].megoldas[0];
        Valasz42.text = Taskok4[szamfajta4].megoldas[1];
        Valasz43.text = Taskok4[szamfajta4].megoldas[2];
        Valaszhatter41.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        Valaszhatter42.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        Valaszhatter43.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        yield return new WaitForSeconds(2f);
        StartCoroutine(Kovifeladat());
    }
    IEnumerator helyes4()
    {
        Valaszhatter41.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        Valaszhatter42.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        Valaszhatter43.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Kovifeladat());
    }
    public void harmadikGame(int szamfajta)
    {
        TaskMutato3.GetComponent<Image>().sprite = taskok3[szamfajta].Task;
        Jelenlegifeladat3 = szamfajta;
    }
    public void GomLenyomas3(int index)
    {
        if (Meheteazidozito)
        {
            if(index==1)
            {
                if(valasz!=1)
                {
                    valasz--;
                    Valasz3.text = valasz.ToString();
                    Valasz32.text = valasz.ToString();
                }
            }
            else
            if(index==2)
            {
                if (valasz != 9)
                {
                    valasz++;
                    Valasz3.text = valasz.ToString();
                    Valasz32.text = valasz.ToString();
                }
            }
            else
            if(index==3)
            {
                Meheteazidozito = false;
                if (taskok3[Jelenlegifeladat3].megoldas == Valasz3.text)
                {
                    helyesvalaszok++;
                    StartCoroutine(helyes(Valaszhatter3));
                }
                else
                {
                    helytelenvalaszok++;
                    StartCoroutine(helytelen(Valaszhatter3, Valasz3, taskok3[Jelenlegifeladat3].megoldas));
                }
            }
            
        }
    }
    public void Masodikjatek(int szamfajta)
    {
        TaskMutato2.GetComponent<Image>().sprite = taskok2[szamfajta].Task;
        Jelenlegifeladat2 = szamfajta;
    }
    public void GomLenyomas(int index)
    {
        if (Meheteazidozito)
        {
            if (index >= 0 && index < 10 && Valasz.text.Length < 6)
            {
                Valasz.text = Valasz.text + index;
            }
            else
                if (index == 10)
            {
                Meheteazidozito = false;
                if (taskok2[Jelenlegifeladat2].megoldas == Valasz.text)
                {
                    helyesvalaszok++;
                    StartCoroutine(helyes(Valaszhatter));
                }
                else
                {
                    helytelenvalaszok++;
                    StartCoroutine(helytelen(Valaszhatter, Valasz, taskok2[Jelenlegifeladat2].megoldas));
                }
            }
            else
                if (index == 11)
            {
                string a = "";
                for (int i = 0; i < Valasz.text.Length - 1; i++)
                {
                    a += Valasz.text[i];
                }
                Valasz.text = a;
            }
        }
    }
    IEnumerator helyes(GameObject Valaszhatter)
    {
        Valaszhatter.GetComponent<Image>().color = Game10.GetComponent<Game10>().helyes;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Kovifeladat());
    }
    IEnumerator helytelen(GameObject Valaszhatter, TMP_Text Valasz,string megoldas)
    {
        Valaszhatter.GetComponent<Image>().color = Game10.GetComponent<Game10>().Teves;
        yield return new WaitForSeconds(1.5f);
        Valasz.text = megoldas;
        Valaszhatter.GetComponent<Image>().color = Game10.GetComponent<Game10>().simpla;
        yield return new WaitForSeconds(2f);
        StartCoroutine(Kovifeladat());
    }
    public void Elsojatek()
    {
        int index = Random.Range(0, Game10.GetComponent<Game10>().Taskok.Count);

        TaskPicture.sprite = Game10.GetComponent<Game10>().Taskok[index].Feladat;
        jelenlegifeladat = index;
        int random2 = Random.Range(0, 2);
        if (random2 == 0)
        {
            FirstButton.text = Game10.GetComponent<Game10>().Taskok[index].FirstAnswer;
            SecuendButton.text = Game10.GetComponent<Game10>().Taskok[index].SecuendAnswer;
        }
        else
        {
            SecuendButton.text = Game10.GetComponent<Game10>().Taskok[index].FirstAnswer;
            FirstButton.text = Game10.GetComponent<Game10>().Taskok[index].SecuendAnswer;
        }
    }
    public void ClickAnswer(int index)
    {
        if (!Meheteazidozito)
        {
            return;
        }
        Meheteazidozito = false;
        string valasz = "";
        if (index == 1)
        {
            valasz = FirstButton.text;
        }
        else
        if (index == 2)
        {
            valasz = SecuendButton.text;
        }
        else
        if (index == 3)
        {
            if (Game10.GetComponent<Game10>().Taskok[jelenlegifeladat].megoldas == "x")
            {
                valasz = Game10.GetComponent<Game10>().Taskok[jelenlegifeladat].megoldas;
            }
        }
        if (Game10.GetComponent<Game10>().Taskok[jelenlegifeladat].megoldas == valasz)
        {
            helyesvalaszok++;
        }
        else
        {
            helytelenvalaszok++;
        }
        if (FirstButton.text == Game10.GetComponent<Game10>().Taskok[jelenlegifeladat].megoldas)
        {
            Button1.color = Game10.GetComponent<Game10>().helyes;
            Button2.color = Game10.GetComponent<Game10>().Teves;
            Button3.color = Game10.GetComponent<Game10>().Teves;
        }
        else
          if (SecuendButton.text == Game10.GetComponent<Game10>().Taskok[jelenlegifeladat].megoldas)
        {
            Button1.color = Game10.GetComponent<Game10>().Teves;
            Button2.color = Game10.GetComponent<Game10>().helyes;
            Button3.color = Game10.GetComponent<Game10>().Teves;
        }
        else
          if ("x" == Game10.GetComponent<Game10>().Taskok[jelenlegifeladat].megoldas)
        {
            Button1.color = Game10.GetComponent<Game10>().Teves;
            Button2.color = Game10.GetComponent<Game10>().Teves;
            Button3.color = Game10.GetComponent<Game10>().helyes;
        }
        StartCoroutine(Kovifeladat());
    }

    public IEnumerator Kovifeladat()
    {
        //float Time = Random.Range(a, b);
        yield return new WaitForSeconds(1.5f);
        Meheteazidozito = true;
        koviTask();
    }

    public void Help(bool a)
    {
        helpPanel.SetActive(a);
        Helpbutton.SetActive(!a);
    }

}
