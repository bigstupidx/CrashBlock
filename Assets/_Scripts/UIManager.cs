using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public void LoadTestScene()
    {
        SceneManager.LoadScene("tests");
    }
}
