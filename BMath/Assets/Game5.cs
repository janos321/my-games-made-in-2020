using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game5 : MonoBehaviour
{
    public GameObject RadicalsMenuOpsion, Game, end, start;
    public TMP_Text TimeCounter;
    public List<GameObject> Palyak = new List<GameObject>();
    public GameObject Task;
    public TMP_Text Valasz;
    public List<Feladatok> Taskok = new List<Feladatok>();
    public GameObject TimeCounterTabla, CorrectTable, TimeFelirat, CorrectFelirat;
    public TMP_Text CorrectTXT,TimeTXT;
    public Color Right, Lose, Alap;
    public GameObject Equal, WrongLine;
    public List<Carpick> CarsSprites = new List<Carpick>();
    public GameObject carpick;
    public GameObject HelpPanel;
    public GameObject HelpButton;

    private int[] VolteMar = new int[40];
    private GameObject Palya;
    private int megoldas = 0, helyesek = 0;
    private float ido = 0;
    private bool Mehete = true;
    public int CarPick=0;

    [System.Serializable]
    public class Feladatok
    {
        public Sprite Kep;
        public int megoldas;
    }

    [System.Serializable]
    public class Carpick
    {
        public Sprite Kep;
        public Vector3 Scale = new Vector3(1, 1, 1);
    }

    void Update()
    {
        ido = ido + Time.deltaTime;
        ido = (float)System.Math.Round(ido, 3);
        TimeCounter.text = ido.ToString();
    }
    public void Back()
    {
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        WrongLine.SetActive(false);
        Mehete = true;
        Equal.GetComponent<Image>().color = Alap;
        for (int i=0;i< VolteMar.Length;i++)
        {
            VolteMar[i] = 0;
        }
        ido = 0;
        helyesek = 0;
        CarMovecarSript.presentcheckpoint = -1;
        RadicalsMenuOpsion.SetActive(true);
        Game.SetActive(false);
        end.SetActive(false);
        start.SetActive(true);
        carpick.SetActive(false);

        gameObject.SetActive(false);
    }
    public void Retry()
    {
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        WrongLine.SetActive(false);
        Mehete = true;
        Equal.GetComponent<Image>().color = Alap;
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        ido = 0;
        helyesek = 0;
        CarMovecarSript.presentcheckpoint = -1;
        end.SetActive(false);
        start.SetActive(false);
        carpick.SetActive(true);
    }

    public void CarValaszto(int index)
    {
        CarPick = index;
        carpick.SetActive(false);
        Game.SetActive(true);
        ido = 0;
        Palyaosztas();
    }
    public void StartButton()
    {
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        WrongLine.SetActive(false);
        Mehete = true;
        Equal.GetComponent<Image>().color = Alap;
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        ido = 0;
        helyesek = 0;
        CarMovecarSript.presentcheckpoint = -1;
        end.SetActive(false);
        start.SetActive(false);
        carpick.SetActive(true);
    }

    public void End()
    {
        Game.SetActive(false);
        TimeCounterTabla.SetActive(false);
        CorrectTable.SetActive(false);
        TimeFelirat.SetActive(false);
        CorrectFelirat.SetActive(false);
        CorrectTable.transform.position = CorrectFelirat.transform.position;
        TimeCounterTabla.transform.position = TimeFelirat.transform.position;
        TimeTXT.text = ido.ToString();
        CorrectTXT.text = helyesek.ToString();
        if ((Database.Pont[5] > ido) || Database.Pont[5] == 0)
        {
            Database.Pont[5] = ido;
            FajlDatabase.WriteIntoTxtFile();
        }
        end.SetActive(true);
        StartCoroutine(End2());
    }

    public IEnumerator End2()
    {
        yield return new WaitForSeconds(0.7f);
        TimeFelirat.SetActive(true);
        TimeCounterTabla.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(Move(0.8f, TimeCounterTabla, TimeCounterTabla.transform.position, new Vector3(TimeCounterTabla.transform.position.x, TimeCounterTabla.transform.position.y - 2, TimeCounterTabla.transform.position.z)));
        yield return new WaitForSeconds(1.4f);
        CorrectFelirat.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        CorrectTable.SetActive(true);
        StartCoroutine(Move(0.8f, CorrectTable, CorrectTable.transform.position, new Vector3(CorrectTable.transform.position.x, CorrectTable.transform.position.y - 2, CorrectTable.transform.position.z)));
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
    public void Palyaosztas()
    {
        int random = Random.Range(0, Palyak.Count);
        Palyak[random].SetActive(true);
        Palya = Palyak[random];
        FeladatOsztas();
    }

    public void FeladatOsztas()
    {
        Mehete = true;
        Equal.GetComponent<Image>().color = Alap;
        Valasz.text = "";
        int random = -1;
        int szamol = 0;
        while(random==-1)
        {
            szamol++;
            if(szamol==1000)
            {
                for (int i = 0; i < VolteMar.Length; i++)
                {
                    VolteMar[i] = 0;
                }
                szamol = 0;
            }
            random = Random.Range(0, Taskok.Count);
            if(VolteMar[random]!=0)
            {
                random = -1;
            }
        }
        VolteMar[random] = 1;
        Task.GetComponent<Image>().sprite = Taskok[random].Kep;
        megoldas = Taskok[random].megoldas;
    }
    public void GomLenyomas(int index)
    {
        if (Mehete)
        {
            if (index >= 0 && index < 10 && Valasz.text.Length < 6)
            {
                Valasz.text = Valasz.text + index;
            }
            else
                if (index == 10)
            {
                if (megoldas.ToString() == Valasz.text)
                {
                    helyesek++;
                    Palya.GetComponent<CarMovecarSript>().Boost();
                    StartCoroutine(helyes());
                }
                else
                {
                    StartCoroutine(helytelen());
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
    IEnumerator helyes()
    {
        Mehete = false;
        Equal.GetComponent<Image>().color = Right;
        yield return new WaitForSeconds(0.7f);
        FeladatOsztas();
    }
    IEnumerator helytelen()
    {
        Mehete = false;
        Equal.GetComponent<Image>().color = Lose;
        WrongLine.GetComponent<Image>().color = Lose;
        WrongLine.SetActive(true);
        yield return new WaitForSeconds(1f);
        WrongLine.SetActive(false);
        Valasz.text = megoldas.ToString();
        Equal.GetComponent<Image>().color = Alap;
        yield return new WaitForSeconds(3f);
        FeladatOsztas();
    }
    public void Helping(bool a)
    {
        HelpPanel.SetActive(a);
        HelpButton.SetActive(!a);
    }
}
