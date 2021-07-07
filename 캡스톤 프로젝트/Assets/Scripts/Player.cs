using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    private NPCDialogue npcDialogue;

    private static string playerName;
    private static Sprite playerSprite;
    private static Animator animator;
    private static RuntimeAnimatorController animation;
    private GameObject scanObject;

    private bool isTigger = false;
    private bool outSide = false;

    void Start()
    {
        /*if(SceneManager.GetActiveScene().name == "Prologue")
        {
            
        }
        else if(SceneManager.GetActiveScene().name == "CorridorScene")
        {
            InputAnimator();
        }*/
    }

    void Update()
    {
        if(scanObject != null && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(scanObject.name);
            npcDialogue = scanObject.GetComponent<NPCDialogue>();

            npcDialogue.GetDialogue(scanObject);
            gameManager.GetNPC(scanObject);
            scanObject = null;
        }

        if(isTigger && Input.GetKeyDown(KeyCode.F) && !outSide)
        {
            transform.Translate(0, -3000, 0);
            outSide = true;
        }
        else if(isTigger && Input.GetKeyDown(KeyCode.F) && outSide)
        {
            transform.Translate(0, +3000, 0);
            outSide = false;
        }
    }

    public void SetName(Text name)
    {
        playerName = name.text;
    }

    public string GetName() { return playerName; }

    public void SetAnimator(Sprite sprite)
    {
        if(sprite.name == "Player_girl_0")
        {
            
        }
        else
        {
            animation = Resources.Load("Animation/Player_boy/Boy") as RuntimeAnimatorController;
        }
    }

    public void InputAnimator()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animation;
    }

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
