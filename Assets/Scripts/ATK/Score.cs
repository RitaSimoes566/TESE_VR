using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private EnemyMov enemy;
    [SerializeField] private Image[] starImages;

    [SerializeField] private Sprite greyStar;
    [SerializeField] private Sprite yellowStar;

    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private StarParticles starPart;

    [SerializeField] private AudioManager scoreAudio;
    bool isVictory = false;

    //public int score;

    void Awake()
    {
        //score = ball.score;


        // all stars start grey
        ResetScore();
        txt.SetText("PONTUAÇÃO:");
        starPart.StarsStop();
    }

    void Update()
    {
        if (enemy.scoreAtk < starImages.Length)
        {
            
            for (int i = 0; i < starImages.Length; i++)
            {
                if (i < enemy.scoreAtk)        
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
                enemy.scoreAtk = starImages.Length + 1;
                txt.SetText("CONSEGUISTE!");

                starPart.StarsPlay();
                scoreAudio.Victory();

                enemy.StopCoroutine("MoveCycle");
                isVictory = true;
            }

        }
    }

    public void ResetScore()
    {
        enemy.scoreAtk = 0;

        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].sprite = greyStar;
        }

        txt.SetText("PONTUAÇÃO:");
        isVictory = false;
    }

}