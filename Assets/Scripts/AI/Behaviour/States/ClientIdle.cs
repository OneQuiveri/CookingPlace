using OneQuiveri;
using UnityEngine;

public class ClientIdle : IState
{

    private AI_Brain user;

    private float timeCounter = 0;

    public ClientIdle(AI_Brain user) 
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
    }

    public void Exit()
    {
        timeCounter = 0;
        if (user.Emotions.IsShowed) 
        {
            user.Emotions.ShowEmotion(false,EmotionType.Sad);
        }
    }

    public void Handle()
    {
        timeCounter += Time.deltaTime;
        if (!user.AllyDetection.AllyNearby) 
        {
            user.StateMachine.SetState(user.StateMachine.previousState);
        }
        if(timeCounter >= user.Emotions.sadEmotionTime && !user.Emotions.IsShowed) 
        {
            user.Emotions.ShowEmotion(true,EmotionType.Sad);
        }

    }
}
