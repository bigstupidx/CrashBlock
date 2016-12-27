using UnityEngine;
using System.Collections;

public class floorDestroyer : MonoBehaviour {

    
    //disable floors and objects that go behind player
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "ground")
			other.transform.parent.gameObject.SetActive (false);
	}
}
