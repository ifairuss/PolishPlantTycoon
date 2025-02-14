using UnityEngine;
using UnityEngine.EventSystems;

public class OpenBuyMachineMenu : MonoBehaviour, IPointerClickHandler
{
     private RectTransform _buyMachineMenu;
     private RectTransform _storageBuyMachineButton;

    private void Awake()
    {
        _buyMachineMenu = GameObject.FindWithTag("BuyMachineMenu").GetComponent<RectTransform>();
        _storageBuyMachineButton = GameObject.FindWithTag("StorageBuyMachineButton").GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _buyMachineMenu.gameObject.SetActive(true);
        SetPositions();
    }

    private void SetPositions()
    {
        for (int i = 0; i < _storageBuyMachineButton.childCount; i++)
        {
            var button = _storageBuyMachineButton.GetChild(i).GetComponent<BuyMachineButton>();
            button.SetBuildingMachinePosition(transform.position, gameObject);
        }
    }
}
