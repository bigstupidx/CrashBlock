using UnityEngine;
using System.Collections;

public class ParticleAutoTurnOff : MonoBehaviour {

	// this script plays audio clips and disables the sound effect after the timer goes off

	[Header("Drag your sound effects, more than 1 is played random"),SerializeField]
	private AudioClip[] sfxToPlay;
	private AudioSource audioS;
	private DataComps dataComps;

    [Header("Tiem to deactivate"),SerializeField]
	private float autopTurnOffTimer;

	private float timer = 0;

	private int random;

	void Awake()
	{
		audioS = gameObject.GetComponent<AudioSource>();
		dataComps = GameObject.FindGameObjectWithTag ("Database").GetComponent<DataComps> ();
	}


	void OnEnable()
	{
		if (sfxToPlay.Length == 1) 
		{
			if (sfxToPlay[0]) 
			{
				audioS.PlayOneShot (sfxToPlay [0], dataComps.sfxVolume);
			}
		}

		if (sfxToPlay.Length > 1) 
		{
			random = Random.Range (0, sfxToPlay.Length);

				if (sfxToPlay[random]) 
				{
					audioS.PlayOneShot (sfxToPlay [random], dataComps.sfxVolume);
				}

		}
		


		StartCoroutine (AutoturnOffCo());
		
	}

	IEnumerator AutoturnOffCo()
	{
		timer = autopTurnOffTimer;

		while(timer >0)
		{
			timer -= Time.deltaTime;


			yield return null;
		}

	
		if( this.gameObject.activeSelf)
		{
			timer =0;
			gameObject.SetActive(false);
		}

	}

  


}
