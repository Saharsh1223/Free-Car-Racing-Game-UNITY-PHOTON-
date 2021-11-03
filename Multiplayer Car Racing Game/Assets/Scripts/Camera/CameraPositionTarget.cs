using UnityEngine;
using Photon.Pun;

public class CameraPositionTarget : MonoBehaviour
{
    [SerializeField] PhotonView _photonView;

    void Start()
    {
        if (_photonView.IsMine)
        {
            DriftCamera.instance.positionTarget = transform;
            Debug.Log("Got camera PositionTarget", DriftCamera.instance.gameObject);
        }
    }
}
