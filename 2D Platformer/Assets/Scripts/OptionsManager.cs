using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Slider gameMusicVolumeSlider;
    public Slider mainMenuMusicVolumeSlider;

    public Resolution[] resolutions;

    public AudioSource gameMusicSource;
    public AudioSource mainMenuMusicSource;

    public GameSettings gameSettings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        gameMusicVolumeSlider.onValueChanged.AddListener(delegate { OnGameMusicVolumeChange(); });
        mainMenuMusicVolumeSlider.onValueChanged.AddListener(delegate { OnMainMenuMusicVolumeChange(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnGameMusicVolumeChange()
    {
        gameMusicSource.volume = gameSettings.gameMusicVolume = gameMusicVolumeSlider.value;
    }

    public void OnMainMenuMusicVolumeChange()
    {
        mainMenuMusicSource.volume = gameSettings.mainMenuMusicVolume = mainMenuMusicVolumeSlider.value;
    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }
}
