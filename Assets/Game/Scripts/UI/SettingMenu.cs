using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _settingMenu;

    [Header("Button")]
    [SerializeField] private Button _closeSettingMenuButton;
    [SerializeField] private Button _openSettingMenuButton;
    [Header("Button setting")]
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _shadowButton;
    [Header("Button social")]
    [SerializeField] private Button _supportButton;
    [SerializeField] private Button _discordButton;
    [SerializeField] private Button _telegramButton;

    [Header("Button setting image")]
    [SerializeField] private Image _musicImage;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Image _shadowImage;

    [Header("Sprite preferences")]
    [SerializeField] private Sprite _onSettingButton;
    [SerializeField] private Sprite _offSettingButton;

    private bool _isMusicOn;
    private bool _isSoundOn;
    private bool _isShadowOn;

    public void Initialized ()
    {
        SettingButton();
        SettingMenuButton();
        SettingSocialButton();
    }

    private void SwitchSettings(bool boolSetting, Image buttonImage)
    {
        if (boolSetting)
        {
            buttonImage.sprite = _offSettingButton;
        }
        else if (!boolSetting)
        {
            buttonImage.sprite = _onSettingButton;
        }
    }

    private void SettingMenuButton()
    {
        _settingMenu.SetActive(false);

        _openSettingMenuButton.onClick.AddListener(() => { 
            _settingMenu.SetActive(true);
        });

        _closeSettingMenuButton.onClick.AddListener(() => {
            _settingMenu.SetActive(false);
        });
    }

    private void SettingButton()
    {
        _isMusicOn = true;
        _isSoundOn = true;
        _isShadowOn = true;

        _musicButton.onClick.AddListener(() => {
            SwitchSettings(_isMusicOn, _musicImage);

            if (_isMusicOn) { _isMusicOn = false; MusicOff(); }
            else { _isMusicOn = true; MusicOn(); }
        });

        _soundButton.onClick.AddListener(() => {
            SwitchSettings(_isSoundOn, _soundImage);

            if (_isSoundOn) { _isSoundOn = false; SoundOff(); }
            else { _isSoundOn = true; SoundOn(); }
        });

        _shadowButton.onClick.AddListener(() => {
            SwitchSettings(_isShadowOn, _shadowImage);

            if (_isShadowOn) { _isShadowOn = false; ShadowOff(); }
            else { _isShadowOn = true; ShadowOn(); }
        });
    }

    private void SettingSocialButton()
    {
        _supportButton.onClick.AddListener(() => {
            print("Link in Gamail support/site .....");
        });

        _discordButton.onClick.AddListener(() => {
            print("Link in Discord group");
        });

        _telegramButton.onClick.AddListener(() => {
            print("Link in Telegram group");
        });
    }

    private void MusicOff()
    {
        print("Music Off");
    }

    private void MusicOn()
    {
        print("Music On");
    }

    private void SoundOff()
    {
        print("Sound Off");
    }

    private void SoundOn()
    {
        print("Sound On");
    }

    private void ShadowOff()
    {
        print("Shadow Off");
    }

    private void ShadowOn()
    {
        print("Shadow On");
    }
}
