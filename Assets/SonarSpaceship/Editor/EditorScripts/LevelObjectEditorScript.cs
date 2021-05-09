using SonarSpaceship.Objects;
using UnityEditor;
using UnitySceneLoaderManagerEditor;

namespace SonarSpaceshipEditor.EditorScripts
{
    [CustomEditor(typeof(LevelObjectScript), true)]
    public class LevelObjectEditorScript : Editor, ILevelObjectEditorScript
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SerializedProperty level_name_string_translation_serialized_property = serializedObject.FindProperty("levelNameStringTranslation");
            if (level_name_string_translation_serialized_property != null)
            {
                EditorGUILayout.PropertyField(level_name_string_translation_serialized_property);
            }
            SerializedProperty scene_path_serialized_property = serializedObject.FindProperty("scenePath");
            if (scene_path_serialized_property != null)
            {
                scene_path_serialized_property.stringValue = SceneLoaderManagerEditorUtilities.DrawSceneProperty(scene_path_serialized_property);
                SceneLoaderManagerEditorUtilities.DrawAddSceneToBuildSettingsButtonIfSceneIsNotInBuildSettings(scene_path_serialized_property.stringValue);
            }
            SerializedProperty required_levels_serialized_property = serializedObject.FindProperty("requiredLevels");
            if (required_levels_serialized_property != null)
            {
                EditorGUILayout.PropertyField(required_levels_serialized_property);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
