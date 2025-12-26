using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using System.IO;
using TMPro;

public class Game10 : MonoBehaviour
{
    public GameObject StartGameobjects;
    public GameObject GameGameobjects;
    public GameObject EndGameobjects;
    public GameObject RadicalsOpcioMenu;
    public Image TaskPicture;
    public TMP_Text FirstButton;
    public TMP_Text SecuendButton;
    public TMP_Text FeladatCounter;
    public TMP_Text TimeCounter;
    public Image Button1, Button2, Button3;
    public Color Teves, helyes, simpla;
    public GameObject TimeFelirat, CorrectFelirat, InCorrectFelirat, TimeValue, CorrectValue, inCorrectValue;
    public TMP_Text VeglegesTime, VeglegesHelyes, veglegesHelytelen;

    private int jelenlegifeladat = 0, hanyadikfeladat = 0, helyesvalaszok = 0, helytelenvalaszok = 0;
    private bool Meheteazidozito = false;
    private float ido;
    private int[] VolteMar = new int[20];
    public List<Tasks> Taskok;

    [System.Serializable]
    public class Tasks
    {
        public Sprite Feladat;
        public string FirstAnswer;
        public string SecuendAnswer;
        public string megoldas;
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

    public void StartButton()
    {
        Button1.color = simpla;
        Button2.color = simpla;
        Button3.color = simpla;
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        hanyadikfeladat = 0;
        helyesvalaszok = 0;
        helytelenvalaszok = 0;
        ido = 0;
        TimeFelirat.SetActive(false); CorrectFelirat.SetActive(false); InCorrectFelirat.SetActive(false); TimeValue.SetActive(false); CorrectValue.SetActive(false); inCorrectValue.SetActive(false);
        Meheteazidozito = false;
        StartGameobjects.SetActive(false);
        GameGameobjects.SetActive(true);
        FeladatOsztas();
    }
    public void Back()
    {
        StartGameobjects.SetActive(true);
        GameGameobjects.SetActive(false);
        EndGameobjects.SetActive(false);
        RadicalsOpcioMenu.SetActive(true);
        gameObject.SetActive(false);
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
            if (Taskok[jelenlegifeladat].megoldas == "x")
            {
                valasz = Taskok[jelenlegifeladat].megoldas;
            }
        }
        if (Taskok[jelenlegifeladat].megoldas == valasz)
        {
            helyesvalaszok++;
        }
        else
        {
            helytelenvalaszok++;
        }
        if (FirstButton.text == Taskok[jelenlegifeladat].megoldas)
        {
            Button1.color = helyes;
            Button2.color = Teves;
            Button3.color = Teves;
        }
        else
          if (SecuendButton.text == Taskok[jelenlegifeladat].megoldas)
        {
            Button1.color = Teves;
            Button2.color = helyes;
            Button3.color = Teves;
        }
        else
          if ("x" == Taskok[jelenlegifeladat].megoldas)
        {
            Button1.color = Teves;
            Button2.color = Teves;
            Button3.color = helyes;
        }
        StartCoroutine(Kovifeladat(1, 1));
    }

    public IEnumerator Kovifeladat(float a, float b)
    {
        float Time = Random.Range(a, b);
        yield return new WaitForSeconds(Time);
        Button1.color = simpla;
        Button2.color = simpla;
        Button3.color = simpla;
        FeladatOsztas();
    }
    public void FeladatOsztas()
    {
        hanyadikfeladat++;
        if (hanyadikfeladat == 6)
        {
            StartCoroutine(Vege());
            return;
        }
        Meheteazidozito = true;
        FeladatCounter.text = "5/" + hanyadikfeladat;
        int index = Random.Range(0, Taskok.Count);
        while (VolteMar[index] != 0)
        {
            index = Random.Range(0, Taskok.Count);
        }
        VolteMar[index] = 1;
        TaskPicture.sprite = Taskok[index].Feladat;
        jelenlegifeladat = index;
        int random2 = Random.Range(0, 2);
        if (random2 == 0)
        {
            FirstButton.text = Taskok[index].FirstAnswer;
            SecuendButton.text = Taskok[index].SecuendAnswer;
        }
        else
        {
            SecuendButton.text = Taskok[index].FirstAnswer;
            FirstButton.text = Taskok[index].SecuendAnswer;
        }


    }

    public void Retry()
    {
        Button1.color = simpla;
        Button2.color = simpla;
        Button3.color = simpla;
        EndGameobjects.SetActive(false);
        RadicalsOpcioMenu.SetActive(false);
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        hanyadikfeladat = 0;
        helyesvalaszok = 0;
        helytelenvalaszok = 0;
        ido = 0;
        TimeFelirat.SetActive(false); CorrectFelirat.SetActive(false); InCorrectFelirat.SetActive(false); TimeValue.SetActive(false); CorrectValue.SetActive(false); inCorrectValue.SetActive(false);
        Meheteazidozito = false;
        StartGameobjects.SetActive(false);
        GameGameobjects.SetActive(true);
        FeladatOsztas();
    }
    private IEnumerator Vege()
    {
        GameGameobjects.SetActive(false);
        EndGameobjects.SetActive(true);
        VeglegesTime.text = ido.ToString();
        veglegesHelytelen.text = "5/" + helytelenvalaszok;
        VeglegesHelyes.text = "5/" + helyesvalaszok;
        if ((Database.Pont[2] == 0||Database.Pont[2]>ido)&&helyesvalaszok==5&&helytelenvalaszok==0)
        {
            Database.Pont[2] = ido;
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
}
