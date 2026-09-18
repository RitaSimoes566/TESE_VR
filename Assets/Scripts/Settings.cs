/*using UnityEngine;
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
    public bool isAR;

    private void Awake()
    {
        isAR = true;
        ARcam = cam.GetComponent<ARCameraManager>();
        vrBtn.image.sprite = vrImg[0];
        EnableAR();
    }

    private void Start()
    {
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

    public void EnableAR()
    {
        Color transparent = Color.black;
        transparent.a = 0f;

        ARcam.enabled = true;
        RenderColor(transparent, cam);
        vrBtn.image.sprite = vrImg[0];
    }

    public void DisableAR()
    {
        ARcam.enabled = false;
        RenderSkybox(cam);
        vrBtn.image.sprite = vrImg[1];
    }

    public void SwitchVR()
    {

        if (ARcam.enabled )
        {
            DisableAR();

        } else
        {
            EnableAR();

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

}*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject settings;

    [SerializeField] private Button vrBtn;
    [SerializeField] private Sprite[] vrImg = new Sprite[2];
    [SerializeField] private Camera cam;

    private ARCameraManager arCameraManager;
    private bool isAR;

    private void Awake()
    {
        if (cam == null)
            cam = Camera.main;

        if (cam == null)
        {
            Debug.LogError("Settings: No camera assigned.");
            return;
        }

        arCameraManager = cam.GetComponent<ARCameraManager>();

        if (arCameraManager == null)
        {
            Debug.LogError("Settings: ARCameraManager is missing from the assigned camera.");
            return;
        }

        if (vrBtn == null)
        {
            Debug.LogError("Settings: vrBtn is not assigned.");
            return;
        }

        EnableAR();
    }

    private void Start()
    {
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

    public void EnableAR()
    {
        isAR = true;
        arCameraManager.enabled = true;

        Color transparent = new Color(0f, 0f, 0f, 0f);

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = transparent;

        vrBtn.image.sprite = vrImg[0];

        Debug.Log("Passthrough enabled.");
    }

    public void DisableAR()
    {
        isAR = false;
        arCameraManager.enabled = false;

        cam.clearFlags = CameraClearFlags.Skybox;

        vrBtn.image.sprite = vrImg[1];

        Debug.Log("Passthrough disabled.");
    }

    public void SwitchVR()
    {
        if (arCameraManager.enabled)
            DisableAR();
        else
            EnableAR();
    }
}


