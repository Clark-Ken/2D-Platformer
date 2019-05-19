using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public static AudioManager instance = null;

    public Slider musicVolumeSlider;

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

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pastVolume = musicVolumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (pastVolume > musicVolumeSlider.value || pastVolume < musicVolumeSlider.value)
        {
            volumeChanged = true;
            pastVolume = musicVolumeSlider.value;
        }

        if (volumeChanged)
        {
            SetMusicVolume();
            volumeChanged = false;
        }
    }

    public void PlaySingle(AudioClip clip)
    {

    }

    public void SetMusicVolume()
    {
        musicSource.volume = musicVolumeSlider.value;
    }
}
