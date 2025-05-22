using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public int maxClients = 1;

    public float clietnSpawnDelay = 30f;

    public List<AI_Brain> clietnts;

    public int activeClients = 0;

    private float timer = 0;

    private void Awake()
    {
        foreach(AI_Brain brain in clietnts) 
        {
            brain.OnUserExit += DeactivateClient;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= clietnSpawnDelay)
        {
            if (activeClients < maxClients)
            {
                ActivateClient();
            }
            timer = 0;
        }
    }

    public void ActivateClient() 
    {
        List<AI_Brain> allInactieveBrain = clietnts.FindAll(x => !x.gameObject.activeSelf);

        AI_Brain randomInactieveBrain = allInactieveBrain[Random.Range(0, allInactieveBrain.Count)];

        if(randomInactieveBrain == null) 
        {
            Debug.LogError("No inactive clients");
            return;
        }

        randomInactieveBrain.gameObject.SetActive(true);
        randomInactieveBrain.StateMachine.SetState(randomInactieveBrain.StateMachine.enterInRoom);
        activeClients++;
    }

    public void DeactivateClient(AI_Brain client) 
    {
        client.gameObject.SetActive(false);
        activeClients--;
    }

    private void OnDestroy()
    {
        foreach(AI_Brain client in clietnts) 
        {
            client.OnUserExit -= DeactivateClient;
        }
    }
}
