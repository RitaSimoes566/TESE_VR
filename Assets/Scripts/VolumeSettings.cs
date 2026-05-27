using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;

    private void Start()
    {
        SetMasterVolume();
        SetMusicVolume();
        SetSfxVolume();
    }

    public void SetMasterVolume()
    {
        float volumeMas = masterSlider.value;
        audioMixer.SetFloat("masterV", Mathf.Log10(volumeMas)*20);
    }
    public void SetMusicVolume()
    {
        float volumeMus = musicSlider.value;
        audioMixer.SetFloat("musicV", Mathf.Log10(volumeMus) * 20);
    }
    public void SetSfxVolume()
    {
        float volumeSfx = sfxSlider.value;
        audioMixer.SetFloat("sfxV", Mathf.Log10(volumeSfx) * 20);
    }
}
