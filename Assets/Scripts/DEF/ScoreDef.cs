using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDef : MonoBehaviour
{
    [SerializeField] private Image[] starImages;   // 5 Image components (grey star sprites)

    [SerializeField] public Sprite greyStar;
    [SerializeField] public Sprite yellowStar;

    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private StarParticles starPart;

    [SerializeField] private AudioManager scoreAudio;
    [SerializeField] private bool isVictory = false;

    public Flying fly;

    void Awake()
    {
        // all stars start grey
        ResetScore();
        txt.SetText("PONTUAÇÃO:");
        starPart.StarsStop();

        fly = fly.GetComponent<Flying>();
    }

    void Update()
    {
        if (fly.score < starImages.Length)
        {
            
            for (int i = 0; i < starImages.Length; i++)
            {
                if (i < fly.score)              // e.g. score = 2 → first 2 stars yellow
                    starImages[i].sprite = yellowStar;
                else
                    starImages[i].sprite = greyStar;
            }
            txt.SetText("PONTUAÇÃO:");
            starPart.StarsStop();
        }
        else
        {
            if (isVictory == false)
            {
                for (int i = 0; i < starImages.Length; i++)
                {
                    starImages[i].sprite = yellowStar;
                }
                fly.score = starImages.Length + 1;
                txt.SetText("CONSEGUISTE!");

                starPart.StarsPlay();
                scoreAudio.Victory();
                isVictory = true;
            }

        }
    }

    public void ResetScore()
    {
        fly.score = 0;

        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].sprite = greyStar;
        }

        txt.SetText("PONTUAÇÃO:");
        isVictory = false;

        StopAllCoroutines();
        StartCoroutine(fly.FlyRoutine());

    }

}