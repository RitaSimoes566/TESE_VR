using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    public float targetTime = 120.0f;

    [SerializeField] private TextMeshProUGUI timeDisplay;
    [SerializeField] private ParticleSystem endPart;
    [SerializeField] private AudioManager audioM;

    public bool isStar;
    public bool timerPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endPart.Stop();
        isStar = false;
        timerPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown
        if (targetTime > 0 && !timerPause)
        {
            targetTime -= Time.deltaTime;
        }

        if(targetTime <= 0.0f && !isStar)
        {
            endPart.Play();
            audioM.Victory();
            isStar = true;
        }

        //display
        int min = (int)targetTime / 60;
        int sec = (int)targetTime % 60;

        if (sec >= 10)
        {
            timeDisplay.SetText("0" + min.ToString() + ":" + sec.ToString());

        }else
        {
            timeDisplay.SetText("0" + min.ToString() + ":0" + sec.ToString());
        }

    }

    public void ResetTimer()
    {
        targetTime = 120.0f;
        timerPause = false;
        isStar = false;
    }

    public void PauseTimer()
    {
        timerPause = !timerPause;
    }
}
