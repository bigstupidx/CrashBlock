using UnityEngine;
using System.Collections;

public class PlayerJumpPad: MonoBehaviour
{
	[Header("Assign the PlayerPrefs GameObject here")]

	public GameObject core;
	[SerializeField]
	float lobHeight = 6;
	[SerializeField]
	float lobTime = 0.9f;

    private FPSRigidBodyWalker fpsRigid;

	[SerializeField]
	float stepHeight = 3;
	[SerializeField]
	float stepTime = 0.15f;

	public Vector3 targetPosition;

	public Vector3 TargetPosition
	{
		get{return targetPosition; }
		set
		{
			targetPosition = value;

			JumpPadActivation ();
            StartCoroutine(JumpPadDamagePermit());

		}
	}

	public Vector3 targetStep;

	public Vector3 TargetStep
	{
		get{return targetStep; }
		set
		{
			targetStep = value;

			StepActivation ();

        }
	}


    void Start()
    {
        if(GetComponent<FPSRigidBodyWalker>())
        {
            fpsRigid = GetComponent<FPSRigidBodyWalker>();
        }
    }




	public void StepActivation()
	{
		iTween.MoveBy(core, iTween.Hash("y", stepHeight, "time", stepTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(core, iTween.Hash("y", -stepHeight, "time", stepTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(gameObject, iTween.Hash("position", targetStep, "time", stepTime, "easeType", iTween.EaseType.linear));
		iTween.FadeTo(gameObject, iTween.Hash("delay", 3, "time", .5, "alpha", 0, "onComplete", "CleanUp"));
	}





	public void JumpPadActivation()
	{
		iTween.MoveBy(core, iTween.Hash("y", lobHeight, "time", lobTime/2, "easeType", iTween.EaseType.easeOutQuad));
		iTween.MoveBy(core, iTween.Hash("y", -lobHeight, "time", lobTime/2, "delay", lobTime/2, "easeType", iTween.EaseType.easeInCubic));     
		iTween.MoveTo(gameObject, iTween.Hash("position", targetPosition, "time", lobTime, "easeType", iTween.EaseType.linear));
		iTween.FadeTo(gameObject, iTween.Hash("delay", 3, "time", .5, "alpha", 0, "onComplete", "CleanUp"));
	}



    IEnumerator JumpPadDamagePermit()
    {
        if (fpsRigid)
        {
            fpsRigid.usingJumpPad = true;
            yield return new WaitForSeconds(lobTime + 0.5f);
            fpsRigid.usingJumpPad = false;
        }
        
    }



}

