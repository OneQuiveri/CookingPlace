using OneQuiveri;
using UnityEngine;

public class ClientIdle : IState
{

    private AI_Brain user;

    const float idleTime = 2f;

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
    }

    public void Handle()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= idleTime) 
        {
            user.StateMachine.SetState(user.StateMachine.exitFromRoom);
            Debug.Log("ExitFromIdle!"); 
        }
    }
}
