using UnityEngine;
using System.Collections;
using Heyzap;

public class AdManager : MonoBehaviour {

	public FPSPlayer fpsPlayerRef;
	public PauseManager pause;
	// Use this for initialization
	void Start () {
		HeyzapAds.Start("f62dff4e4bbf49a67e29252338b6d0d7", HeyzapAds.FLAG_NO_OPTIONS);
		HZIncentivizedAd.Fetch();
		fpsPlayerRef.GetComponent<FPSPlayer>();
	}

	public void Interstitial()
	{
		HZInterstitialAd.Show();
	}

	public void Rewarded()
	{
#if UNITY_EDITOR
		fpsPlayerRef.hitPoints += fpsPlayerRef.maximumHitPoints;
		pause.DeactivateDeathCanvas ();
#endif

#if UNITY_ANDROID

		if (HZIncentivizedAd.IsAvailable()) {
			HZIncentivizedAd.Show();
			fpsPlayerRef.hitPoints += fpsPlayerRef.maximumHitPoints;
			pause.DeactivateDeathCanvas ();
		}

		HZIncentivizedAd.Fetch();
#endif
	}

}
