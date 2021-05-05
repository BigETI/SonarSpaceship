using SonarSpaceship;
using UnityEditor;
using UnityTranslator.Objects;

namespace SonarSpaceshipEditor
{
    [CustomEditor(typeof(LevelObjectScript), true)]
    public class LevelObjectEditorScript : Editor
    {
        public override void OnInspectorGUI()
        {
            if (target is LevelObjectScript level)
            {
                SceneAsset old_scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(level.ScenePath);
                serializedObject.Update();
                EditorGUI.BeginChangeCheck();
                StringTranslationObjectScript new_level_name_string_translation = EditorGUILayout.ObjectField("Level Name String Translation", level.LevelNameStringTranslation, typeof(StringTranslationObjectScript), false) as StringTranslationObjectScript;
                SceneAsset new_scene = EditorGUILayout.ObjectField("Scene", old_scene, typeof(SceneAsset), false) as SceneAsset;
                if (EditorGUI.EndChangeCheck())
                {
                    if (serializedObject.FindProperty("levelNameStringTranslation") is SerializedProperty level_name_string_translation_serialized_property)
                    {
                        level_name_string_translation_serialized_property.objectReferenceValue = new_level_name_string_translation;
                    }
                    if (AssetDatabase.GetAssetPath(new_scene) is string new_scene_path && !string.IsNullOrWhiteSpace(new_scene_path) && serializedObject.FindProperty("scenePath") is SerializedProperty scene_path_serialized_property)
                    {
                        scene_path_serialized_property.stringValue = new_scene_path;
                    }
                }
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
