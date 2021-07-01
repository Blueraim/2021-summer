using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScenario : MonoBehaviour
{
    public TextAsset txtFile;
    public Text txt;

    private string[] sentences;
    private int currentTime;
    private bool timer;
    private float time;


    void Start()
    {
        string currentText = txtFile.text.Substring(0, txtFile.text.Length - 1);
        sentences = currentText.Split('\n');
    }

    public void ShowScenario(GameObject active)
    {
        active.SetActive(true);

        for (int i = 0; i < sentences.Length; i++)
        {
            txt.text += sentences[i];
            txt.text += "\n\n";
        }
    }
}
