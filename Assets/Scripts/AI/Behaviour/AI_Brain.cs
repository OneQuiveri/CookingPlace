using UnityEngine;
using DG.Tweening;
using System;

public class AI_Brain : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;

    public float timeToFadeIn;
    public float timeToFadeOut;

    public NPC_Path targetPath;
    
    private ClientStateMachine stateMachine;

    public ClientStateMachine StateMachine => stateMachine;

    [SerializeField] AIMovoment m_AIMovoment;

    public bool TargetArrived => m_AIMovoment.targetArrived;

    [SerializeField] private AllyDetection detection;

    bool isFaded = false;

    public AllyDetection AllyDetection => detection;

    [SerializeField] ClientEmotions emotions;

    public Action<AI_Brain> OnUserExit;
    public ClientEmotions Emotions => emotions;
    
    public bool AcceptOrder=false;

    private void Awake()
    {
        if (sprite == null)
            sprite = GetComponent<SpriteRenderer>();

        if (m_AIMovoment == null)
            m_AIMovoment = GetComponent<AIMovoment>();

        if (emotions == null)
            emotions = GetComponent<ClientEmotions>();

        stateMachine = new ClientStateMachine(this);
    }

    private void Update()
    {
        stateMachine.UpdateState();
        if(m_AIMovoment.GetMoveDirection() != Vector2.zero)detection.detectDirection = m_AIMovoment.GetMoveDirection();
    }

    public void MoveToPoint(Vector2 point) 
    {
        m_AIMovoment.SetTargetMovePint(point);
        m_AIMovoment.NeedMove(true);
    }

    public void Move(bool value) 
    {
        m_AIMovoment.NeedMove(value);
    }

    public void FadeIn() 
    {
        if(isFaded)
        sprite.color = new Color(1, 1, 1, 0);
        sprite.DOFade(1, timeToFadeIn).SetEase(Ease.OutQuad);
        isFaded = false;
    }

    public void FadeOut() 
    {
        if(!isFaded)
        sprite.color = new Color(1, 1, 1, 1);
        sprite.DOFade(0, timeToFadeOut).SetEase(Ease.InQuad);
        isFaded = true;
    }

    public void SetReadyProduct(bool value) 
    {
        if (value && !OrderManager.Instance.productReady) 
        {
            return;
        }

        AcceptOrder = value;
    }
}
