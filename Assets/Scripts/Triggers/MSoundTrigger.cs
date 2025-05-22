using UnityEngine;

public class MSoundTrigger : TriggerBase<ActionObject>
{
    [SerializeField]BackgroundMusicManager manager;


    private void Awake()
    {
        enterTrigerAction.Action += SetSound;
    }

    public void SetSound() 
    {
        manager.SetMoldavian();
    }

    private void OnDestroy()
    {
        enterTrigerAction.Action -= SetSound;
    }
}
