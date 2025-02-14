using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactoryAreaUpgrade : MonoBehaviour
{
    [Header("Upgrade preferences")]
    [SerializeField] private int _startPriceUpgarde = 500;
    [SerializeField] private Image _upgradeAreaMenuImage;
    [SerializeField] private TextMeshProUGUI _upgradePriceDisplayText;

    private int _currentLevel;
    private int _nextLevel;

    public void Initialized(List<Transform> listAllArea, List<Transform> listAllBuildingZone, List<Sprite> nextImageMenu)
    {
        for (int i = 0; i < listAllBuildingZone.Count; i++)
        {
            listAllBuildingZone[i].gameObject.SetActive(false);
        }

        listAllArea[_currentLevel].gameObject.SetActive(true);
        listAllBuildingZone[_currentLevel].gameObject.SetActive(true);
        _upgradeAreaMenuImage.sprite = nextImageMenu[_currentLevel];
        _upgradePriceDisplayText.text = $"${_startPriceUpgarde}";
    }

    public void FactoryActiveArea(List<Transform> listAllArea, List<Transform> listAllBuildingZone, List<Sprite> nextImageMenu, GameManager gameManager, int playerMoney)
    {
        if (playerMoney >= _startPriceUpgarde && _nextLevel < (listAllArea.Count - 1))
        {
            _nextLevel = _currentLevel + 1;

            listAllArea[_currentLevel].gameObject.SetActive(false);
            listAllArea[_nextLevel].gameObject.SetActive(true);
            _upgradeAreaMenuImage.sprite = nextImageMenu[_nextLevel];
            listAllBuildingZone[_nextLevel].gameObject.SetActive(true);

            gameManager.GetMoney(_startPriceUpgarde);
            _startPriceUpgarde = _startPriceUpgarde + (_startPriceUpgarde / 4);
            _upgradePriceDisplayText.text = $"${_startPriceUpgarde}";

            _currentLevel = _nextLevel;
        }
    }
}
