using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private List<GameObject> _allBoxInInventory;

    [Header("Inventory preferences")]
    [SerializeField] private int _maxBoxInInventory;

    public List<GameObject> AllBoxInInventory => _allBoxInInventory;
    public int MaxBoxInInventory => _maxBoxInInventory;

    public void Initialized()
    {

    }

    public void AddBoxInInventory(GameObject box)
    {
        _allBoxInInventory.Add(box);
    }

    public void RemoveBoxInInventory(GameObject box)
    {
        _allBoxInInventory.Remove(box);
    }
}
