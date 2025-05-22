using UnityEngine;

public class FoodStationTrigger : TriggerBase<ActionObject>
{

    public GameObject button;

    private void Awake()
    {
        enterTrigerAction.Action += OnEnter;
        interactTrigerAction.Action += GiveProduct;
        exitTrigerAction.Action += OnExit;
    }

    public void GiveProduct() 
    {
        OrderManager.Instance?.targetClient?.SetReadyProduct(true);
    }

    protected override void Update() 
    {
        base.Update();

        if (playerInTrigger)
        {
            OnEnter();
        }
    }

    public void OnEnter() 
    {
        if (OrderManager.Instance.productReady && OrderManager.Instance.targetClient != null) 
        {
            button.SetActive(true);
        }
        else 
        {
            button.SetActive(false);
        }
    }

    public void OnExit() 
    {
        button.SetActive(false);
    }

    private void OnDestroy()
    {
        enterTrigerAction.Action -= OnEnter;
        interactTrigerAction.Action -= GiveProduct;
        exitTrigerAction.Action -= OnExit;
    }
}
