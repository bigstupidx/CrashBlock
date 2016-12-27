using UnityEngine;
using System.Collections;

public class MenuFloor : MonoBehaviour {

	[SerializeField]
	private int floorSpeed;

	[Header ("Building Objects")]
	[SerializeField]
	private GameObject[] buildingObjects;
	[SerializeField]
	private GameObject buildingSpawnerLeft;
	[SerializeField]
	private GameObject buildingSpawnerRight;

	void Awake()
	{
		int random = Random.Range (0, buildingObjects.Length);
		Debug.Log ("range: 0 - " + buildingObjects.Length);
		Debug.Log ("left random: " + random);
		GameObject leftObject = buildingObjects [random];
		GameObject leftBuilding = Instantiate (leftObject, buildingSpawnerLeft.transform.position, buildingSpawnerLeft.transform.rotation) as GameObject; 
		leftBuilding.transform.parent = gameObject.transform;

		random = Random.Range (0, buildingObjects.Length);
		GameObject rightObject = buildingObjects [random];
		GameObject rightBuilding = Instantiate (rightObject, buildingSpawnerRight.transform.position, buildingSpawnerRight.transform.rotation) as GameObject; 
		rightBuilding.transform.parent = gameObject.transform;
	}
		

	void Update () 
	{

		transform.Translate (Vector3.forward * Time.deltaTime * floorSpeed, Space.World);

	}
}
