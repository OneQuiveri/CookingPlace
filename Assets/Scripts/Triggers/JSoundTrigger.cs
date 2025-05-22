using UnityEngine;

public class JSoundTrigger : TriggerBase<ActionObject>
{
    [SerializeField] BackgroundMusicManager manager;


    private void Awake()
    {
        enterTrigerAction.Action += SetSound;
    }

    public void SetSound()
    {
        manager.SetJaponese();
    }

    private void OnDestroy()
    {
        enterTrigerAction.Action -= SetSound;
    }
}
