using System.Collections.Generic;
using UnityEngine;

public class AudioManagerAtk : MonoBehaviour
{
    [SerializeField] private BallManager ballManager;
    [SerializeField] private ScoreAtk sco;

    [SerializeField] private AudioSource timerSource;
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioSource enemySource;

    [SerializeField] private List<AudioSource> ballSource = new List<AudioSource>();

    [SerializeField] private AudioClip victorySfx;
    [SerializeField] private AudioClip hurtSfx;
    [SerializeField] private AudioClip bgMusic;

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
        if (sco.isPaused)
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

    /*public void ScoreIncrease()
    {
        scoreSource.clip = correctSfx;
        scoreSource.Play();
    }*/

    public void Victory()
    {
        timerSource.clip = victorySfx;
        timerSource.Play();
    }

    public void GetAudioOfBall(GameObject BallObj)
    {
            ballSource.Add(BallObj.GetComponentInChildren<AudioSource>());
    }

    public void HurtMonster()
    {
       //int b = beeCode.bees.IndexOf(gameBee);
        //beeSource[b].clip = hurtSfx;
        //beeSource[b].Play();
    }
}
