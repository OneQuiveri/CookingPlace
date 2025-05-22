using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class ClientEmotions : MonoBehaviour
{
    public RectTransform EmotionCloud;

    public Image emotionSprite;

    private Tween tween;

    private bool isShowed = false;

    public bool IsShowed => isShowed;

    public float sadEmotionTime = 1f;

    public List<Emotion> defaultEmotionList;

    public List<OrderEmotion> ordersEmotionList;

    private int targetOrderID = -1;

    public int TargetOrderID => targetOrderID;

    public AudioSource sadEmoSound;
    public AudioSource happyEmoSound;
    public AudioSource giveOrderEmoSound;

    public void ShowEmotion(bool value,EmotionType emotionType)
    {
        if (tween != null && !tween.IsComplete
            ()) 
        {
            tween.Complete();
            tween.Kill();
        }

        tween = EmotionCloud.DOScale(value ? 1 : 0, 0.3f);

        if (value) 
        {
            FindAndSetEmotionSprite(emotionType);
        }

        tween.Play();

        switch (emotionType) 
        {
            case EmotionType.Glad:
                happyEmoSound.Play(); 
                break;
            case EmotionType.Sad:
                sadEmoSound.Play();
                break;
            case EmotionType.Order:
                giveOrderEmoSound.Play();
                break;
        }

        isShowed = value;
    }

    private void FindAndSetEmotionSprite(EmotionType emotionType) 
    {
        if(emotionType == EmotionType.Sad || emotionType == EmotionType.Glad) 
        {
            var emo = defaultEmotionList.Find(x => x.type == emotionType);
            emotionSprite.sprite = emo.emotionSprite;
        }
        else if(emotionType == EmotionType.Order) 
        {
            var emo = ordersEmotionList[Random.Range(0, ordersEmotionList.Count)];

            emotionSprite.sprite = emo.emotionSprite;
            targetOrderID = emo.orderID;
        } 
    }
}
