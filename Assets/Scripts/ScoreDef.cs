using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDef : MonoBehaviour
{
    public Image[] starImages;   // 5 Image components (grey star sprites)

    public Sprite greyStar;
    public Sprite yellowStar;

    public TextMeshProUGUI txt;
    public StarParticles starPart;

    public AudioManager scoreAudio;
    bool isVictory = false;

    private Flying fly;
    public int score;

    //public int score;

    void Awake()
    {
        score = fly.score;

        // all stars start grey
        ResetScore();
        txt.SetText("PONTUAÇÃO:");
        starPart.StarsStop();
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

    }

}