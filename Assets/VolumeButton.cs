using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour {


    [SerializeField]
    // objects to show and hide on click
    private GameObject[] objectsToToggle;
    [SerializeField]
    private Slider musicVolSlider;
    [SerializeField]
    private Slider sfxVolSlider;

    [SerializeField]
    private bool show = false;
    public bool Show
    {
        get { return show; }

        set {
            show = value;
            for (int i = 0; i < objectsToToggle.Length; i++)
            {
                objectsToToggle[i].SetActive(show);

            }
            // if true, set the sliders initial values form datacomps
            if (show)
            {
                musicVolSlider.value = dataComps.trackVolume;
            }
        }
    }



    // the usual data comps
    private DataComps dataComps;


    void Awake()
    {
        if (!dataComps)
            dataComps = GameObject.FindGameObjectWithTag("DataBase").GetComponent<DataComps>();

        if (SaveSystem.GetFirstTime() == true)
        {
            musicVolSlider.value = 0.5f;
            sfxVolSlider.value = 0.8f;
        }
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(false);

        }


    }


    // update audio values in database, save system AND player speaker Game Obj
    public void UpdateVolume()
    {
        if (dataComps)
        {
            dataComps.trackVolume = musicVolSlider.value;
            dataComps.sfxVolume = sfxVolSlider.value;

            if (dataComps.playerSpeaker_ref)
            {
                dataComps.playerSpeaker_ref.gameObject.GetComponent<AudioSource>().volume = sfxVolSlider.value;
                dataComps.playerSpeaker_ref.gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().volume = musicVolSlider.value;
            }
            
        }
      




        SaveSystem.SetSfxVolume(sfxVolSlider.value);
        SaveSystem.SetTrackVolume(musicVolSlider.value);

    }

    public void DisplaySliders()
    {
        Show = !Show;

    }


    void OnEnable()
    {
        musicVolSlider.value = dataComps.trackVolume;
        sfxVolSlider.value = dataComps.sfxVolume;
    }


}
