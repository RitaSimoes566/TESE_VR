using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class SettingsDef : MonoBehaviour
{
    [SerializeField] private GameObject tutCardDef;
    [SerializeField] private CanvasGroup scoreCanvas;

    [SerializeField] private Button timerBtn, playBtn, pauseBtn;
    [SerializeField] private Sprite[] timerIcons = new Sprite[2];
    [SerializeField] private Sprite[] playIcons = new Sprite[2];
    [SerializeField] private Sprite[] pauseIcons = new Sprite[3];

    [SerializeField] private TextMeshProUGUI[] startTxt = new TextMeshProUGUI [2];
    [SerializeField] private string[] txt = new string[4];


    //[SerializeField] private BeeSpawn beeMan;
    [SerializeField] private ButterflySpawn beeMan;
    [SerializeField] private Timer timer;
    [SerializeField] private AudioManager audioMan;
    [SerializeField] private SceneChanger sceneChange;


    [SerializeField] CanvasGroup timerDisplay;

    bool showTimer;
    public bool isStart;

    private void Awake()
    {
        showTimer = true;
        playBtn.image.sprite = playIcons[0];
        isStart = false;
        startTxt[0].SetText(txt[0]);
        startTxt[1].SetText(txt[4]);
        pauseBtn.image.sprite = pauseIcons[2];
    }

    public void ChangePlaySprite()
    {
        playBtn.image.sprite = playIcons[1];
        startTxt[0].SetText(txt[1]);
        startTxt[1].SetText(txt[2]);
;    }

    public void ChangePauseSprite()
    {
        pauseBtn.image.sprite = pauseIcons[1];
        startTxt[1].SetText(txt[3]);
    }

    public void ResetPauseBtn()
    {
        startTxt[1].SetText(txt[2]);
    }

    public void HideTimerDef()
    {
        showTimer = !showTimer;

        if (showTimer)
        {
            timerBtn.image.sprite = timerIcons[0];
            timerDisplay.alpha = 1;
        }
        else
        {
            timerBtn.image.sprite = timerIcons[1];
            timerDisplay.alpha = 0;
        }
    }

    public void PlayDef()
    {
        isStart = true;
        ChangePlaySprite();
        beeMan.RestartBees();
        timer.ResetTimer();
        audioMan.PlayBgMusic();
        pauseBtn.image.sprite = pauseIcons[0];
    }

    public void PauseDef()
    {

        if (timer.targetTime > 0)
        {
            if (isStart)
            {
                beeMan.PauseBees();
                timer.PauseTimer();
                audioMan.PauseBgMusic();
            } else
            {
                tutCardDef.SetActive(true);
            }
        } else
        {
            sceneChange.GoToAttack();
        }
    }

    public void ForcePauseDef()
    {
        beeMan.isPaused = true;
        timer.timerPause = true;
        audioMan.playerSource.Pause();
    }

    public void ShowTutorialDef()
    {
        tutCardDef.SetActive(true);

        scoreCanvas.interactable = false;
        scoreCanvas.blocksRaycasts = false;
    }

    public void RestoreScoreCard()
    {
        scoreCanvas.interactable = true;
        scoreCanvas.blocksRaycasts = true;
    }
}

    
