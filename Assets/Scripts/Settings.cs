using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject settings;

    [SerializeField] private Button vrBtn;
    [SerializeField] private Sprite[] vrImg = new Sprite[2];
    [SerializeField] private Color blackZero;
    [SerializeField] private Camera cam;
    public ARCameraManager ARcam;

    private void Awake()
    {
        ARcam = cam.GetComponent<ARCameraManager>();
        vrBtn.image.sprite = vrImg[0];
        
    }

    private void Start()
    {
        ARcam.enabled = true;
        ShowScore();
    }
    public void ShowScore()
    {
        score.SetActive(true);
        settings.SetActive(false);
    }

    public void ShowSettings()
    {
        score.SetActive(false);
        settings.SetActive(true);
    }

    public void SwitchVR()
    {
        if (ARcam.enabled)
        {
            ARcam.enabled = false;
            RenderSkybox(cam);
        }
        else
        {
            ARcam.enabled = true;
            Color b = new (0, 0, 0, 0);
            RenderColor(b ,cam);
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


