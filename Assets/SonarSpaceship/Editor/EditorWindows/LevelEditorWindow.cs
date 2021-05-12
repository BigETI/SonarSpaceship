using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SonarSpaceshipEditor.EditorWindows
{
    public class LevelEditorWindow : EditorWindow, ILevelEditorWindow
    {
        private List<GameObject> selectedGameObjects = new List<GameObject>();

        private bool isAddingWithRandomRotationEnabled = true;

        private string newGameObjectsName = string.Empty;

        private GameObject containersGameObject;

        private GameObject containerEntityAsset;

        private GameObject rocksGameObject;

        private GameObject rockEntityAsset;

        private GameObject minesGameObject;

        private GameObject mineEntityAsset;

        private GameObject refillStationsGameObject;

        private GameObject refillStationEntityAsset;

        [MenuItem("Sonar Spaceship/Level editor")]
        private static void InitializeWindow() => GetWindow<LevelEditorWindow>("Level editor - Sonar Spaceship").Show();

        private void ShowAddEntityGUI(string action, string assetPath, string parentGameObjectName, ref GameObject parentGameObject, ref GameObject entityAsset)
        {
            if (!parentGameObject || !parentGameObject.activeInHierarchy || (parentGameObject.name != parentGameObjectName))
            {
                parentGameObject = GameObject.Find(parentGameObjectName);
            }
            if (parentGameObject)
            {
                if (!entityAsset)
                {
                    entityAsset = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                }
                if (entityAsset && GUILayout.Button(action))
                {
                    if (PrefabUtility.InstantiatePrefab(entityAsset) is GameObject game_object)
                    {
                        game_object.transform.SetParent(parentGameObject.transform, false);
                        game_object.transform.localPosition = Vector3.zero;
                        if (isAddingWithRandomRotationEnabled)
                        {
                            game_object.transform.localRotation = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f - float.Epsilon), Vector3.forward);
                        }
                        Selection.activeGameObject = game_object;
                        foreach (SceneView scene_view in SceneView.sceneViews)
                        {
                            if (scene_view.camera)
                            {
                                Vector3 camera_position = scene_view.camera.transform.position;
                                game_object.transform.position = new Vector3(camera_position.x, camera_position.y, 0.0f);
                                scene_view.AlignViewToObject(game_object.transform);
                                scene_view.rotation = Quaternion.identity;
                            }
                        }
                    }
                }
            }
        }

        private string GetCommonNamePrefix()
        {
            string ret = string.Empty;
            if (selectedGameObjects.Count > 0)
            {
                ret = selectedGameObjects[0].name;
                for (int index = 1; (index < selectedGameObjects.Count) && (ret.Length > 0); index++)
                {
                    string game_object_name = selectedGameObjects[index].name;
                    while (!game_object_name.Contains(ret) && (ret.Length > 0))
                    {
                        ret = ret.Substring(0, ret.Length - 1);
                    }
                }
            }
            return ret;
        }

        private void OnGUI()
        {
            GameObject[] selected_game_objects = Selection.gameObjects;
            GUILayout.Label("Add entities");
            GUILayout.Space(12.0f);
            isAddingWithRandomRotationEnabled = EditorGUILayout.Toggle("With random rotation", isAddingWithRandomRotationEnabled);
            ShowAddEntityGUI("Add a container", "Assets/SonarSpaceship/Prefabs/Entities/ContainerEntityObject.prefab", "========== CONTAINERS ==========", ref containersGameObject, ref containerEntityAsset);
            ShowAddEntityGUI("Add a rock", "Assets/SonarSpaceship/Prefabs/Entities/RockEntityObject.prefab", "========== ROCKS ==========", ref rocksGameObject, ref rockEntityAsset);
            ShowAddEntityGUI("Add a mine", "Assets/SonarSpaceship/Prefabs/Entities/MineEntityObject.prefab", "========== MINES ==========", ref minesGameObject, ref mineEntityAsset);
            ShowAddEntityGUI("Add a refill station", "Assets/SonarSpaceship/Prefabs/Entities/RefillStationEntityObject.prefab", "========== TRIGGERS ==========", ref refillStationsGameObject, ref refillStationEntityAsset);
            GUILayout.Space(24.0f);
            if (selected_game_objects != null)
            {
                GUILayout.Label("Edit game objects");
                GUILayout.Space(12.0f);
                foreach (GameObject selected_game_object in selected_game_objects)
                {
                    if ((selected_game_object.scene != null) && selected_game_object.scene.isLoaded)
                    {
                        selectedGameObjects.Add(selected_game_object);
                    }
                }
                if (selectedGameObjects.Count > 0)
                {
                    string action_name = $"Randomize rotation ({ selectedGameObjects.Count })";
                    if (GUILayout.Button(action_name))
                    {
                        foreach (GameObject selected_game_object in selectedGameObjects)
                        {
                            Undo.RecordObject(selected_game_object.transform, action_name);
                            selected_game_object.transform.localRotation = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f - float.Epsilon), Vector3.forward);
                        }
                    }
                    newGameObjectsName = EditorGUILayout.TextField("New game objects name", newGameObjectsName);
                    string new_game_object_name = string.IsNullOrWhiteSpace(newGameObjectsName) ? GetCommonNamePrefix() : newGameObjectsName;
                    if (!string.IsNullOrWhiteSpace(new_game_object_name))
                    {
                        action_name = $"Bulk rename game objects to \"{ new_game_object_name }\" ({ selectedGameObjects.Count })";
                        if (GUILayout.Button(action_name))
                        {
                            foreach (GameObject selected_game_object in selectedGameObjects)
                            {
                                Undo.RecordObject(selected_game_object, action_name);
                                selected_game_object.name = new_game_object_name;
                            }
                        }
                    }
                    selectedGameObjects.Clear();
                }
                else
                {
                    GUILayout.Label("Select atleast one game object to edit.");
                }
            }
        }
    }
}
