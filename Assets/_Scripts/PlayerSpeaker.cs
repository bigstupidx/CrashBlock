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



	void Start ()
	{
		audioS = gameObject.GetComponent<AudioSource> ();

        audioS.volume = SaveSystem.GetSfxvolume();

        gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().volume = SaveSystem.GetTrackvolume();
    }




}
