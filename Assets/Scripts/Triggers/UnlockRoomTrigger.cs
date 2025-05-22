using UnityEngine;

public class UnlockRoomTrigger : TriggerBase<ActionObject>
{
    bool isPurchased = false;

    public int unlockCost = 0;

    public int addMaxClients = 0;

    public SpriteRenderer LockedSprite;

    [SerializeField] GameObject lockedObject;
    [SerializeField] GameObject unlockedObject;

    [SerializeField] ClientManager clientManager;

    private void Awake()
    {
        interactTrigerAction.Action += UnlockMap;
    }

    public void UnlockMap() 
    {
        if(isPurchased) return;

        if(PlayerMoney.Instance.Money >= unlockCost) 
        {
            lockedObject.SetActive(false);
            unlockedObject.SetActive(true);

            if (LockedSprite != null)
            {
                LockedSprite.enabled = false;
            }

            isPurchased = true;

            clientManager.maxClients += addMaxClients;

            PlayerMoney.Instance.ReduceMoney(unlockCost);
        }
    }

    private void OnDestroy()
    {
        interactTrigerAction.Action -= UnlockMap;
    }
}
