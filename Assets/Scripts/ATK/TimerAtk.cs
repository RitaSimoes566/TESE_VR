using UnityEngine;
using System.Collections;
using TMPro;

public class TimerAtk : MonoBehaviour
{
    public float targetTime = 120.0f;

    [SerializeField] private TextMeshProUGUI timeDisplay;
    [SerializeField] private ParticleSystem starPart;
    [SerializeField] private AudioManagerAtk audioM;
    [SerializeField] private ScoreAtk score;
    private bool isStar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starPart.Stop();
        isStar = false;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown
        if (targetTime > 0 && score.isPaused == false)
        {
            targetTime -= Time.deltaTime;
        }

        /*if(targetTime <= 0.0f && !isStar)
        {
            starPart.Play();
            audioM.Victory();
            isStar = true;
        }*/

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
        isStar = false;
    }

    public void HideTimer()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
