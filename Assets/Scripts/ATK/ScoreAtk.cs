using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAtk : MonoBehaviour
{

    [SerializeField] private EnemyMov enemy;
    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private AudioManagerAtk audioAtk;
    [SerializeField] private BallManager ballMan;

    public bool isPaused;
    public bool isPlaying;

    private void Awake()
    {
        isPaused = true;
        isPlaying = false;
    }

    private void Update()
    {
        DisplayScoreAtk();
    }

    public void StartAtk()
    {
        isPlaying = true;
        isPaused = false;

        timer.ResetTimer();
        enemy.ResetEnemy();
        audioAtk.PlayBgMusic();
        ballMan.StartBalls();

        enemy.scoreAtk = 0;

    }

    public void PauseAtk()
    {
        if (isPlaying)
        {
            isPaused = !isPaused;
            enemy.PauseEnemy();
            audioAtk.PauseBgMusic();
        }
    }

    public void DisplayScoreAtk()
    {
        txtScore.SetText(enemy.scoreAtk.ToString());
    }
}
