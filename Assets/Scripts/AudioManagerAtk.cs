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
    [SerializeField] private AudioClip[] footsteps = new AudioClip[2];
    public List<AudioClip> ballSound = new List<AudioClip>();

    private void Awake()
    {
        playerSource.loop = true;
        enemySource.volume = 0.25f;
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

    public void VictorySnd()
    {
        timerSource.clip = victorySfx;
        timerSource.Play();
    }

    public void AddAudioBall(GameObject ballObj)
    {
        AudioSource ballAudio = ballObj.GetComponentInChildren<AudioSource>();
            ballSource.Add(ballAudio);
    }

    /*public void HurtMonster()
    {
       //int b = beeCode.bees.IndexOf(gameBee);
        //beeSource[b].clip = hurtSfx;
        //beeSource[b].Play();
    }*/

    public void BallAudioHit(int ballIndex)
    {
        ballSource[ballIndex].clip = ballSound[0];
        ballSource[ballIndex].Play();
    }

    public void BallAudioBounce(int ballIndex)
    {
        ballSource[ballIndex].clip = ballSound[1];
        ballSource[ballIndex].Play();
    }

    public void BallAudioPickUp( GameObject ballObj )
    {
        AudioSource ballAudio = ballObj.GetComponentInChildren<AudioSource>();

        ballAudio.clip = ballSound[2];
        ballAudio.Play();
    }

    public void ClearBallAudio()
    {
        ballSource.Clear();
    }

    public void DinoPlayStepR()
    {
        enemySource.clip = footsteps[0];
        enemySource.Play();
    }

    public void DinoPlayStepL()
    {
        enemySource.clip = footsteps[1];
        enemySource.Play();
    }
}
