using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Player : MonoBehaviour
{
    public InputField inputName;
    public Flowchart flowchart;

    private string playerName;
    private Sprite playerSprite;
    private Character player;

    void Start()
    {
        player = GetComponent<Character>();
    }

    public void SetName()
    {
        playerName = inputName.text;
        player.NameText = playerName;

        Debug.Log(player.NameText);
    }

    public void SetSprite(Sprite sprite)
    {
        playerSprite = sprite;
        player.Portraits.Add(playerSprite);

        flowchart.ExecuteBlock("Scenario");
    }
}