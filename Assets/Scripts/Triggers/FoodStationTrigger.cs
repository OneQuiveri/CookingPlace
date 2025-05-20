using UnityEngine;

public class FoodStationTrigger : TriggerBase<ActionObject>
{
    private void Awake()
    {
        interactTrigerAction.Action += GiveProduct;
    }

    public void GiveProduct() 
    {
        OrderManager.Instance?.targetClient?.SetReadyProduct(true);
    }

    private void OnDestroy()
    {
        interactTrigerAction.Action -= GiveProduct;
    }
}
