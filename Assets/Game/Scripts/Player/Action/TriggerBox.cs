using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private Inventory _playerInventory;
    private float _cuurentBox = 1;

    public void Initialized() {
        _playerInventory = GetComponentInChildren<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if( _playerInventory.AllBoxInInventory.Count < _playerInventory.MaxBoxInInventory)
        {
            if (other.gameObject.tag == "NewBox")
            {
                Transform box = other.gameObject.GetComponent<Transform>();

                _playerInventory.AddBoxInInventory(box.gameObject);
                box.SetParent(_playerInventory.gameObject.transform);
                box.localRotation = Quaternion.Euler(0, 90, 0);
                box.position = _playerInventory.transform.position + box.transform.up * _cuurentBox;

                other.gameObject.tag = "Box";

                _cuurentBox += 1.25f;
            }
        }

        if(other.gameObject.tag == "SalesZone")
        {
            _cuurentBox = 1;
        }
    }
}
