using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource audion_source;

	public float end_counter = 0;

	public void Awake(){
		DontDestroyOnLoad (this.gameObject);
		audion_source.playOnAwake = true;
		print ("music duration: " + audion_source.clip.length);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		end_counter += 1 * Time.deltaTime;
		if (end_counter >= audion_source.clip.length)
			Application.Quit();
	}
}
