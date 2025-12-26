using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Game7 : MonoBehaviour
{
    public GameObject RadicalsMenuOpsion, Game, end, start;
    public TMP_Text TimeCounter;
    public GameObject TimeCounterTabla, ShootTable, TimeFelirat, ShootFelirat;
    public TMP_Text ShootsTXT, TimeTXT;
    public GameObject HelpPanel;
    public GameObject HelpButton;
    public GameObject Joystick;
    public GameObject Mutato;
    public float MutatoSpeed=1;
    public GameObject Gun;
    public List<tabladata> Tablak = new List<tabladata>();
    public List<feladat> Taskok = new List<feladat>();
    public GameObject Tolto;
    public float RealodaingTime=2;
    public TMP_Text ShootingpointCounter;
    public TMP_Text pointMutato;
    public GameObject TaskMutato;
    public int maxpoint = 30;
    public GameObject handle;

    private int[] VolteMar = new int[40];
    private float ido = 0,shoot=0,elozoshoot=0;
    private int PointCounter=0,elozotabla=-1,jelenlegitask=-1;
    public static float shootingTime=0;
    private tabladata Jelenlegitabla;

    [System.Serializable]
    public class tabladata
    {
        public GameObject Tabla;
        public GameObject Celpont;
        public GameObject Kinti;
        public GameObject Benti;
    }

    [System.Serializable]
    public class feladat
    {
        public Sprite Task;
        public bool helyes;
    }
    private void Start()
    {
    }
    void Update()
    {
        ido = ido + Time.deltaTime;
        ido = (float)System.Math.Round(ido, 3);
        TimeCounter.text = ido.ToString();
        if(shootingTime!=RealodaingTime)
        {
            shootingTime += Time.deltaTime;
            Tolto.GetComponent<Image>().fillAmount = 1 - shootingTime / RealodaingTime;
            if(shootingTime>=RealodaingTime)
            {
                Tolto.GetComponent<Image>().fillAmount = 0;
                shootingTime = RealodaingTime;
            }
        }
        if(Input.GetKeyDown("w"))
        {
            loves();
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(Joystick.GetComponent<FixedJoystick>().Horizontal, Joystick.GetComponent<FixedJoystick>().Vertical);

        Mutato.transform.Translate(dir.normalized * MutatoSpeed * Time.deltaTime / 3, Space.World);
        if(Mutato.transform.position.x>3f)
        {
            Mutato.transform.position = new Vector3(3f, Mutato.transform.position.y, Mutato.transform.position.z);
        }
        else
        if (Mutato.transform.position.x < -3f)
        {
            Mutato.transform.position = new Vector3(-3f, Mutato.transform.position.y, Mutato.transform.position.z);
        }
        if (Mutato.transform.position.y > 2f)
        {
            Mutato.transform.position = new Vector3( Mutato.transform.position.x,2f, Mutato.transform.position.z);
        }
        else
        if (Mutato.transform.position.y < -4f)
        {
            Mutato.transform.position = new Vector3(Mutato.transform.position.x, -4f, Mutato.transform.position.z);
        }
        Gun.transform.rotation= Quaternion.Euler((Mutato.transform.position.x + 2) * 10, (Mutato.transform.position.x+2)*10, 0);
        //Mutato.transform.position = new Vector3(Joystick.GetComponent<FixedJoystick>().Horizontal * MutatoSpeed, Joystick.GetComponent<FixedJoystick>().Vertical * MutatoSpeed, Mutato.transform.position.z);
    }

    public void Back()
    {
        ujra();
        RadicalsMenuOpsion.SetActive(true);
        Game.SetActive(false);
        Joystick.SetActive(false);
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
        Joystick.SetActive(true);
        NextTablaAndTask();
    }

    public void StartButton()
    {
        ujra();
        end.SetActive(false);
        start.SetActive(false);
        Game.SetActive(true);
        Joystick.SetActive(true);
        NextTablaAndTask();
    }

    private void ujra()
    {
        handle.transform.position = Joystick.transform.position;
        for (int i=0;i<Tablak.Count;i++)
        {
            Tablak[i].Tabla.transform.position = Tablak[i].Benti.transform.position;
            Tablak[i].Tabla.SetActive(false);
        }
        pointMutato.text = "";
        ShootingpointCounter.text = maxpoint.ToString() + "/" + 0;
        for (int i = 0; i < VolteMar.Length; i++)
        {
            VolteMar[i] = 0;
        }
        elozotabla = -1;
        PointCounter = 0;
        ido = 0;
        Tolto.GetComponent<Image>().fillAmount = 0;
        Mutato.transform.position = new Vector3(0, 0, 0);
        HelpPanel.SetActive(false);
        HelpButton.SetActive(true);
        shoot = 0;
        shootingTime = RealodaingTime;
    }

    public void NextTablaAndTask()
    {
        int random = -1, szamol = 0 ;
        elozoshoot = shoot;
        while (random==-1)
        {
            szamol++;
            if(szamol==1000)
            {
                for (int i = 0; i < VolteMar.Length; i++)
                {
                    VolteMar[i] = 0;
                }
            }
            random = Random.Range(0, Taskok.Count);
            if(VolteMar[random]!=0)
            {
                random = -1;
            }
        }
        VolteMar[random] = 1;
        TaskMutato.GetComponent<Image>().sprite = Taskok[random].Task;
        jelenlegitask = random;
        random = -1;
        while(random==-1)
        {
            random = Random.Range(0, Tablak.Count);
            if (random==elozotabla)
            {
                random = -1;
            }
        }
        Jelenlegitabla = Tablak[random];
        Jelenlegitabla.Tabla.SetActive(true);
        elozotabla = random;
       StartCoroutine( TablaMozgas(Jelenlegitabla,1.5f,2));
    }
    public void End()
    {
        Game.SetActive(false);
        Joystick.SetActive(false);
        TimeCounterTabla.SetActive(false);
        ShootTable.SetActive(false);
        TimeFelirat.SetActive(false);
        ShootFelirat.SetActive(false);
        ShootTable.transform.position = ShootFelirat.transform.position;
        TimeCounterTabla.transform.position = TimeFelirat.transform.position;
        TimeTXT.text = ido.ToString();
        ShootsTXT.text = shoot.ToString();
        if ((Database.Pont[6] > ido) || Database.Pont[6] == 0)
        {
            Database.Pont[6] = ido;
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
        ShootFelirat.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ShootTable.SetActive(true);
        StartCoroutine(Move(0.8f, ShootTable, ShootTable.transform.position, new Vector3(ShootTable.transform.position.x, ShootTable.transform.position.y - 2, ShootTable.transform.position.z)));
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

    IEnumerator TablaMozgas(tabladata Tabla, float kimenobemeno,float kintmarado)
    {
        float timer = 0;
        while(timer< kimenobemeno)
        {
            Tabla.Tabla.transform.position = Vector3.Lerp(Tabla.Benti.transform.position, Tabla.Kinti.transform.position, timer / kimenobemeno);
            yield return timer += Time.deltaTime;  
        }
        Tabla.Tabla.transform.position = Tabla.Kinti.transform.position;
        yield return new WaitForSeconds(kintmarado);
        if(Game.active)
        {
            if(elozoshoot==shoot&& !Taskok[jelenlegitask].helyes)
            {
                PointCounter += 1;
                StartCoroutine(pointmutatoo(1));
            }
            NextTablaAndTask();
        }
        timer = 0;
        while (timer < kimenobemeno)
        {
            Tabla.Tabla.transform.position = Vector3.Lerp(Tabla.Kinti.transform.position,Tabla.Benti.transform.position, timer / kimenobemeno);
            yield return timer += Time.deltaTime;
        }
        Tabla.Tabla.transform.position = Tabla.Benti.transform.position;
        Tabla.Tabla.SetActive(false);
    }

    public void loves()
    {
        if(shootingTime==RealodaingTime)
        {
            shoot++;
            shootingTime = 0;
            float tavolsag = Vector3.Distance(Jelenlegitabla.Celpont.transform.position, Mutato.transform.position)*9;
            if(Taskok[jelenlegitask].helyes)
            {
                if(tavolsag<=1)
                {
                    PointCounter += 6;
                    StartCoroutine(pointmutatoo(8));
                }
                else
                    if(tavolsag<=3)
                {
                    PointCounter += 4;
                    StartCoroutine(pointmutatoo(4));
                }
                else
                    if(tavolsag<=5)
                {
                    PointCounter += 2;
                    StartCoroutine(pointmutatoo(2));
                }
            }
            else
            {
                if (tavolsag <= 1)
                {
                    PointCounter -= 3;
                    StartCoroutine(pointmutatoo(-4));
                }
                else
                if (tavolsag <= 3)
                {
                    PointCounter -= 2;
                    StartCoroutine(pointmutatoo(-2));
                }
                else
                if (tavolsag <= 5)
                {
                    PointCounter -= 1;
                    StartCoroutine(pointmutatoo(-1));
                }
            }
            if(tavolsag>5)
            {
                StartCoroutine(pointmutatoo(0));
            }


        }
    }

    IEnumerator pointmutatoo(int point)
    {
        if (point > 0)
        {
            pointMutato.text = "+"+point.ToString();
        }
        else
        {
            pointMutato.text = point.ToString();
        }
        if (PointCounter>= maxpoint)
        {
            End();
        }
        float xd = 1.5f;
            yield return new WaitForSeconds(xd);
        pointMutato.text = "";
        ShootingpointCounter.text = maxpoint.ToString() + "/" + PointCounter.ToString();
    }

}
