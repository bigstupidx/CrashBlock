using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum CameraFade {FadeIn, FadeOut};

public class CameraFader : MonoBehaviour {

	[Header("Animate the color")]
	[SerializeField]
	private Image image;
	[SerializeField]
	private Color32 startAnimColour;
	[SerializeField]
	private Color32 endAnimColour;
	[SerializeField]
	private float fadeTime;


	void Start()
	{
		if (gameObject.activeSelf) 
		{

				image = gameObject.GetComponent<Image> ();
				StartCoroutine (FaderCo(CameraFade.FadeIn));

		}


	}




	IEnumerator FaderCo(CameraFade action)
	{
		float timer = 0;

		if (action == CameraFade.FadeIn) {


			while (timer < fadeTime) {
				timer += Time.deltaTime;
				image.color = Color32.Lerp (startAnimColour, endAnimColour, (timer / fadeTime));

				yield return null;

			}
			image.raycastTarget = false;
		}  

		//yield return new WaitForSeconds (0.1f);

		if (action == CameraFade.FadeOut) {

			timer = 0;

			while (timer < fadeTime) {
				timer += Time.deltaTime;

				image.color = Color32.Lerp (endAnimColour, startAnimColour, (timer / fadeTime));

				yield return null;



			}

		}
	}

}
