using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static string playerName;
    private static Sprite playerSprite;

    void Start()
    {
        if (playerSprite != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite;
        }
    }

    public void SetName(Text name)
    {
        playerName = name.text;
    }

    public void SetSprite(Sprite sprite)
    {
        playerSprite = sprite;
    }
}
