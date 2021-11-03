using UnityEngine;
using Photon.Pun;
using TMPro;

public class Car : MonoBehaviour
{
    [SerializeField] PhotonView _photonView;
    [Space]
    [SerializeField] TMP_Text _usernameText;
    [SerializeField] GameObject _usernameCanvas;
    [SerializeField] GameObject _ownerObj;
    //[Space]
    //[SerializeField] GameObject _needle;
    //[SerializeField] float _vehicleSpeed;

    float _startPosition = 220f, _endPosition = -41f;
    float _desiredPosition;

    void Awake()
    {
        //TODO: Set Username
        SetUsername();
    }

    void Start()
    {
        if (_photonView.IsMine)
        {
            CarSwitcher.instance.vehicle = gameObject;
            CarSwitcher.instance.spawnPoints = transform;
        }
    }

    void SetUsername()
    {
        if (!_photonView.IsMine)
        {
            _usernameCanvas.SetActive(true);
            _usernameText.text = _photonView.Owner.NickName;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (_photonView.AmOwner)
            {
                _ownerObj.SetActive(true);
            }
        }
    }

    //void FixedUpdate()
    //{
    //    UpdateNeedle();
    //}

    //void UpdateNeedle()
    //{
    //    _desiredPosition = _startPosition - _endPosition;
    //    float _temp = _vehicleSpeed / 180;
    //    _needle.transform.eulerAngles = new Vector3(0, 0, (_startPosition - _temp * _desiredPosition));
    //}
}
