using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour {
    public AudioClip LevelMusic;


	// Use this for initialization
	void Start () {
        GameObject MPObject = GameObject.Find("Music Player");
        AudioSource musicPlayer = MPObject.GetComponent<AudioSource>();
        musicPlayer.Stop();
        musicPlayer.clip = LevelMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
	}
	
}
