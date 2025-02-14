using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyMachineButton : MonoBehaviour
{
    [Header("Button preferences")]
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Image _image;

    private int _price;

    private GameObject _machinePrefab;
    private Button _buttonBuyMachine;
    private GameManager _gameManager;
    private Transform _machineStoragel;

    private Vector3 _bildingMachinePosition;
    private GameObject _destroyBuildingZone;

    public void SetPreferences(ButtonBuyMachinePreferences preferences)
    {
        _buttonBuyMachine = GetComponent<Button>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _machineStoragel = GameObject.FindWithTag("MachineStorage").GetComponent<Transform>();

        _price = preferences.MachinePrice;
        _priceText.text = $"${preferences.MachinePrice}";
        _description.text = preferences.MachineDescription;
        _machinePrefab = preferences.MachinePrefab;
        _image.sprite = preferences.MachineImage;

        _buttonBuyMachine.onClick.AddListener(() =>
        {
            if (GameManager.PlayerMoney >= _price)
            {
                var Machine = Instantiate(_machinePrefab, _bildingMachinePosition, Quaternion.Euler(0, -90, 0)).GetComponent<Transform>();
                Machine.SetParent(_machineStoragel);
                _gameManager.GetMoney(_price);
                var menu = GameObject.FindWithTag("BuyMachineMenu").GetComponent<MachineMenu>();
                menu.gameObject.SetActive(false);
                Destroy(_destroyBuildingZone);
            }
        });
    }

    public void SetBuildingMachinePosition(Vector3 position, GameObject gameObject)
    {
        _bildingMachinePosition = position;
        _destroyBuildingZone = gameObject;
    }
}
