using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using System.IO;
using TMPro;
public class Game2 : MonoBehaviour
{
    public GameObject RadicalsMenuOpsion, Game, end, start;
    public TMP_Text TimeCounter;
    public TMP_Text EndPoint;
    public GameObject TimeFelirat, TimeValue;
    public GameObject Back1, Back2;
    public TMP_Text TimeTXT;
    public GameObject Timepanel;
    public GameObject TimeMutato;
    public GameObject HelpPanel;
    public GameObject HelpButton;

    private float ido=0;
    public static int pontok;
    //private float ido;
    //private bool Meheteazidozito = false;
    void Start()
    {
        pontok = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(pontok.ToString()!= TimeCounter.text)
        {
            TimeCounter.text = pontok.ToString();
        }

                ido = ido + Time.deltaTime;
                ido = (float)System.Math.Round(ido, 3);

    }
    public void Back()
    {
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        ido = 0;
        pontok = 0;
        Back1.SetActive(false);
        Back2.SetActive(true);
        RadicalsMenuOpsion.SetActive(true);
        Game.SetActive(false);
        end.SetActive(false);
        start.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Retry()
    {
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        ido = 0;
        pontok = 0;
        end.SetActive(false);
        Back1.SetActive(true);
        Back2.SetActive(false);
        TimeFelirat.SetActive(false); TimeValue.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
    }
    public void StartButton()
    {
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        ido =0;
        Back1.SetActive(true);
        Back2.SetActive(false);
        TimeFelirat.SetActive(false); TimeValue.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
    }

    public void End()
    {
        Back1.SetActive(false);
        Back2.SetActive(true);
        Game.SetActive(false);
        Timepanel.SetActive(false);
        TimeMutato.SetActive(false);
        TimeFelirat.SetActive(false);
        TimeValue.SetActive(false);
        TimeMutato.transform.position = Timepanel.transform.position;
        TimeValue.transform.position = TimeFelirat.transform.position;
        TimeTXT.text = ido.ToString();
        if ((Database.Pont[3] <pontok))
        {
            Database.Pont[3] = pontok;
            FajlDatabase.WriteIntoTxtFile();
        }
        EndPoint.text = pontok.ToString();
        end.SetActive(true);
        StartCoroutine(End2());
    }

    public IEnumerator End2()
    {
        yield return new WaitForSeconds(0.7f);
        TimeFelirat.SetActive(true);
        TimeValue.transform.position = TimeFelirat.transform.position;
        TimeValue.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Move(0.8f, TimeValue, TimeValue.transform.position, new Vector3(TimeValue.transform.position.x, TimeValue.transform.position.y - 2, TimeValue.transform.position.z)));
        yield return new WaitForSeconds(1f);
        Timepanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        TimeMutato.SetActive(true);
        StartCoroutine(Move(0.8f, TimeMutato, TimeMutato.transform.position, new Vector3(TimeMutato.transform.position.x, TimeMutato.transform.position.y - 2, TimeMutato.transform.position.z)));
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
