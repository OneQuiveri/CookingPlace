using System;
using UnityEngine;

public abstract class TriggerBase<T> : MonoBehaviour where T : IAction
{
    [SerializeField] protected bool playerInTrigger = false;

    public bool PlayerInTrigger => playerInTrigger;

    public bool playTriggerOnce = false;

    private bool triggered = false;

    public bool playTriggerOnKey = false;
    public bool playTriggerOnEnter = false;
    public bool playTriggerOnExit = false;

    public KeyCode TriggerKey;

    public T enterTrigerAction;
    public T interactTrigerAction;
    public T exitTrigerAction;


    public virtual void OnCollisionEnter2D(Collision2D collider) 
    {
        playerInTrigger = true;

        if (playTriggerOnEnter) 
        {
            enterTrigerAction.DoAction();
        }
    }

    public virtual void OnCollisionStay2D(Collision2D collider) 
    {
        if (playTriggerOnKey) 
        {
            if (playTriggerOnce) 
            {
                if (!triggered && Input.GetKeyDown(TriggerKey))
                {
                    triggered = true;
                    interactTrigerAction.DoAction();
                }
            }
            else 
            {
                if (Input.GetKeyDown(TriggerKey))
                {
                    interactTrigerAction.DoAction();
                }
            }
        }
    }

    public virtual void OnCollisionExit2D(Collision2D collider) 
    {
        playerInTrigger = false;

        if (playTriggerOnExit) 
        {
            exitTrigerAction.DoAction();
        }
    }
}
