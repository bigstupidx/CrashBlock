using UnityEngine;
using System.Collections;

public enum EnvironmentTypes{ Dia, Noche, Atardecer, Lluvia, Random }


public class EnvironmentManager : MonoBehaviour {



	[Header ("Skybox Settings")]

	public EnvironmentTypes environmentTypeVariable = EnvironmentTypes.Dia;
	public bool enableFog;
	[Range(0f,0.15f)]
	public float fogDensity;

	[Space(25f)]
	public Material diaSkybox;
	public Color32 diaAmbientColor;
	public Color32 diaFogColor;

	[Space(25f)]
	public Material nocheSkybox;
	public Color32 nocheAmbientColor;
	public Color32 nocheFogColor;

	[Space(25f)]
	public Material atardecerSkybox;
	public Color32 atardecerAmbientColor;
	public Color32 atardecerFogColor;

	[Space(25f)]
	public Material lluviaSkybox;
	public Color32 lluviaAmbientColor;
	public Color32 lluviaFogColor;
	public GameObject lluviaGameObject;


	// Use this for initialization
	void Start () {
	
		switch (environmentTypeVariable) {
		case EnvironmentTypes.Dia:
			RenderSettings.skybox = diaSkybox;
			RenderSettings.ambientLight = diaAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = diaFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;
		
		case EnvironmentTypes.Noche:
			RenderSettings.skybox = nocheSkybox;
			RenderSettings.ambientLight = nocheAmbientColor;
			if (enableFog) {
				RenderSettings.fog = true;
				RenderSettings.fogColor = nocheFogColor;
				RenderSettings.fogDensity = fogDensity;
			} else {
				RenderSettings.fog = false;
			}
			break;

		case EnvironmentTypes.Atardecer:
			RenderSettings.skybox = atardecerSkybox;
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
			RenderSettings.skybox = lluviaSkybox;
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
			RenderSettings.skybox = diaSkybox;
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
			RenderSettings.skybox = nocheSkybox;
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
			RenderSettings.skybox = atardecerSkybox;
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
			RenderSettings.skybox = lluviaSkybox;
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
