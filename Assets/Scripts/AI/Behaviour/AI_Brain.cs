using UnityEngine;
using DG.Tweening;

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



    private void Awake()
    {
        if (sprite == null)
            sprite = GetComponent<SpriteRenderer>();

        if (m_AIMovoment == null)
            m_AIMovoment = GetComponent<AIMovoment>();

        stateMachine = new ClientStateMachine(this);
    }

    private void Update()
    {
        stateMachine.UpdateState();
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
        sprite.color = new Color(1, 1, 1, 0);
        sprite.DOFade(1, timeToFadeIn).SetEase(Ease.OutQuad);
    }

    public void FadeOut() 
    {
        sprite.color = new Color(1, 1, 1, 1);
        sprite.DOFade(0, timeToFadeOut).SetEase(Ease.InQuad);
    }
}
