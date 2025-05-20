using UnityEngine;

public class CookTrigger : TriggerBase<ActionObject>
{
    [SerializeField] GameObject cookingPotPanel;

    private void Awake()
    {
        enterTrigerAction.Action += Enter;
        exitTrigerAction.Action += Exit;
    }

    public void Enter() 
    {
        cookingPotPanel.SetActive(true);
    }

    public void Exit() 
    {
        cookingPotPanel?.SetActive(false);
    }

    private void OnDestroy()
    {
        enterTrigerAction.Action -= Enter;
        exitTrigerAction.Action -= Exit;
    }
}
