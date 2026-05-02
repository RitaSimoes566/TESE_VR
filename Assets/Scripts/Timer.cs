using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public float targetTime = 120.0f;
    [SerializeField] private GameObject scoreUI;
    private TextMeshProUGUI timeDisplay;

    [SerializeField] private GameObject starObj;
    private ParticleSystem starPart;

    private bool isStar;
    private bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeDisplay = scoreUI.GetComponentInChildren<TextMeshProUGUI>();
        starPart = starObj.GetComponent<ParticleSystem>();

        starPart.Stop();
        isStar = false;
        isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        //countdown
        if (targetTime >= 0 && !isPaused)
        {
            targetTime -= Time.deltaTime;
        }

        if(targetTime < 0)
        {
            starPart.Play();
        }

        //display
        int min = (int)targetTime / 60;
        int sec = (int)targetTime % 60;

        if (sec >= 10)
        {
            timeDisplay.SetText("Tempo restante: \n" + min + " : " + sec.ToString());

        }else
        {
            timeDisplay.SetText("Tempo restante: \n" + min + " : 0" + sec.ToString());
        }

        //timeDisplay.SetText("Score: \n" + scoreDisplay.score);
    }

    public void ResetTimer()
    {
        targetTime = 120.0f;
        isPaused = false;
    }

    public void PauseTimer()
    {
        isPaused = !isPaused;
    }
}
