using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    [Header("사운드 등록")]
    [SerializeField] Sound bgmSounds;

    [Header("bgm 플레이어")]
    [SerializeField] AudioSource bgmPlayer;


    // Start is called before the first frame update
    void Start()
    {
        PlaySpringBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySpringBGM()
    {
        bgmPlayer.clip = bgmSounds.clip;
        bgmPlayer.Play();
    }
}
