using UnityEngine;
using UnityEngine.UI;

public class MachineMenu : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private Button _closeMenu;

    public void Initialized()
    {
        gameObject.SetActive(false);

        _closeMenu.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
    }
}
