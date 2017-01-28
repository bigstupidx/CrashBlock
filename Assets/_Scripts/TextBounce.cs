using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBounce : MonoBehaviour {

	[Header("Bounce animation"),SerializeField]
	private bool animateScale;
	private Vector3 initialScale;
	[SerializeField]
	public float maxScale;
	[SerializeField]
	public float minScale;
	[SerializeField]
	public float animTime;

	[Header("Animate the color")]
	[SerializeField]
	private bool animateColor;
	private Text image;
	[SerializeField]
	private Color32 startAnimColour;
	[SerializeField]
	private Color32 endAnimColour;
	[SerializeField]
	private float colorAnimTime;


	void Start()
	{
		if (gameObject.activeSelf) 
		{
			if (animateScale) 
			{
				initialScale = transform.localScale;
				StartCoroutine (BounceCo ());
			}

			if (animateColor) 
			{
				image = gameObject.GetComponent<Text> ();
				StartCoroutine (FlashyColourCo ());
			}


		}


	}


	IEnumerator BounceCo ()
	{
		float timer = 0;
		while (timer < animTime)
		{
			timer += Time.deltaTime;
			transform.localScale = Vector3.Lerp (minScale*initialScale, maxScale*initialScale, (timer / animTime));

				yield return null;

		}

		yield return new WaitForSeconds (0.1f);

		timer = 0;

		while (timer < animTime)
		{
			timer += Time.deltaTime;

			transform.localScale = Vector3.Lerp (maxScale*initialScale, minScale*initialScale, (timer / animTime));

			yield return null;



		}

		yield return new WaitForSeconds (0.1f);


		if (gameObject.activeSelf) 
		{
			StartCoroutine(BounceCo());
		}



	}


	IEnumerator FlashyColourCo ()
	{
		float timer = 0;
		while (timer < colorAnimTime)
		{
			timer += Time.deltaTime;
			image.color = Color32.Lerp (startAnimColour, endAnimColour, (timer / animTime));

			yield return null;

		}

		//yield return new WaitForSeconds (0.1f);

		timer = 0;

		while (timer < colorAnimTime)
		{
			timer += Time.deltaTime;

			image.color = Color32.Lerp (endAnimColour, startAnimColour, (timer / animTime));

			yield return null;



		}

		//yield return new WaitForSeconds (0.1f);


		if (gameObject.activeSelf) 
		{
			StartCoroutine(FlashyColourCo ());
		}



	}


}
