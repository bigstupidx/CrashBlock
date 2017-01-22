using UnityEngine;
using System.Collections;

public class PlayerSpeaker : MonoBehaviour {

	// just set the number of audio to play


	public AudioSource audioS;
	public AudioClip[] sfxLibrary;
	[Range(0,1)]
	public float volume = 0.7f;

	public int sfxToPlay;	// last sfx played

	public int SfxToPlay
	{

		get{ return sfxToPlay; }
		set
		{
			sfxToPlay = value;

			audioS.PlayOneShot (sfxLibrary[sfxToPlay], volume);
		
		
		}

	}



	void Awake ()
	{
		audioS = gameObject.GetComponent<AudioSource> ();
	}




}
