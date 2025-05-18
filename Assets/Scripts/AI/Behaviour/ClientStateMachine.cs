using UnityEngine;
using OneQuiveri;
public class ClientStateMachine : StateMachine
{

    bool paused;

    public bool Paused => paused;

    public EnterInRoom enterInRoom;
    public ExitFromRoom exitFromRoom;
    public GoToGiveOrder goToGiveOrder;
    public ClientIdle clientIdle;

    public ClientStateMachine(AI_Brain user) 
    {
        enterInRoom = new EnterInRoom(user);
        exitFromRoom = new ExitFromRoom(user);
        goToGiveOrder = new GoToGiveOrder(user);
        clientIdle = new ClientIdle(user);

        Initialize(enterInRoom);
    }

    public void UpdateState() 
    {
        if (!paused)
        {
            HandleState();
        }
    }

    public void SetPause(bool value) 
    {
        paused = value;
    }
}
