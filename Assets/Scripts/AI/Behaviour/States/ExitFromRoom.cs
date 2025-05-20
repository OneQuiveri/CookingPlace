using OneQuiveri;
using UnityEngine;

public class ExitFromRoom : IState
{
    public bool CanTransitionToItself => true;
    private AI_Brain user;

    public ExitFromRoom(AI_Brain user)
    {
        this.user = user;
    }

    public bool CanTransitionTo(IState state)
    {
        return true;
    }

    public void Enter()
    {
        user.FadeOut();
        user.MoveToPoint(user.targetPath.path[3].point.transform.position.ToVector2());
    }

    public void Exit()
    {
        user.transform.position = user.targetPath.path[0].point.transform.position;
        user.Emotions.ShowEmotion(false, EmotionType.Order);
    }

    public void Handle()
    {
        if (user.TargetArrived)
        {
            user.StateMachine.SetState(user.StateMachine.enterInRoom);
        }
    }
}
