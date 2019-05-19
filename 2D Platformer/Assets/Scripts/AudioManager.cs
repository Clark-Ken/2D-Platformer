using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public static AudioManager instance = null;

    //public Slider musicVolumeSlider;

    public GameSettings gameSettings;

    private bool volumeChanged = false;

    private float pastVolume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //SetMusicVolume();

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {

    }

    public void SetMusicVolume()
    {
        musicSource.volume = gameSettings.gameMusicVolume;
    }
}
