using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SettingsDef : MonoBehaviour
{
    [SerializeField] private Button timerBtn, playBtn, pauseBtn;
    [SerializeField] private Sprite[] timerIcons = new Sprite[2];
    [SerializeField] private Sprite[] playIcons = new Sprite[2];

    [SerializeField] private Camera cam;
    [SerializeField] private BeeSpawn beeMan;
    [SerializeField] private Timer timer;
    [SerializeField] private AudioManager audioMan;
    [SerializeField] private Color blackZero;

    [SerializeField] CanvasGroup timerDisplay;
    bool showTimer;
    public bool isStart;
    public bool isAR;

    private void Awake()
    {
        isAR = false;
        showTimer = true;
        playBtn.image.sprite = playIcons[0];
        pauseBtn.interactable = false;
        isStart = false;
    }

    public void ChangePlaySprite()
    {
        playBtn.image.sprite = playIcons[1];
        pauseBtn.interactable = true;
    }

    public void HideTimerDef()
    {
        showTimer = !showTimer;

        if (showTimer)
        {
            timerBtn.image.sprite = timerIcons[0];
            timerDisplay.alpha = 1;
        } else
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

    }

    public void PauseDef()
    {
        beeMan.PauseBees();
        timer.PauseTimer();
        audioMan.PauseBgMusic();
    }

    public void ForcePauseDef()
    {
        beeMan.isPaused = true;
        timer.timerPause = true;
        audioMan.playerSource.Pause();
    }

    public void changeVR()
    {

        isAR = !isAR;

        if (isAR)
        {
            RenderSkybox(cam);
        }
        else
        {
            RenderColor(blackZero, cam);
        }

    }

    //credit: https://stackoverflow.com/questions/72395530/change-background-type-from-solid-color-to-skybox-dynamically-c-sharp

    public void RenderSkybox(Camera targetCamera = null)
    {
        if (targetCamera == null)
        {
            //Get reference to main camera if no camera is passed
            targetCamera = Camera.main;
        }
        //set camera to render the skybox
        targetCamera.clearFlags = CameraClearFlags.Skybox;
    }

    public void RenderColor(Color color, Camera targetCamera = null)
    {
        if (targetCamera == null)
        {
            //Get reference to main camera if no camera is passed
            targetCamera = Camera.main;
        }

        targetCamera.clearFlags = CameraClearFlags.SolidColor;
        targetCamera.backgroundColor = color;
    }

}
