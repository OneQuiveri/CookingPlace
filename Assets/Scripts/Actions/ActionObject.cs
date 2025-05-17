using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionObject", menuName = "Scriptable Objects/ActionObject")]
public class ActionObject : ScriptableObject, IAction
{
    private Action action;

    public Action Action { get => action; set { action = value; } }

    public void DoAction()
    {
        action?.Invoke();
    }
}
