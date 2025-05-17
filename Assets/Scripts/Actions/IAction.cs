using System;
using UnityEngine;

public interface IAction
{
    public Action Action { get; set; }

    public void DoAction();
}
