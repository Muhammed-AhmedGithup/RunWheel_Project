using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_sound : MonoBehaviour
{
    public AudioClip audioClip_coin;
    private AudioSource audio_source;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audioClip_coin;
        audio_source.volume = 0.5f;
        audio_source.loop = false;

    }

    // Update is called once per frame
    
    public void PlaySource()
    {
        audio_source.Play();
    }
}
