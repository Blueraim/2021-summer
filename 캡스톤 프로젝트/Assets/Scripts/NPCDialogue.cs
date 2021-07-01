using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public Text npcName;
    public Text npcText;
    public Image textBox;
    public NPC npc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.gameObject.tag == "Player")
            {
                textBox.gameObject.SetActive(true);
                npcName.text = npc.GetName();
                npc.ShowText(npcText);
            }
        }
    }
}
