using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Game3 : MonoBehaviour
{
    public GameObject RadicalsMenuOpsion, Game, end, start;
    public TMP_Text TimeCounter;
    public GameObject lapok;
    //public GameObject Position;
    public List<KepParok> Feladatok = new List<KepParok>();
    public List<GameObject> Images = new List<GameObject>();
    public GameObject TimeFelirat, TimeCounterTabla, ProbalkozasokFelirat, ProbalkozasokCounterTabla;
    public TMP_Text TimeTxt, ProbalkozasokTXT;
    public List<Sprite> LapBackground = new List<Sprite>();
    public GameObject HelpPanel;
    public GameObject HelpButton;
    public Color Piros, feher;

    private List<LapAdatok> Lapok = new List<LapAdatok>();
    private float ido = 0;
    private int Probalkozasok = 0, elsoLap = -1, helyesek = 0,segitsegmax=3,piroslap1=-1,piroslap2=-1;
    private bool Mehetealapforditas = true;
    private int[] Static = new int[8];
    private int Segitseg = 0;
    private int[] VolteMar = new int[40];

    [System.Serializable]
    public class KepParok
    {
        public List<Sprite> Kepek;
    }
    [System.Serializable]
    public class LapAdatok
    {
        public Transform Lap;
        public Vector3 Position;
        //public Transform Kep;
        public int jeloles = 0;
    }

    private void Start()
    {
        Static[0] = 0;
        Static[1] = 0;
        Static[2] = 0;
        Static[3] = 1;
        Static[4] = 1;
        Static[5] = 2;
        for (int i = 0; i < lapok.transform.childCount; i++)
        {
            Transform Lap = lapok.transform.GetChild(i).transform;
            LapAdatok lapAdattt = new LapAdatok();
            Lapok.Add(lapAdattt);
            Lapok[Lapok.Count - 1].Position = Lap.position;
            Lapok[Lapok.Count - 1].Lap = Lap;
        }
    }
    void Update()
    {
        ido = ido + Time.deltaTime;
        ido = (float)System.Math.Round(ido, 3);
        TimeCounter.text = Mathf.Floor(ido).ToString();
    }

    public void Felosztas()
    {
        int kartyaKinezetIndex = Random.Range(0, 6);
        for (int i = 0; i < Lapok.Count; i++)
        {
            Lapok[i].Lap.GetComponent<Image>().sprite = LapBackground[Static[kartyaKinezetIndex]];
            Lapok[i].Lap.rotation = Quaternion.Euler(0, 0, 0);
            Lapok[i].Lap.transform.position = Lapok[i].Position;
            Lapok[i].Lap.GetComponent<Image>().color = feher;
            Images[i].SetActive(false);
            //Images[i].transform.position = new Vector3(0, 0, 0);
            //Images[i].transform.rotation = Quaternion.Euler(0, 180, 0);
            Lapok[i].jeloles = -1;
        }
        int mennyit = 0;
        while (mennyit != 15)
        {
            if (mennyit <= 10)
            {
                for (int j = 0; j < 2; j++)
                {
                    int random = -1;
                    while (random == -1)
                    {
                        random = Random.Range(0, 30);
                        if (Lapok[random].jeloles != -1)
                        {
                            random = -1;
                        }
                    }
                    Lapok[random].jeloles = mennyit;
                    Images[random].GetComponent<Image>().sprite = Feladatok[mennyit].Kepek[j];

                }
            }
            else
            {
                for (int j = 0; j < 2; j++)
                {
                    int random = -1;
                    for (int i = 0; i < Lapok.Count; i++)
                    {
                        if (Lapok[i].jeloles == -1)
                        {
                            random = i;
                            break;
                        }
                    }
                    Lapok[random].jeloles = mennyit;
                    Images[random].GetComponent<Image>().sprite = Feladatok[mennyit].Kepek[j];

                }
            }
            mennyit++;
        }
    }
    public void Back()
    {
        piroslap1 = -1;
        piroslap2 = -1;
        segitsegmax = 1;
        for (int i=0;i<VolteMar.Length;i++)
        {
            VolteMar[i] = 0;
        }
        Segitseg = 0;
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        Mehetealapforditas = true;
        ido = 0;
        elsoLap = -1;
        Probalkozasok = 0;
        helyesek = 0;
        RadicalsMenuOpsion.SetActive(true);
        Game.SetActive(false);
        end.SetActive(false);
        start.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Retry()
    {
        piroslap1 = -1;
        piroslap2 = -1;
        segitsegmax = 1;
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        Segitseg = 0;
        HelpButton.SetActive(true);
        HelpPanel.SetActive(false);
        Mehetealapforditas = true;
        ido = 0;
        elsoLap = -1;
        Probalkozasok = 0;
        helyesek = 0;
        end.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
        Felosztas();
    }

    public void StartButton()
    {
        piroslap1 = -1;
        piroslap2 = -1;
        segitsegmax = 1;
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        Segitseg = 0;
        HelpButton.SetActive(true);
        HelpPanel.SetActive(false);
        Mehetealapforditas = true;
        ido = 0;
        elsoLap = -1;
        Probalkozasok = 0;
        helyesek = 0;
        end.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
        Felosztas();
    }

    public void LapraKattintas(int index)
    {
        if (Mehetealapforditas && index != elsoLap)
        {
            Mehetealapforditas = false;
            StartCoroutine(Lapmegforditas(index, 0.5f));
        }
    }
    IEnumerator Lapmegforditas(int index, float time)
    {
        float Timer = 0;
        bool nez = true, masodiklape = false;
        if (elsoLap == -1)
        {
            elsoLap = index;
            Mehetealapforditas = true;
        }
        else
        {
            masodiklape = true;
        }
        if (piroslap1 == index)
        {
            Lapok[piroslap1].Lap.GetComponent<Image>().color = feher;
            piroslap1 = -1;
        }
        if (piroslap2 == index)
        {
            Lapok[piroslap2].Lap.GetComponent<Image>().color = feher;
            piroslap2 = -1;
        }
        while (Timer < time)
        {
            Lapok[index].Lap.rotation = Quaternion.Euler(0, Mathf.Lerp(0, 180, Timer / time), 0);
            if (Timer >= time / 2 && nez)
            {
                nez = false;
                Images[index].SetActive(true);
            }
            yield return Timer += Time.deltaTime;
        }
        Lapok[index].Lap.rotation = Quaternion.Euler(0, 180, 0);
        if (masodiklape)
        {
            Probalkozasok++;
            if (Lapok[elsoLap].jeloles == Lapok[index].jeloles)
            {
                Segitseg = 0;
                yield return new WaitForSeconds(time);
                VolteMar[index] = 1;
                VolteMar[elsoLap] = 1;
                Lapok[elsoLap].Lap.transform.position = new Vector3(999, 999, -999);
                Lapok[index].Lap.transform.position = new Vector3(999, 999, -999);
                Images[index].SetActive(false);
                Images[elsoLap].SetActive(false);
                helyesek++;
            }
            else
            {
                Segitseg ++;
                yield return new WaitForSeconds(time);
                if(Segitseg >= segitsegmax)
                {
                    segitsegmax += 2;
                    Segitseg = 0;
                    StartCoroutine(Pirositas());
                        }
                Timer = 0;
                nez = true;
                while (Timer < time)
                {
                    Lapok[index].Lap.rotation = Quaternion.Euler(0, Mathf.Lerp(180, 0, Timer / time), 0);
                    Lapok[elsoLap].Lap.rotation = Quaternion.Euler(0, Mathf.Lerp(180, 0, Timer / time), 0);
                    if (Timer >= time / 2 && nez)
                    {
                        nez = false;
                        Images[index].SetActive(false);
                        Images[elsoLap].SetActive(false);
                    }
                    yield return Timer += Time.deltaTime;
                }
                Lapok[index].Lap.rotation = Quaternion.Euler(0, 0, 0);
                Lapok[elsoLap].Lap.rotation = Quaternion.Euler(0, 0, 0);
            }
            elsoLap = -1;
            if (helyesek == 15)
            {
                End();
            }
            Mehetealapforditas = true;
        }
    }

    IEnumerator Pirositas()
    {
        int elsokartya = 0, masodikkartya = 0,jeloles=0,random=-1;
        while(random==-1)
        {
            random = Random.Range(0, Lapok.Count);
            if (VolteMar[random] == 0)
            {
                elsokartya = random;
                jeloles = Lapok[random].jeloles;
                break;
            }
            else
            {
                random = -1;
            }
        }
        for (int i = 0; i < Lapok.Count; i++)
        {
            if (Lapok[i].jeloles==jeloles&&elsokartya!=i)
            {
                masodikkartya = i;
                break;
            }
        }
        Color elso = feher;
        Color Masodik = Piros;
        piroslap1 = elsokartya;
        piroslap2 = masodikkartya;
        for(int i=0;i<6;i++)
        {
            float timer = 0;
            while(timer<1)
            {
                if(piroslap1!=-1)
                Lapok[elsokartya].Lap.GetComponent<Image>().color = Color.Lerp(elso, Masodik, timer / 1);
                if(piroslap2!=-1)
                Lapok[masodikkartya].Lap.GetComponent<Image>().color = Color.Lerp(elso, Masodik, timer / 1);
                yield return timer += Time.deltaTime;
            }
            Color xd = elso;
            elso = Masodik;
            Masodik = xd;
        }
        Lapok[elsokartya].Lap.GetComponent<Image>().color = feher;
        Lapok[masodikkartya].Lap.GetComponent<Image>().color = feher;

    }
    public void End()
    {
        Game.SetActive(false);
        TimeCounterTabla.SetActive(false);
        ProbalkozasokCounterTabla.SetActive(false);
        TimeFelirat.SetActive(false);
        ProbalkozasokFelirat.SetActive(false);
        ProbalkozasokCounterTabla.transform.position = ProbalkozasokFelirat.transform.position;
        TimeCounterTabla.transform.position = TimeFelirat.transform.position;
        TimeTxt.text = ido.ToString();
        ProbalkozasokTXT.text = Probalkozasok.ToString();
        if ((Database.Pont[4] > ido)|| Database.Pont[4]==0)
        {
            Database.Pont[4] = ido;
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
        ProbalkozasokFelirat.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ProbalkozasokCounterTabla.SetActive(true);
        StartCoroutine(Move(0.8f, ProbalkozasokCounterTabla, ProbalkozasokCounterTabla.transform.position, new Vector3(ProbalkozasokCounterTabla.transform.position.x, ProbalkozasokCounterTabla.transform.position.y - 2, ProbalkozasokCounterTabla.transform.position.z)));
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
    public void Helping(bool a)
    {
        HelpPanel.SetActive(a);
        HelpButton.SetActive(!a);
    }
}
