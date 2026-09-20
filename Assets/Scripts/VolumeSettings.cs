using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    [SerializeField] private float musValue = -15f;
    [SerializeField] private float sfxValue = -0f;

    private void Start()
    {
        musValue = -15f;
        sfxValue = 0f;

        //SetMasterVolume();
        SetMusicVolume();
        SetSfxVolume();
    }

    /*public void SetMasterVolume()
    {
        float volumeMas = masterSlider.value;
        audioMixer.SetFloat("masterV", Mathf.Log10(volumeMas) * 20);
    }*/
    public void SetMusicVolume()
    {
        float volumeMus = musicSlider.value;
        audioMixer.SetFloat("musicV", (Mathf.Log10(volumeMus) * 20) + musValue);
    }
    public void SetSfxVolume()
    {
        float volumeSfx = sfxSlider.value;
        audioMixer.SetFloat("sfxV", (Mathf.Log10(volumeSfx) * 20) + sfxValue);
    }
}
