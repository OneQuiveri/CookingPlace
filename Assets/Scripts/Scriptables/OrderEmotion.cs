using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "OrderEmotion", menuName = "Scriptable Objects/OrderEmotion")]
public class OrderEmotion : Emotion
{
    public int orderID;
}


#if UNITY_EDITOR

[CustomEditor(typeof(OrderEmotion))]
public class OrderEmotionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Показываем все сериализованные свойства, включая унаследованные
        SerializedProperty property = serializedObject.GetIterator();
        bool expanded = true;

        if (property.NextVisible(expanded))
        {
            do
            {
                if (property.name == "m_Script") // Показываем скрипт вверху, но не редактируемым
                {
                    GUI.enabled = false;
                    EditorGUILayout.PropertyField(property, true);
                    GUI.enabled = true;
                }
                else
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }
            while (property.NextVisible(false));
        }

        serializedObject.ApplyModifiedProperties();
    }
}

#endif