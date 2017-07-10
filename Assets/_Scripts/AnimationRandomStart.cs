using UnityEngine;
using System.Collections;

public class AnimationRandomStart : MonoBehaviour {

	public Animator anim;
	public string animationName;

	void Start()
	{
		if (anim != null) {
			anim.Play (animationName, 0, Random.Range (0, anim.GetCurrentAnimatorStateInfo (0).length));
		}
	}
}
