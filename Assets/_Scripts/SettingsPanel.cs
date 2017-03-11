using UnityEngine;
using System.Collections;

public class SettingsPanel : MonoBehaviour {

	public GameObject settingsPanel;

	public void ShowSettingsPanel()
	{
		if (settingsPanel.activeSelf == true)
			settingsPanel.SetActive (false);
		else
			settingsPanel.SetActive (true);
	}

	public void ShowPrivacyPolicy()
	{
		Application.OpenURL ("https://pixelroyalegames.wixsite.com/privacypolicy");
	}
}
