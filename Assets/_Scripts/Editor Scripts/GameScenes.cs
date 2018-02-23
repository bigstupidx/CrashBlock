using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CreateAssetMenu(fileName = "GameLoader", menuName = "Game", order = 1)]
public class GameScenes : ScriptableObject
{
    public string objectName = "Game name";
    [Tooltip("The app Bundile id for Google play store")]
    public string storeName = "com.pixelroyale.GameName"; // bundle id

    [Header("Version"), Space(5)]

    public string currentVersionInStore = "1.0";
    [Tooltip("Version number for the next release")]
    public string lastVersionWIP = "1.1";

    [Header("Bundle Version Code"), Space(5)]

    public string cBVC_InStore = "1";
    [Tooltip("Bundle version code for the next release")]
    public string cBVC_WIP = "2";

    [Header("Place scenes in order!"), Space(5)]

    public List<SceneAsset> m_SceneAssets = new List<SceneAsset>();
}