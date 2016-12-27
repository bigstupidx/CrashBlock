using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class floorSpawner : MonoBehaviour {

    
    
	[Space(10)]
	[Header("Pooling Variables")]
	public int pooledFloorAmount = 20;
	public GameObject floorSegment;
	public Transform floorGroup;
	List<GameObject> floorPool;

    //fill the pool with the floor objects
	void Start(){

		floorPool = new List<GameObject> ();
		//we fill the list with the defined amount of obstacles
//		for (int i = 0; i < pooledFloorAmount; i++)
//		{
//			GameObject obj = (GameObject)Instantiate(floorSegment);
//			obj.SetActive(false);
//			obj.transform.parent = floorGroup.transform;
//			floorPool.Add (obj);
//		}

		for (int i = 0; i < floorGroup.transform.childCount; i++) 
		{
			floorPool.Add (floorGroup.transform.GetChild (i).gameObject);
		}
	}

    //after exiting the triger we activate a floor from the pool
	void OnTriggerExit(Collider other) {
		spawnFloor(other);
	}

    //we look through the list of objects until we find one inactive and then we activate it and move it to the right position and we add them as a child of a group 
    //to avoid too much objects in the inspector
	public void spawnFloor(Collider otherM){
		for (int i = 0; i < floorPool.Count; i++) {
			if (!floorPool [i].activeInHierarchy) {
				floorPool [i].transform.position = otherM.gameObject.GetComponent<Transform> ().position;	//we move the object to the position of the lane
				floorPool [i].SetActive (true); 																					//we activate the object
				break;
			}
		}
	
	}
}
