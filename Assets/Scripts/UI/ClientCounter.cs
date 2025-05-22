using UnityEngine;
using TMPro;

public class ClientCounter : MonoBehaviour
{
    public TMP_Text text;

    public ClientManager manager;

    private void Update()
    {
        text.text = $"CLIENTS: {manager.activeClients}/{manager.maxClients}";
    }
}
