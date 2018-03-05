using UnityEngine;
using System.Collections;

public class TeamSkin : MonoBehaviour {

    [Header("Call the team as 1,2,3")]
    public int team;

    public Texture currentSkin;

    public Texture[] texture;

    private DataComps dataComps;
    [SerializeField]
    private SkinnedMeshRenderer playerFeet;
    [SerializeField]
    private Texture[] feetTexture;

    // when player selects a team, the current skin must be updated



    public void SetTeamSkin(int teamNum)
    {
        team = teamNum;

        currentSkin = texture[team - 1];

        dataComps = ServiceLocator.dataComps;

        dataComps.playerWeps_ref.CurrentWeaponBehaviorComponent.gameObject.SetActive(false);

        StartCoroutine(ReActivateCo());

        playerFeet.material.SetTexture("_MainTex", feetTexture[team - 1]);

    }

    IEnumerator ReActivateCo()
    {
        yield return new WaitForSeconds(0.5f);
        dataComps.playerWeps_ref.CurrentWeaponBehaviorComponent.gameObject.SetActive(true);
    }
	
}
