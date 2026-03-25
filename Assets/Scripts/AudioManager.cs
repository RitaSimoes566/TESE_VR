using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource scoreSource;
    public AudioClip correctSfx;
    public AudioClip victorySfx;


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
}
