using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAtk : MonoBehaviour
{

    [SerializeField] private EnemyMov enemy;
    [SerializeField] private TimerAtk timer;

    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI[] headerScores = new TextMeshProUGUI[2];

    [SerializeField] private AudioManagerAtk audioAtk;
    [SerializeField] private BallManager ballMan;
    [SerializeField] private ParticleSystem victoryPart;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Sprite[] buttonImg = new Sprite[3];
    [SerializeField] private SceneChanger sceneChanger;

    [SerializeField] private GameObject[] hoverPanels = new GameObject[3];
    private TextMeshProUGUI[] uiHoverTxt = new TextMeshProUGUI[3];
    [SerializeField] private string[] uitxt = new string [5];

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
        playBtn.image.sprite = buttonImg[3];
        playBtn.image.sprite = buttonImg[0];
        victoryPart.Stop();

        for (int i = 0; i < hoverPanels.Length; i++)
        {
            uiHoverTxt[i] = hoverPanels[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        uiHoverTxt[0].SetText(uitxt[0]);
        uiHoverTxt[1].SetText(uitxt[2]);
        uiHoverTxt[2].SetText(uitxt[3]);
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
        audioAtk.StopBgMusic();

        for (int i = 0; i < headerScores.Length; i++)
        {
            headerScores[i].SetText("Parabéns");
        }

        victoryPart.Play();
        audioAtk.VictorySnd();

        ballMan.ClearBalls();
        
        enemy.StopAllCoroutines();
        enemy.monsterAnim.enabled = false;
        enemy.gameObject.SetActive(false);

        pauseBtn.image.sprite = buttonImg[1];
        playBtn.image.sprite = buttonImg[2];

        uiHoverTxt[0].SetText(uitxt[4]);
        uiHoverTxt[1].SetText(uitxt[1]);
    }

    public void StartAtk()
    {
        if (timer.targetTime > 0)
        {
            uiHoverTxt[0].SetText(uitxt[1]);
            uiHoverTxt[1].SetText(uitxt[2]);

            isPlaying = true;
            isPaused = false;

            timer.ResetTimer();

            enemy.gameObject.SetActive(true);
            enemy.ResetEnemy();
            audioAtk.PlayBgMusic();
            ballMan.StartBalls();

            enemy.scoreAtk = 0;
            for (int i = 0; i < headerScores.Length; i++)
            {
                headerScores[i].SetText("Pontuação");
            }
            isPart = false;

            pauseBtn.interactable = true;
            pauseBtn.image.sprite = buttonImg[3];
            playBtn.image.sprite = buttonImg[1];
        } else
        {
            sceneChanger.GoToDefense();
        }
    }

    public void PauseAtk()
    {
        if (isPlaying)
        {
            isPaused = !isPaused;
            enemy.PauseEnemy();
            audioAtk.PauseBgMusic();
        }

        if (timer.targetTime <= 0)
        {
            isPlaying = true;
            isPaused = false;

            timer.ResetTimer();
            enemy.ResetEnemy();
            audioAtk.PlayBgMusic();
            ballMan.StartBalls();

            enemy.scoreAtk = 0;
            for (int i = 0; i < headerScores.Length; i++)
            {
                headerScores[i].SetText("Pontuação");
            }
            isPart = false;

            pauseBtn.interactable = true;
            pauseBtn.image.sprite = buttonImg[3];
            playBtn.image.sprite = buttonImg[1];

            uiHoverTxt[0].SetText(uitxt[1]);
            uiHoverTxt[1].SetText(uitxt[2]);
        }
    }

    public void ForcePause()
    {
        isPaused = true;
        enemy.PauseEnemy();
        audioAtk.PauseBgMusic();
    }

    public void DisplayScoreAtk()
    {
        if (isPaused && isPlaying)
        {
            txtScore.SetText("Pausa");
        }
        else
        {
           
            if (enemy.scoreAtk < 9)
            {
                txtScore.SetText("000" + enemy.scoreAtk.ToString());
            }
            else if (enemy.scoreAtk < 99)
            {
                txtScore.SetText("00" + enemy.scoreAtk.ToString());
            }
            else if (enemy.scoreAtk < 999)
            {
                txtScore.SetText("0" + enemy.scoreAtk.ToString());
            }
            else
            {
                txtScore.SetText(enemy.scoreAtk.ToString());
            }
        }
        
    }
}
