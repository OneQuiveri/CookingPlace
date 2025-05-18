using OneQuiveri;
using UnityEngine;

public class GoToGiveOrder : IState
{
    private AI_Brain user;

    public GoToGiveOrder(AI_Brain user)
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
        user.MoveToPoint(user.targetPath.path[2].point.transform.position.ToVector2());
    }

    public void Exit()
    {

    }

    public void Handle()
    {
        if (user.TargetArrived) 
        {
            user.StateMachine.SetState(user.StateMachine.clientIdle);
        }
    }
}
