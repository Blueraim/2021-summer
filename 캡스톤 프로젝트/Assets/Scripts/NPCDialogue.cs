using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public Text npcName;
    public Text npcText;
    public NPC npc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.gameObject.tag == "Player")
            {
                npcName.text = npc.GetName();
                npc.ShowText(npcText);
            }
        }
    }
}
