using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Language : MonoBehaviour
{
    public Read LANG;
    private void Start()
    {
        StartCoroutine(varakoztatas(0.2f));
    }

    IEnumerator varakoztatas(float a)
    { 
        yield return new WaitForSeconds(a);
        MENUMainSrcipt.Hangallitas2.value = Database.Pont[1];
        MENUMainSrcipt.hangletrehozasa(gameObject,MENUMainSrcipt.Zene2);
        LanguagesChange((int)Database.Pont[0], LANG);

    }
    [System.Serializable]
    public class Translate
    {
        public List<TMP_Text> Text = new List<TMP_Text>();
        public List<string> Languasges = new List<string>();
    }
    [System.Serializable]
    public class Read
    {
        public List<int> Langs = new List<int>();
        public List<Translate> TextCount = new List<Translate>();
    }

    public void ChooseLanguages(int a)
    {
        LanguagesChange(a, LANG);
        FajlDatabase.WriteIntoTxtFile();
    }

    public static void LanguagesChange(int Lang, Read LANg)
    {
        Database.Pont[0] = Lang;
        int index = Lang;
        for (int i = 0; i < LANg.TextCount.Count; i++)
        {
            for (int j = 0; j < LANg.TextCount[i].Text.Count; j++)
            {
                if (LANg.TextCount[i].Languasges[index].IndexOf('|') == -1)
                {
                    if (LANg.TextCount[i].Text[j] != null)
                    {
                        LANg.TextCount[i].Text[j].text = LANg.TextCount[i].Languasges[index];
                    }
                    else
                    {
                        Debug.Log("Hiányzik ez a txt:");
                        Debug.Log("sor:" + i);
                        Debug.Log("Oszlop:" + j);
                    }
                }
                else
                {
                    string[] split = LANg.TextCount[i].Languasges[index].Split('|');
                    if (LANg.TextCount[i].Text[j] != null)
                    {
                        LANg.TextCount[i].Text[j].text = split[0];
                    }
                    else
                    {
                        Debug.Log("Hiányzik ez a txt:");
                        Debug.Log("sor:" + i);
                        Debug.Log("Oszlop:" + j);
                    }
                    for (int k = 1; k < split.Length; k++)
                    {
                        LANg.TextCount[i].Text[j].text += "\n" + split[k];
                    }
                }
            }
        }
    }
}
