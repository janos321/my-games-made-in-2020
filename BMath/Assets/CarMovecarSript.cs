using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarMovecarSript : MonoBehaviour
{
    public GameObject checkpoints;
    public GameObject Car;
    public TMP_Text RaceCounter;
    public GameObject AutoIndulas;
    public GameObject Game5;

    private Transform target;
    private List<Transform> checkpoint = new List<Transform>();
    private float boost = 1;
    public static int presentcheckpoint=-1;
    private int kor = 0;
    void Start()
    {
        for(int i=0;i<checkpoints.transform.childCount;i++)
        {
            checkpoint.Add(checkpoints.transform.GetChild(i));
        }
    }

    void Update()
    {
        if (gameObject.active)
        {
            if (presentcheckpoint == -1 || Vector3.Distance(target.position, Car.transform.position) < 0.1f)
            {
                if (presentcheckpoint == -1)
                {
                    Car.GetComponent<Image>().sprite = Game5.GetComponent<Game5>().CarsSprites[Game5.GetComponent<Game5>().CarPick].Kep;
                    Car.transform.localScale = Game5.GetComponent<Game5>().CarsSprites[Game5.GetComponent<Game5>().CarPick].Scale;
                    boost = 1;
                    Car.transform.position = AutoIndulas.transform.position;
                    kor = 1;
                    RaceCounter.text = "3/1";
                }
                presentcheckpoint++;
                if (checkpoint.Count == presentcheckpoint && kor == 1)
                {
                    presentcheckpoint = 0;
                    kor = 2;
                    RaceCounter.text = "3/2";
                }
                else
                  if (checkpoint.Count == presentcheckpoint && kor == 2)
                {
                    presentcheckpoint = 0;
                    kor = 3;
                    RaceCounter.text = "3/3";
                }
                else
                 if (checkpoint.Count == presentcheckpoint && kor == 3)
                {
                    Game5.GetComponent<Game5>().End();
                    gameObject.SetActive(false);
                    return;
                }
                target = checkpoint[presentcheckpoint];
            }
            Vector2 dir = target.position - Car.transform.position;
            if (target != null)
            {
                Vector2 targetDirection = target.position - Car.transform.position;
                float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                Car.transform.rotation = Quaternion.Lerp(Car.transform.rotation, targetRotation, Time.deltaTime * 10);
            }
            Car.transform.Translate(dir.normalized * boost * Time.deltaTime/3, Space.World);
        }
    }
    public void Boost()
    {
        boost+=0.4f;
        StartCoroutine(Minusz(9, 11));
    }

    IEnumerator Minusz(float a,float b)
    {
        float random = Random.Range(a, b);
        yield return new WaitForSeconds(random);
        boost-=0.4f;
    }
}
