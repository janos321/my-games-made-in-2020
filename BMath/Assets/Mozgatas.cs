using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozgatas : MonoBehaviour
{
    public Vector3 EredetiHely=new Vector3(0,0,0);
    private bool mozogjone = false;
    public GameObject Game200IQ;
    public int Value;
    public int index=0;
    void Start()
    {
        EredetiHely = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Game200IQ.GetComponent<Game200IQ>().Meheteazidozito)
        {
            if (mozogjone && gameObject.active)
            {
                Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                click.z = 0;
                transform.position = click;
            }
        }
    }
    private void OnMouseDown()
    {
        if (Game200IQ.GetComponent<Game200IQ>().Meheteazidozito) {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            click.z = 0;
            if (MENUMainSrcipt.Bennevane(gameObject.transform, click))
            {
                for (int i = 0; i < Game200IQ.GetComponent<Game200IQ>().answrsButton.Count; i++)
                {
                    if (Game200IQ.GetComponent<Game200IQ>().answrsButton[i] != gameObject)
                    {
                        Game200IQ.GetComponent<Game200IQ>().answrsButton[i].GetComponent<BoxCollider>().enabled = false;
                    }
                }
                mozogjone = true;
            }
        }
    }
    private void OnMouseUp()
    {
        if (Game200IQ.GetComponent<Game200IQ>().Meheteazidozito)
        {
            for (int i = 0; i < Game200IQ.GetComponent<Game200IQ>().answrsButton.Count; i++)
            {
                Game200IQ.GetComponent<Game200IQ>().answrsButton[i].GetComponent<BoxCollider>().enabled = true;
            }
            mozogjone = false;
            Game200IQ.GetComponent<Game200IQ>().Belerak(gameObject.transform.position, index);
            transform.position = EredetiHely;
        }
    }
}
