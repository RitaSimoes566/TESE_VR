using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAtk : MonoBehaviour
{

    [SerializeField] private EnemyMov enemy;
    [SerializeField] private TimerAtk timer;

    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI[] headerScores = new TextMeshProUGUI[2];
    [SerializeField] private TextMeshProUGUI headerScore1;

    [SerializeField] private AudioManagerAtk audioAtk;
    [SerializeField] private BallManager ballMan;
    [SerializeField] private ParticleSystem victoryPart;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Sprite[] playImg = new Sprite[2];

    public bool isPaused;
    public bool isPlaying;
    private bool isPart;

    private void Awake()
    {
        isPart = false;
        isPaused = true;
        isPlaying = false;
        for (int i = 0; i < headerScores.Length; i++)
        {
            headerScores[i].SetText("Pontuação");
        }
        pauseBtn.interactable = false;
        playBtn.image.sprite = playImg[0];
        victoryPart.Stop();
    }

    private void Update()
    {
        DisplayScoreAtk();

        if (timer.targetTime <= 0.0f && !isPart)
        {
            VictoryAtk();
            isPart = true;
        }
    }

    private void VictoryAtk()
    {
        isPaused = true;
        isPlaying = false;

        for (int i = 0; i < headerScores.Length; i++)
        {
            headerScores[i].SetText("Parabéns");
        }

        victoryPart.Play();
        audioAtk.VictorySnd();
        ////audioAtk.StopBgMusic();

        ballMan.ClearBalls();
        enemy.StopAllCoroutines();

        pauseBtn.interactable = false;
    }

    public void StartAtk()
    {
        isPlaying = true;
        isPaused = false;

        timer.ResetTimer();
        enemy.ResetEnemy();
        //audioAtk.PlayBgMusic();
        ballMan.StartBalls();

        enemy.scoreAtk = 0;
        for (int i = 0; i < headerScores.Length; i++)
        {
            headerScores[i].SetText("Pontuação");
        }
        isPart = false;

        pauseBtn.interactable = true;
        playBtn.image.sprite = playImg[1];
    }

    public void PauseAtk()
    {
        if (isPlaying)
        {
            isPaused = !isPaused;
            enemy.PauseEnemy();
            //audioAtk.PauseBgMusic();
        }
    }

    public void ForcePause()
    {
        isPaused = true;
        enemy.PauseEnemy();
    }

    public void DisplayScoreAtk()
    {
        txtScore.SetText(enemy.scoreAtk.ToString());
    }
}
