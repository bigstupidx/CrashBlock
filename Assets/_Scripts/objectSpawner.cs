using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectSpawner : MonoBehaviour {

	[Space(10)]
	[Header("Spawn Object Variables")]
	public float spawnRateMin = 2f;
	public float spawnRateMax = 3f;

	[Space(10)]
	[Header("Spawn Object")]
	public GameObject[] spawnObjects;
	public bool spawning;

	[Space(10)]
	[Header("Lanes Transform")]
	public Transform leftLane;
	public Transform rightLane;

	//we fill the lists with the objects
	void Start () 
	{
       //start spawning objects
		StartCoroutine(spawnObstcle(Random.Range(1,3), Random.Range(spawnRateMin,spawnRateMax)));
	}

    //spawn powerups randomly 

    //spawn obstacles in the lanes
	IEnumerator spawnObstcle(int lane, float delay){
		yield return new WaitForSeconds (delay);
		int random = Random.Range (0, spawnObjects.Length - 1);

		if (lane == 1) 
		{
			GameObject leftLaneObject = spawnObjects [random];
			Instantiate (leftLaneObject, leftLane.transform.position, Quaternion.Euler (0.0f, Random.Range (0.0f, 360.0f), 0.0f)); 
		} 
		else 
		{
			GameObject rightLaneObject = spawnObjects [random];
			Instantiate (rightLaneObject, rightLane.transform.position, Quaternion.Euler (0.0f, Random.Range (0.0f, 360.0f), 0.0f)); 
		}
        //we start another coroutine spawning more objects
		StartCoroutine(spawnObstcle(Random.Range(1,3), Random.Range(spawnRateMin,spawnRateMax)));
	}
}
