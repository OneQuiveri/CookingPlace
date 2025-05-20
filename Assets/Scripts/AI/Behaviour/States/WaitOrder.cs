using OneQuiveri;
using UnityEngine;

public class WaitOrder : IState
{
    private AI_Brain user;

    private float timeCounter;

    private const float idleTime = 2f;

    public WaitOrder(AI_Brain user) 
    {
        this.user = user;
    }

    public bool CanTransitionToItself => true;

    public bool CanTransitionTo(IState state)
    {
        return true;
    }

    public void Enter()
    {
        timeCounter = 0;
        user.Move(false);
        user.Emotions.ShowEmotion(true,EmotionType.Order);

        OrderManager.Instance.targetClient = user;
        OrderManager.Instance.order = user.Emotions.TargetOrderID;

    }

    public void Exit()
    {
        timeCounter = 0;
        user.Emotions.ShowEmotion(false, EmotionType.Order);

        user.Emotions.ShowEmotion(true, OrderManager.Instance.GetOrder() ? EmotionType.Glad : EmotionType.Sad);

        OrderManager.Instance.targetClient = null;
        OrderManager.Instance.order = -1;
    }

    public void Handle()
    {
        if (user.AcceptOrder) 
        {
            user.StateMachine.SetState(user.StateMachine.exitFromRoom);
            user.SetReadyProduct(false);
        }
    }
}
