using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TriggerBase<T> : MonoBehaviour where T : IAction
{
    [SerializeField] protected bool playerInTrigger = false;

    public bool PlayerInTrigger => playerInTrigger;

    public bool playTriggerOnce = false;

    protected bool triggered = false;

    public bool playTriggerOnKey = false;
    public bool playTriggerOnEnter = false;
    public bool playTriggerOnExit = false;

    public KeyCode TriggerKey;

    public T enterTrigerAction;
    public T interactTrigerAction;
    public T exitTrigerAction;


    protected virtual void Update() 
    {
        CheckKey();
    }

    private void CheckKey() 
    {
        if (playTriggerOnKey && PlayerInTrigger)
        {
            if (playTriggerOnce)
            {
                if (!triggered && Input.GetKeyDown(TriggerKey))
                {
                    Debug.LogError("KEY");
                    triggered = true;
                    interactTrigerAction?.DoAction();
                }
            }
            else
            {
                if (Input.GetKeyDown(TriggerKey))
                {
                    Debug.LogError("KEY");
                    interactTrigerAction?.DoAction();
                }
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;

            if (playTriggerOnEnter)
            {
                enterTrigerAction?.DoAction();
            }
        }
    }



    public virtual void OnTriggerStay2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {

        }
    }

    public virtual void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;

            if (playTriggerOnExit)
            {
                exitTrigerAction?.DoAction();
            }
        }
    }
}
