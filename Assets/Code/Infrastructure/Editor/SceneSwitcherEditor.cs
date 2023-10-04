#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Code.Infrastructure.Editor
{
    public class SceneSwitcherEditor : EditorWindow
    {
        private Vector2 scrollPos;

        [MenuItem("Tools/Scene Switcher")]
        private static void ShowWindow()
        {
            var window = GetWindow<SceneSwitcherEditor>();
            window.titleContent = new GUIContent("Scene Switcher");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            GUILayout.Label("Scenes", EditorStyles.boldLabel);

            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                var scene = EditorBuildSettings.scenes[i];
                if (scene.enabled)
                {
                    var sceneName = Path.GetFileNameWithoutExtension(scene.path);
                    var pressed = GUILayout.Button(i + ": " + sceneName, new GUIStyle(GUI.skin.GetStyle("Button")) { alignment = TextAnchor.MiddleLeft });

                    if (pressed && Event.current.button == 0)
                    {
                        var activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
                        EditorSceneManager.SaveScene(activeScene, activeScene.path);
                        EditorSceneManager.OpenScene(scene.path);
                    }

                    if (pressed && Event.current.button == 1)
                    {
                        var activeScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
                        EditorSceneManager.SaveScene(activeScene, activeScene.path);

                        EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Additive);

                    }
                }
            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}

#endif