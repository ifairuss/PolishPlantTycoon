using UnityEngine;

public class InstantiateBuyMachineButton : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private GameObject _buttonPrefab;

    public int MachineID;

    public void Start()
    {
        var button = Instantiate(_buttonPrefab, transform.position, Quaternion.Euler(90, 0, 0)).GetComponent<OpenBuyMachineMenu>();
        button.transform.SetParent(transform);
    }
}
