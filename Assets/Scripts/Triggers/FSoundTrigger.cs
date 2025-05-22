using UnityEngine;

public class FSoundTrigger : TriggerBase<ActionObject>
{
    [SerializeField] BackgroundMusicManager manager;


    private void Awake()
    {
        enterTrigerAction.Action += SetSound;
    }

    public void SetSound()
    {
        manager.SetFrance();
    }

    private void OnDestroy()
    {
        enterTrigerAction.Action -= SetSound;
    }
}
