using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomly : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip clip;

    public int maxRnd;

    bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(0, maxRnd);

        if (rnd == 10 && !isOn)
        {
            audioS.Play();
        }

        if (audioS.isPlaying)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }

    }
}
