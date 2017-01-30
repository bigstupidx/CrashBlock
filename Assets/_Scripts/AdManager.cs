using UnityEngine;
using System.Collections;
using Heyzap;
using UnityEngine.Analytics;


public class AdManager : MonoBehaviour {

	public FPSPlayer fpsPlayerRef;
	public PauseManager pause;
	public PlayerWeapons weapons;
	public SaveData saveData;

	// Use this for initialization
	void Start () {
		HeyzapAds.Start("f62dff4e4bbf49a67e29252338b6d0d7", HeyzapAds.FLAG_NO_OPTIONS);
		HZIncentivizedAd.Fetch();
		fpsPlayerRef.GetComponent<FPSPlayer>();
		weapons.GetComponent<PlayerWeapons> ();

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
			pause.DeactivateDeathCanvas ();
			fpsPlayerRef.RemoveInvulnerability();
		#endif
			

		#if UNITY_ANDROID

			if (HZIncentivizedAd.IsAvailable ()) {
				HZIncentivizedAd.Show ();
				fpsPlayerRef.invulnerable = true;
				fpsPlayerRef.hitPoints = fpsPlayerRef.maximumHitPoints;
				fpsPlayerRef.UpdateHPBar ();
				Analytics.CustomEvent ("DeathVideo");
				pause.DeactivateDeathCanvas ();
				fpsPlayerRef.RemoveInvulnerability();

				HZIncentivizedAd.Fetch ();
				#endif
			}
	}

	public void RewardedAmmo()
	{
		#if UNITY_EDITOR
		weapons.giveAmmo(weapons.weaponToAddAmmo);
		pause.DeactivateAmmoCanvas ();
		#endif

		#if UNITY_ANDROID
		if (HZIncentivizedAd.IsAvailable()) {
			HZIncentivizedAd.Show();
			weapons.giveAmmo(weapons.weaponToAddAmmo);
			Analytics.CustomEvent("AmmoVideo");
			pause.DeactivateAmmoCanvas ();
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
