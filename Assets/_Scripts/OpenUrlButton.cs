using UnityEngine;
using System.Collections;

public class OpenUrlButton : MonoBehaviour
{

    public string urlToOpen = string.Empty;

	public void OnOpenUrlPressed()
    {
        if(!string.IsNullOrEmpty(urlToOpen))
        {
            Application.OpenURL(urlToOpen);
        }
    }
}
