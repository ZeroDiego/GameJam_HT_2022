using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> songs = new List<AudioClip>();
    [SerializeField] private List<AudioClip> songsToPlay = new List<AudioClip>();
    private AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (songsToPlay.Count == 0)
        {
            songsToPlay = new List<AudioClip>(songs);
        }

        if (!aS.isPlaying)
        {
            int randomSong = Random.Range(0, songsToPlay.Count);
            AudioClip songClip = songsToPlay[randomSong];
            songsToPlay.Remove(songClip);
            aS.clip = songClip;
            aS.Play();
        }
    }
}
