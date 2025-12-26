using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeaderBoardPlacesSript : MonoBehaviour
{
    public TMP_Text Helyezes, nev, Pont;
    public GameObject Trofea;
    public static bool mozoghate = false;

    private void OnMouseDown()
    {
        MENUMainSrcipt.elozoClick= Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        mozoghate = true;
    }
    private void OnMouseUp()
    {
        mozoghate = false;
    }
}
