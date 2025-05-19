using UnityEngine;

public enum EmotionType { Sad, Glad, Order }

[CreateAssetMenu(fileName = "Emotion", menuName = "Scriptable Objects/Emotion")]
public class Emotion : ScriptableObject
{
    public EmotionType type;

    public Sprite emotionSprite;
}
