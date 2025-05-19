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
    }

    public void Exit()
    {
        timeCounter = 0;
        user.Emotions.ShowEmotion(false, EmotionType.Order);
    }

    public void Handle()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= idleTime && !user.AllyDetection.AllyNearby)
        {
            user.StateMachine.SetState(user.StateMachine.exitFromRoom);
            Debug.Log("ExitFromRoom!");
        }
    }
}
