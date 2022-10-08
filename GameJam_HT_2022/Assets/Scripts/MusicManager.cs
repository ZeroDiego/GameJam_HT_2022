using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> songs;
    [SerializeField] private List<AudioClip> songsToPlay;
    private AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!aS.isPlaying)
        {
            int randomSong = Random.Range(0, songsToPlay.Count);
            AudioClip songClip = songsToPlay[randomSong];
            songsToPlay.Remove(songClip);
            aS.clip = songClip;
            aS.Play();
        }

        if (songsToPlay.Count == 0)
        {
            songsToPlay = new List<AudioClip>(songs);
        }
    }
}
