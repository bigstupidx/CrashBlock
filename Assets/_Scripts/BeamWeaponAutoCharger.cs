using UnityEngine;
using System.Collections;

public class BeamWeaponAutoCharger : MonoBehaviour {


    private bool startedOnce;
    private WaitForSeconds rechargeWait;
    private WeaponBehavior wepBeh_ref;

    [SerializeField]
    private float rechargeRate;

    [SerializeField]
    private int ammoToRecharge;


	
	void OnEnable()
    {
        if (!startedOnce)
        {
            InitializeScript();
            startedOnce = true;
        }
        StartCoroutine(WaitForCharge());
    }


    void InitializeScript()
    {
        rechargeWait = new WaitForSeconds(rechargeRate);
        wepBeh_ref = GetComponent<WeaponBehavior>();
    }




    IEnumerator WaitForCharge()
    {
        if((wepBeh_ref.ammo + ammoToRecharge)< wepBeh_ref.maxAmmo)
        {
            wepBeh_ref.ammo += ammoToRecharge;
        }

        yield return rechargeWait;
        if (gameObject.activeSelf)
        {
            StartCoroutine(WaitForCharge());
        }

    }

}
