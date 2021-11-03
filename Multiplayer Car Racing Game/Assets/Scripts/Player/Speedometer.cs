using UnityEngine;
using Photon.Pun;
using TMPro;

public class Speedometer : MonoBehaviour
{
    [SerializeField] GameObject _speedOmeterGameObject;
    [SerializeField] Rigidbody target;
    [SerializeField] PhotonView _photonView;

    [SerializeField] float _maxSpeed = 0.0f; // The maximum speed of the target ** IN KM/H **

    [SerializeField] float _minSpeedArrowAngle;
    [SerializeField] float _maxSpeedArrowAngle;

    [Header("UI")]
    [SerializeField] TMP_Text _speedLabel; // The label that displays the speed;
    [SerializeField] TMP_Text _maxSpeedLabel;
    [SerializeField] RectTransform _arrow; // The arrow in the speedometer

    float _speed = 0.0f;

    void Start()
    {
        if (!_photonView.IsMine)
        {
            _speedOmeterGameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            // 3.6f to convert in kilometers
            // ** The speed must be clamped by the car controller **
            _speed = target.velocity.magnitude * 3.6f;

            if (_speedLabel != null)
            {
                _speedLabel.text = ((int)_speed) + " km/h";
            }
                
            if (_arrow != null)
            {
                _arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(_minSpeedArrowAngle, _maxSpeedArrowAngle, _speed / _maxSpeed));
            }

            if(_speed >= _maxSpeed)
            {
                Debug.Log("MAX SPEED REACHED!", gameObject);
                _speedLabel.gameObject.SetActive(false);
                _maxSpeedLabel.gameObject.SetActive(true);
            }
            else
            {
                _speedLabel.gameObject.SetActive(true);
                _maxSpeedLabel.gameObject.SetActive(false);
            }
        }
    }
}
