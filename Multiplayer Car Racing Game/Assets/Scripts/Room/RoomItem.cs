using UnityEngine;
using Photon.Pun;
using TMPro;

public class RoomItem : MonoBehaviour
{
    [SerializeField] TMP_Text _roomName;
    Lobby _lobby;

    void Start()
    {
        _lobby = FindObjectOfType<Lobby>();
    }

    public void SetRoomName(string roomName)
    {
        _roomName.text = roomName;
    }

    public void JoinRoom()
    {
        _lobby.JoinRoom(_roomName.text);
    }
}
