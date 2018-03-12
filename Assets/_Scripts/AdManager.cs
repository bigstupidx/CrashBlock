using UnityEngine;
using System.Collections;
using Heyzap;
using UnityEngine.Analytics;


public class AdManager : MonoBehaviour {

	public FPSPlayer fpsPlayerRef;
	public PauseManager pause;
	public PlayerWeapons weapons;
	public SaveData saveData;
    public bool resetPositionInDeath = false;
    Transform fpsPlayerTransform;
    Vector3 originalPosition;
    Quaternion originalRotation;

    private void Awake()
    {
        ServiceLocator.adManager = this;
    }

    // Use this for initialization
    void Start ()
    {
		HeyzapAds.Start("f62dff4e4bbf49a67e29252338b6d0d7", HeyzapAds.FLAG_NO_OPTIONS);
		HZIncentivizedAd.Fetch();
        //fpsPlayerRef.GetComponent<FPSPlayer>(); ---> optimized
        fpsPlayerRef = ServiceLocator.fpsPlayer;
        fpsPlayerTransform = fpsPlayerRef.GetComponent<Transform>();
        originalPosition = fpsPlayerTransform.position;
        originalRotation = fpsPlayerTransform.rotation;
        // weapons.GetComponent<PlayerWeapons> (); ---> optimized
        weapons = ServiceLocator.playerWeapons;

	}

	public void Interstitial()
	{
		HZInterstitialAd.Show();
	}

	public void Rewarded()
	{
		#if UNITY_EDITOR
			fpsPlayerRef.hitPoints = fpsPlayerRef.maximumHitPoints;
			fpsPlayerRef.UpdateHPBar();
			fpsPlayerRef.invulnerable = true;
        if (resetPositionInDeath)
        {
            fpsPlayerTransform.position = originalPosition;
            fpsPlayerTransform.rotation = originalRotation;
            resetPositionInDeath = false;
        }
        pause.DeactivateDeathCanvas ();
			fpsPlayerRef.RemoveInvulnerability();
            fpsPlayerRef.ActivateADShield(5.0f);
        #endif


#if UNITY_ANDROID

        if (HZIncentivizedAd.IsAvailable ()) {
				HZIncentivizedAd.Show ();
				fpsPlayerRef.invulnerable = true;
				fpsPlayerRef.hitPoints = fpsPlayerRef.maximumHitPoints;
				fpsPlayerRef.UpdateHPBar ();
				Analytics.CustomEvent ("DeathVideo");
            if (resetPositionInDeath)
            {
                fpsPlayerTransform.position = originalPosition;
                fpsPlayerTransform.rotation = originalRotation;
                resetPositionInDeath = false;
            }
				pause.DeactivateDeathCanvas ();
				fpsPlayerRef.RemoveInvulnerability();
                fpsPlayerRef.ActivateADShield(5.0f);
                HZIncentivizedAd.Fetch ();

			}
#endif
	}

	public void RewardedAmmo()

	{
#if UNITY_EDITOR
		weapons.giveAmmo(weapons.weaponToAddAmmo);
		pause.DeactivateAmmoCanvas ();
        fpsPlayerRef.ActivateADShield(3.0f);
#endif

#if UNITY_ANDROID
        if (HZIncentivizedAd.IsAvailable()) {
			HZIncentivizedAd.Show();
			weapons.giveAmmo(weapons.weaponToAddAmmo);
			Analytics.CustomEvent("AmmoVideo");
			pause.DeactivateAmmoCanvas ();
            fpsPlayerRef.ActivateADShield(3.0f);
            HZIncentivizedAd.Fetch();
		}

#endif
	}

	public void RewardedWepSlot(int slot)
	{
#if UNITY_EDITOR
	
		saveData.AwardSlot(slot);


#endif

#if UNITY_ANDROID
		if (HZIncentivizedAd.IsAvailable()) {
			HZIncentivizedAd.Show();
			Analytics.CustomEvent("SlotVideo");
			saveData.AwardSlot(slot);
		}

		HZIncentivizedAd.Fetch();
#endif
	}






}
