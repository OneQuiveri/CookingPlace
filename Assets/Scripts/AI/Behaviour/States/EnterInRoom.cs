using OneQuiveri;
using UnityEngine;

public class EnterInRoom : IState
{
    private AI_Brain user;

    public EnterInRoom(AI_Brain user) 
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
        user.FadeIn();
        user.MoveToPoint(user.targetPath.path[1].point.transform.position.ToVector2());
    }

    public void Exit()
    {

    }

    public void Handle()
    {
        if (user.TargetArrived) 
        {
            user.StateMachine.SetState(user.StateMachine.goToGiveOrder);
        }
        if (user.AllyDetection.AllyNearby) 
        {
            user.StateMachine.SetState(user.StateMachine.clientIdle);
        }
    }
}
