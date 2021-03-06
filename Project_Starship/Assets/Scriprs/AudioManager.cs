using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> audioList;
    private AudioSource audio;
    private int index;
    private int random;

    private void Awake()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("Audio");
        if (audioObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audio = this.GetComponent<AudioSource>();
        index = -1;
        AudioGenerator();
    }

    private void Update()
    {
        if (!audio.isPlaying)
        {
            AudioGenerator();
        }
    }

    private void AudioGenerator()
    {
        do
        {
            random = Random.Range(0, audioList.Count);
        } while (random == index);
        index = random;
        audio.clip = audioList[index];
        audio.Play();
    }
}
