using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;
using TMPro;
public class TutorialUI : MonoBehaviour
{
    [SerializeField] GameObject tutCard;
    [SerializeField] Button[] uiBtn = new Button[2];
    //[SerializeField] List<Image> imgTutorial = new List<Image>();

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] List<VideoClip> tutClips = new List<VideoClip>();
    [SerializeField] List<TextMeshProUGUI> txtTutorial = new List<TextMeshProUGUI>();

    private int currentIndex = 0;
    private int maxIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
        maxIndex = txtTutorial.Count - 1;
        Debug.Log(maxIndex);
        Debug.Log(currentIndex);
        DisplayTut(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex == 0)
        {
            uiBtn[0].interactable = false;
        } else
        {
            uiBtn[0].interactable = true;
        }

        if (currentIndex == maxIndex)
        {
            uiBtn[1].interactable = false;
        } else
        {
            uiBtn[1].interactable = true;
        }
    }

    public void PressForward()
    {
        if (currentIndex <= maxIndex)
        {
            currentIndex += 1;
        }

        DisplayTut(currentIndex);
        Debug.Log(currentIndex);
    }

    public void PressBack()
    {
        if (currentIndex >= 0)
        {
            currentIndex -= 1;
        }
        DisplayTut(currentIndex);
        Debug.Log(currentIndex);
    }

    void DisplayTut(int index)
    {
        for (int i = 0; i <= maxIndex; i++)
        {
            if (index == i)
            {
                txtTutorial[i].enabled = true;
            } else
            {
                txtTutorial[i].enabled = false;
            }
        }
        videoPlayer.clip = tutClips[index];

    }

    public void QuitTutorial()
    {
        tutCard.SetActive(false);
    }
}
