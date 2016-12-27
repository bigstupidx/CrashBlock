using UnityEngine;
using System.Collections;

public class MenuZombieWalk : MonoBehaviour {

	[SerializeField]
	private int walkMovementSpeed;

	void Update () {

		transform.Translate (Vector3.forward * Time.deltaTime * walkMovementSpeed, Space.Self);

	}
}
