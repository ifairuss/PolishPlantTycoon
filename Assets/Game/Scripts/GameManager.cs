using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game settings")]
    [SerializeField] private List<Transform> _areaLevelVariables;
    [SerializeField] private List<Transform> _areaBuildingZoneLevelVariables;
    [SerializeField] private List<Sprite> _areaImageMenuLevelVariables;
    [SerializeField] private Transform _areaUpgardeStorage;
    [SerializeField] private Transform _areaBuildingZoneStorage;

    [Header("Game UI panels")]
    [SerializeField] private GameObject _upgradeFactoryAreaPanel;


    public static int PlayerMoney { get; private set; }

    private FactoryAreaUpgrade _areaUpgrade;
    private ButtonManager _buttonManager;
    private SalesZone _salesZone;
    private BuyMachineMenu _buyMachineMenu;
    private MachineMenu _machineMenu;
    private PlayerInterface _playerInterface;
    private SettingMenu _settingMenu;

    private void Start()
    {
        InitializedComponents();
    }

    private void InitializedComponents()
    {
        _areaUpgrade = GetComponent<FactoryAreaUpgrade>();
        _buttonManager = GetComponent<ButtonManager>();
        _buyMachineMenu = GetComponent<BuyMachineMenu>();
        _playerInterface = GetComponent<PlayerInterface>();
        _settingMenu = GetComponent<SettingMenu>();
        _machineMenu = GameObject.FindWithTag("BuyMachineMenu").GetComponent<MachineMenu>();
        _salesZone = GameObject.FindWithTag("SalesZone").GetComponent<SalesZone>();


        PlayerMoney = 50;

        _upgradeFactoryAreaPanel.SetActive(false);

        AllAreaUpgradeLevel();
        _machineMenu.Initialized();
        _areaUpgrade.Initialized(_areaLevelVariables, _areaBuildingZoneLevelVariables, _areaImageMenuLevelVariables);
        _buyMachineMenu.Initialized();
        _salesZone.Initialized();
        _settingMenu.Initialized();

        UpgradeAreaButtons();

        _playerInterface.SetDispleyMoney(PlayerMoney);
    }

    private void AllAreaUpgradeLevel()
    {
        for (int i = 0; i < _areaUpgardeStorage.childCount; i++)
        {
            _areaLevelVariables.Add(_areaUpgardeStorage.GetChild(i).GetComponent<Transform>());
        }

        for (int i = 0; i < _areaBuildingZoneStorage.childCount; i++)
        {
            _areaBuildingZoneLevelVariables.Add(_areaBuildingZoneStorage.GetChild(i).GetComponent<Transform>());
        }
    }

    public void SetMoney(int playerMoney)
    {
        PlayerMoney += playerMoney;

        _playerInterface.SetDispleyMoney(PlayerMoney);
    }

    public void GetMoney(int playerMoney)
    {
        PlayerMoney -= playerMoney;

        _playerInterface.SetDispleyMoney(PlayerMoney);
    }

    private void UpgradeAreaButtons()
    {
        _buttonManager.OpenUpgradeAreaButton.onClick.AddListener(() => {
            _upgradeFactoryAreaPanel.SetActive(true);
        });

        _buttonManager.UpgradeAreaButton.onClick.AddListener(() => {
            _areaUpgrade.FactoryActiveArea(_areaLevelVariables, _areaBuildingZoneLevelVariables, _areaImageMenuLevelVariables, this, PlayerMoney);
        });

        _buttonManager.ExitAreaButton.onClick.AddListener(() => {
            _upgradeFactoryAreaPanel.SetActive(false);
        });
    }
}
