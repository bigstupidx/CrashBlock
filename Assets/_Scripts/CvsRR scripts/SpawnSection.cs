using UnityEngine;
using System.Collections;

public class SpawnSection : MonoBehaviour {

	// npc's to spawn
	public GameObject[] npc;




	public void SpawnNpcs()
	{
		StartCoroutine (SpawnNpcsCo ());
	}

	IEnumerator SpawnNpcsCo()
	{

		for (int i = 0; i < npc.Length; i++) 
		{
			yield return new WaitForSeconds (0.02f);

			npc [i].SetActive (true);

		}
		
	}





}
