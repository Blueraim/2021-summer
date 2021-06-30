using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[CommandInfo("Narrative",
             "Say Scenario",
             "Get the file and Writes text in a dialog box.")]
public class SayScenario : Command
{
    public TextAsset txtFile;
    public Flowchart flowchart;

    private string[] sentences;
    private Say say;
    private Command command;
    private Block block;

    void Start()
    {
        string currentText = txtFile.text.Substring(0, txtFile.text.Length - 1);
        sentences = currentText.Split('\n');
    }

    public override void OnEnter()
    {
        int j = 0;
        block = flowchart.FindBlock("Scenario");

        for (int i = 0; i < block.CommandList.Count; i++)
        {
            if (block.CommandList[i].GetType().Name == "Say")
            {
                say = (Say)block.CommandList[i];
                say.SetStandardText(sentences[j]);
                j++;
            }
        }

        Continue();
    }
}
