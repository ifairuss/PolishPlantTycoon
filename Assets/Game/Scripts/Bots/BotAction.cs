using UnityEngine;
using UnityEngine.AI;

public class BotAction : MonoBehaviour
{
    [Header("All bot positions")]
    [SerializeField] private Transform _botWaitPosition;
    [SerializeField] private Transform _botPickUpBoxPosition;

    
    private Transform _botBoxSalePosition;
    private NavMeshAgent _botNavMeshAgent;
    private BotInventory _botInventory;
    private Animator _botAnimator;

    public bool IsBotStorageFull;

    public void Initialized()
    {
        _botNavMeshAgent = GetComponent<NavMeshAgent>();
        _botInventory = GetComponentInChildren<BotInventory>();
        _botAnimator = GetComponent<Animator>();

        _botBoxSalePosition = GameObject.FindWithTag("BoxSalePosition").GetComponent<Transform>();
    }


    private void Update()
    {
        BotActions();
    }

    private void BotActions()
    {
        if (Vector3.Distance(transform.position, _botPickUpBoxPosition.position) <= 10)
        {
            _botInventory.BotWalkingToMachine = false;
        }

        if (!IsBotStorageFull && Vector3.Distance(transform.position, _botWaitPosition.position) <= 2) { _botAnimator.SetBool("isWalking", false); }
        else { _botAnimator.SetBool("isWalking", true); }

        if (IsBotStorageFull && _botInventory.BoxsInStorageBot < 3)
        {
            _botNavMeshAgent.SetDestination(_botPickUpBoxPosition.position);
        }
        else if (!IsBotStorageFull && _botInventory.BoxsInStorageBot < 3)
        {
            _botNavMeshAgent.SetDestination(_botWaitPosition.position);
        }
        else if (_botInventory.BoxsInStorageBot >= 3)
        {
            _botNavMeshAgent.SetDestination(_botBoxSalePosition.position);

            if (Vector3.Distance(transform.position, _botBoxSalePosition.position) <= 3)
            {
                _botInventory.BoxsInStorageBot = 0;
                _botInventory.BotWalkingToMachine = true;
            }
        }
    }
}
