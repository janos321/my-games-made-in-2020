using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject Position1, Position2;
    public float Timek = 0.8f;
    void Start()
    {
        StartCoroutine(Move());
    }

public IEnumerator Move()
    {
        float Timer = 0;
        while(Timer<Timek)
        {
            gameObject.transform.position = Vector3.Lerp(Position1.transform.position, Position2.transform.position, Timer / Timek);
            yield return Timer += Time.deltaTime;
        }
        gameObject.transform.position = Position2.transform.position;
    }
}
