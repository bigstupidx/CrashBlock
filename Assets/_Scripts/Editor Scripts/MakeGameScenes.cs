using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeGameScenes
{
    [MenuItem("Assets/Create/Game Loader")]
    public static void CreateMyAsset()
    {
        GameScenes asset = ScriptableObject.CreateInstance<GameScenes>();

        AssetDatabase.CreateAsset(asset, "Assets/GameScenes.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}