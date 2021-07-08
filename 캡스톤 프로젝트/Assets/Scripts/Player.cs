using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera Camera;

    private NPCDialogue npcDialogue;

    private static string playerName;
    private GameObject scanObject;
    private GameManager gameManager;

    private bool isTigger = false;
    private bool outSide = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Scene"))
        {
            GameObject manager = GameObject.Find("Main Camera");
            gameManager = manager.GetComponentInChildren<GameManager>();
        }
    }

    void Update()
    {
        if (scanObject != null && Input.GetKeyDown(KeyCode.Space))
        {
            NPC collision = scanObject.GetComponent<NPC>();

            if (collision.InteractionCheck())
            {
                Debug.Log(scanObject.name);
                npcDialogue = scanObject.GetComponent<NPCDialogue>();
                npcDialogue.GetDialogue(collision);
                gameManager.GetNPC(collision);
            }
        }

        if (isTigger && Input.GetKeyDown(KeyCode.F) && !outSide)
        {
            transform.Translate(0, -3000, 0);

            outSide = true;

            Camera.orthographicSize = 1000;
        }
        else if (isTigger && Input.GetKeyDown(KeyCode.F) && outSide)
        {
            transform.Translate(0, +3000, 0);

            outSide = false;

            Camera.orthographicSize = 800;
        }
    }

    public void SetName(Text name)
    {
        playerName = name.text;
    }

    public string GetName() { return playerName; }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            scanObject = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            scanObject = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "WrapZone")
        {
            isTigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WrapZone")
        {
            isTigger = false;
        }
    }
}
