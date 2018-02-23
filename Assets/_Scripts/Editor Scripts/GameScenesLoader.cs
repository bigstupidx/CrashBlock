using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameScenesLoader : EditorWindow
{
    GameScenes gameToLoad;
    List<SceneAsset> m_SceneAssets = new List<SceneAsset>();
    List<EditorBuildSettingsScene> cleanList = new List<EditorBuildSettingsScene>();

    // Add menu item named "Example Window" to the Window menu
    [MenuItem("GameLoader/Load Game from ScriptObj")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(GameScenesLoader));
    }


    void OnGUI()
    {
        GUILayout.Label("Drag the Scriptable Obj from the Game to load :", EditorStyles.boldLabel);

        // for (int i = 0; i < m_SceneAssets.Count; ++i)
        // {
        //     m_SceneAssets[i] = (SceneAsset)EditorGUILayout.ObjectField(m_SceneAssets[i], typeof(SceneAsset), false);
        // }

        // if (GUILayout.Button("Add Game"))
        // {
        //     m_SceneAssets.Add(null);
        // }

        gameToLoad = (GameScenes)EditorGUILayout.ObjectField(gameToLoad, typeof(GameScenes), false);


        GUILayout.Space(8);

        if (GUILayout.Button("Apply To Build Settings"))
        {
            SetEditorBuildSettingsScenes();
            SetProjectSettings();
        }
    }


    public void SetEditorBuildSettingsScenes()
    {
        if (gameToLoad == null)
        {
            return;
        }

        m_SceneAssets.Clear();

        for (int i = 0; i < gameToLoad.m_SceneAssets.Count; i++)
        {
            m_SceneAssets.Add(gameToLoad.m_SceneAssets[i]);
        }

        // Find valid Scene paths and make a list of EditorBuildSettingsScene
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        foreach (var sceneAsset in m_SceneAssets)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            if (!string.IsNullOrEmpty(scenePath))
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
        }

        // Set the Build Settings window Scene list
        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }

    public void SetProjectSettings()
    {
        if(gameToLoad == null)
        {
            return;
        }

        UnityEditor.PlayerSettings.bundleIdentifier = gameToLoad.storeName;
        UnityEditor.PlayerSettings.bundleVersion = gameToLoad.lastVersionWIP;
    }
}

