using UnityEngine;
using Photon.Pun;

public class CameraLookAtTarget : MonoBehaviour
{
    [SerializeField] PhotonView _photonView;

    void Start()
    {
        if (_photonView.IsMine)
        {
            DriftCamera.instance.lookAtTarget = transform;
            Debug.Log("Got camera LookAtTarget", DriftCamera.instance.gameObject);
        }
    }
}
