using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public Text npcName;
    public Text npcText;
    public Image textBox;

    private static NPC npc;

    public void GetDialogue(NPC collsionNPC)
    {
        npc = collsionNPC;

        textBox.gameObject.SetActive(true);
        npcName.text = npc.GetName();
        Debug.Log("이름 불러오기");
        npc.ShowQuestion(npcText);
    }

    public void TextBoxOff()
    {
        textBox.gameObject.SetActive(false);
    }
}
