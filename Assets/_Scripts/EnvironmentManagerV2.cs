using UnityEngine;
using System.Collections;


public class EnvironmentManagerV2 : MonoBehaviour {



	[Header ("Skybox Settings")]

	public EnvironmentTypes environmentTypeVariable = EnvironmentTypes.Dia;
	public bool enableFog;
	[Range(0f,0.15f)]
	public float fogDensity;
    public Material skyDome;
    public GameObject moon;
    public GameObject sun;

	[Space(25f)]
	public Vector2 diaSkybox;
	public Color32 diaAmbientColor;
	public Color32 diaFogColor;

	[Space(25f)]
	public Vector2 nocheSkybox;
	public Color32 nocheAmbientColor;
	public Color32 nocheFogColor;

	[Space(25f)]
	public Vector2 atardecerSkybox;
	public Color32 atardecerAmbientColor;
	public Color32 atardecerFogColor;

	[Space(25f)]
	public Vector2 lluviaSkybox;
	public Color32 lluviaAmbientColor;
	public Color32 lluviaFogColor;
	public GameObject lluviaGameObject;


	// Use this for initialization
	void Start () {
	
		switch (environmentTypeVariable) {
		case EnvironmentTypes.Dia:
			skyDome.mainTextureOffset = diaSkybox;
			RenderSettings.ambientLight = diaAmbientColor;
                sun.SetActive(true);
                moon.SetActive(false);
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = diaFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;
		
		case EnvironmentTypes.Noche:
            skyDome.mainTextureOffset = nocheSkybox;
			RenderSettings.ambientLight = nocheAmbientColor;
                sun.SetActive(false);
                moon.SetActive(true);
                if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = nocheFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;

		case EnvironmentTypes.Atardecer:
                sun.SetActive(true);
                moon.SetActive(false);
                skyDome.mainTextureOffset = atardecerSkybox;
			RenderSettings.ambientLight = atardecerAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = atardecerFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;

		case EnvironmentTypes.Lluvia:
                sun.SetActive(false);
                moon.SetActive(true);
                skyDome.mainTextureOffset = lluviaSkybox;
			RenderSettings.ambientLight = lluviaAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = lluviaFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			if(lluviaGameObject != null)
				lluviaGameObject.SetActive (true);
			break;

		case EnvironmentTypes.Random:
			float randomNumber = Random.Range (0.0f, 3.0f);
			randomEnvironment (Mathf.RoundToInt( randomNumber));
			break;
		}

	}

	void randomEnvironment(int _index){
		switch (_index) {
		case 0:
            skyDome.mainTextureOffset = diaSkybox;
                sun.SetActive(true);
                moon.SetActive(false);
                RenderSettings.ambientLight = diaAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = diaFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;

		case 1:
                skyDome.mainTextureOffset = nocheSkybox;
                sun.SetActive(false);
                moon.SetActive(true);
                RenderSettings.ambientLight = nocheAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = nocheFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;

		case 2:
                skyDome.mainTextureOffset = atardecerSkybox;
                sun.SetActive(true);
                moon.SetActive(false);
                RenderSettings.ambientLight = atardecerAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = atardecerFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;

		case 3:
                skyDome.mainTextureOffset = lluviaSkybox;
                sun.SetActive(false);
                moon.SetActive(true);
                RenderSettings.ambientLight = lluviaAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = lluviaFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			if(lluviaGameObject != null)
				lluviaGameObject.SetActive (true);
			break;
	}

}
}
