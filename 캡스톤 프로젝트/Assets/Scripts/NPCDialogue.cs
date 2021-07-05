using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public Text npcName;
    public Text npcText;
    public Image textBox;

    private NPC npc;

    public void GetDialogue(GameObject collisionNPC)
    {
        npc = collisionNPC.GetComponent<NPC>();

        textBox.gameObject.SetActive(true);
        npcName.text = npc.GetName();
        npc.ShowText(npcText);
    }
}
