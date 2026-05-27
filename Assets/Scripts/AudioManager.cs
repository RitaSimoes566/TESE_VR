using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private BeeSpawn beeManager;

    public AudioSource scoreSource;
    public AudioSource playerSource;

    public List<AudioSource> beeSource = new List<AudioSource>();

    public AudioClip correctSfx;
    public AudioClip victorySfx;
    public AudioClip hurtSfx;
    public AudioClip bgMusic;

    private void Awake()
    {
        playerSource.loop = true;
    }
    public void PlayBgMusic()
    {
        playerSource.clip = bgMusic;
        playerSource.Play();
    }

    public void PauseBgMusic()
    {
        if (beeManager.isPaused)
        {
            playerSource.Pause();
        } else
        {
            playerSource.UnPause();
        }
    }

    public void StopBgMusic()
    {
        playerSource.Stop();
    }

    public void ScoreIncrease()
    {
        scoreSource.clip = correctSfx;
        scoreSource.Play();
    }

    public void Victory()
    {
        scoreSource.clip = victorySfx;
        scoreSource.Play();
    }

    public void GetAudioOfBee(GameObject BeeObj)
    {
            beeSource.Add(BeeObj.GetComponentInChildren<AudioSource>());
    }

    public void HurtBee(int b)
    {
       //int b = beeCode.bees.IndexOf(gameBee);
        beeSource[b].clip = hurtSfx;
        beeSource[b].Play();
    }
}
