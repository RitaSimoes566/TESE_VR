using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public float targetTime = 120.0f;
    [SerializeField] private GameObject scoreUI;
    private TextMeshProUGUI timeDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeDisplay = scoreUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //countdown
        if (targetTime >= 0)
        {
            targetTime -= Time.deltaTime;
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
    }

    void ResetScore()
    {

    }
}
