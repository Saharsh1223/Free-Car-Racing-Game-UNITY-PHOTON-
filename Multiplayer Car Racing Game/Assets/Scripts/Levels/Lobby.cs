
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField _createInput;
    [SerializeField] TMP_InputField _joinInput;
    [Space]
    [SerializeField] byte _maxPlayers = 10;
    [SerializeField] MenuManager _menuManager;
    [SerializeField] string _gameScene = "GAme";
    [Space]
    [SerializeField] RoomItem _roomItemPrefab;
    [SerializeField] Transform _contentObject;

    List<RoomItem> _roomItemsList = new List<RoomItem>();

    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        if(_createInput.text.Length >= 1)
        {
            RoomOptions _roomOptions = new RoomOptions();
            _roomOptions.MaxPlayers = _maxPlayers;

            PhotonNetwork.CreateRoom(_createInput.text, _roomOptions);
        }
    }

    public override void OnJoinedRoom()
    {
        _menuManager.LoadPhotonLevel(_gameScene);
    }

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        UpdateRoomList(_roomList);
    }

    void UpdateRoomList(List<RoomInfo> _list)
    {
        foreach (RoomItem item in _roomItemsList)
        {
            Destroy(item.gameObject);
        }
        _roomItemsList.Clear();

        foreach (RoomInfo _room in _list)
        {
            RoomItem _newRoom = Instantiate(_roomItemPrefab, _contentObject);
            _newRoom.SetRoomName(_room.Name);
            _roomItemsList.Add(_newRoom);
        }
    }

    public void JoinRoom(string _name)
    {
        PhotonNetwork.JoinRoom(_name);
    }

    public void JoinRoomBtn()
    {
        PhotonNetwork.JoinRoom(_joinInput.text);
    }

    
}
