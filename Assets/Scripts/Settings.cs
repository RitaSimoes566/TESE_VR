using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject settings;

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
}
