using UnityEngine;
using Photon.Pun;

public class CameraSideView : MonoBehaviour
{
    [SerializeField] PhotonView _photonView;

    void Start()
    {
        if (_photonView.IsMine)
        {
            DriftCamera.instance.sideView = transform;
            Debug.Log("Got camera SideView", DriftCamera.instance.gameObject);
        }
    }
}
