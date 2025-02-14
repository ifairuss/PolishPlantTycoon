using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyBotButton : MonoBehaviour
{
    [Header("Button preferences")]
    [SerializeField] private GameObject _bot;

    private Button _buyBotButton;
    private MachineAnimation _machine;
    private RectTransform _buttonStorage;
    private GameManager _gameManager;
    private TextMeshProUGUI _priceText;

    private void Start()
    {
        _buyBotButton = GetComponent<Button>();

        _priceText = GetComponentInChildren<TextMeshProUGUI>();
        _machine = GetComponentInParent<MachineAnimation>();

        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _buttonStorage = GameObject.FindWithTag("BuyBotButtonStorage").GetComponent<RectTransform>();


        _priceText.text = $"${_machine.BotPrice}";

        transform.SetParent(_buttonStorage);

        _buyBotButton.onClick.AddListener(() =>
        {
            if(GameManager.PlayerMoney >= _machine.BotPrice)
            {
                _bot.SetActive(true);

                _gameManager.GetMoney(_machine.BotPrice);

                Destroy(gameObject);
            }
        });
    }
}
