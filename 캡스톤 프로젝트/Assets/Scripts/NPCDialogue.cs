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

        if (!npc.GetInteraction())
        {
            textBox.gameObject.SetActive(true);
            npcName.text = npc.GetName();
            npc.ShowQuestion(npcText);
        }
    }
}
