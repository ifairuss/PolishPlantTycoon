using UnityEngine;

public class SalesZone : MonoBehaviour
{

    private Inventory _playerInventory;
    private GameManager _gameManager;

    public void Initialized()
    {
        _playerInventory = GameObject.FindWithTag("Player").GetComponentInChildren<Inventory>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponentInChildren<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            var box = other.gameObject.GetComponent<BoxStorageInfo>();

            _playerInventory.RemoveBoxInInventory(box.gameObject);
            _gameManager.SetMoney(box.BoxInfo.Price);

            Destroy(box.gameObject);
        }
    }
}
