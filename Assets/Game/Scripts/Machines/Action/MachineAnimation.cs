using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MachineAnimation : MonoBehaviour
{
    [Header("Machine preferences")]
    [SerializeField] private BotAction _bot;
    [SerializeField] private GameObject _spawnBoxPoint;
    [SerializeField] private GameObject _endBoxPoint;
    [SerializeField] private Transform _dril;
    [SerializeField] private MachinePresetInfo _machineInformation;
    [SerializeField] private BoxVariablesPreset _machineBoxInfo;
    [SerializeField] private Image _progressBar;

    private Transform _progressBarStorage;
    private Camera _camera;
    private MachineBoxStorage _machineBoxStorage;

    public int BotPrice => _machineInformation.BotPrice;

    public int MachineID { get; private set; }

    private void Start()
    {
        MachineID = _machineInformation.ID;

        _progressBarStorage = GameObject.FindWithTag("MachineProgress").GetComponent<Transform>();
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        _machineBoxStorage = GetComponentInChildren<MachineBoxStorage>();
        _progressBar.transform.SetParent(_progressBarStorage);

        _bot.Initialized();

        StartCoroutine(MachineAnimations());
    }

    public IEnumerator MachineAnimations()
    {
        if (_machineBoxStorage.BoxInStorage < _machineInformation.MaxBoxStorage)
        {
            _bot.IsBotStorageFull = false;

            _progressBar.sprite = _machineInformation.ProgressBarImage;

            float timerAnimation = 0f;

            _dril.localPosition = new Vector3(-1.25f, 0, 0);

            while (_machineInformation.TimeToCreateBox > timerAnimation)
            {
                _progressBar.gameObject.transform.LookAt(_camera.transform);
                timerAnimation += Time.deltaTime;
                _progressBar.fillAmount = timerAnimation / _machineInformation.TimeToCreateBox;
                yield return null;
            }

            _dril.localPosition = new Vector3(0, 0, 0);

            yield return new WaitForSeconds(0.2f);

            var box = Instantiate(_machineInformation.BoxPrefab, _spawnBoxPoint.transform.position, Quaternion.identity).GetComponent<BoxStorageInfo>();
            

            box.BoxInfo = _machineBoxInfo;
        }
        else
        {
            float timer = 1f;

            _bot.IsBotStorageFull = true;

            _progressBar.sprite = _machineInformation.WarningImage;

            while (timer > 0)
            {
                _progressBar.gameObject.transform.LookAt(_camera.transform);
                _progressBar.transform.localScale = new Vector3(timer, timer, timer);

                timer -= Time.deltaTime;
                yield return null;
            }

            while (timer < 1)
            {
                _progressBar.gameObject.transform.LookAt(_camera.transform);
                _progressBar.transform.localScale = new Vector3(timer, timer, timer);

                timer += Time.deltaTime;
                yield return null;
            }
        }

        yield return new WaitForSeconds(0.05f);

        StartCoroutine(MachineAnimations());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NewBox")
        {
            var box = other.GetComponent<Transform>();
            box.position = Vector3.MoveTowards(box.position, _endBoxPoint.transform.position, 5f * Time.deltaTime);
        }
    }
}
