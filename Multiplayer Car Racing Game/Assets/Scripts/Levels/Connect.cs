using UnityEngine;
using Photon.Pun;
using TMPro;


public class Connect : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField _usernameInput;
    [Space]
    [SerializeField] GameObject _connectBtn;
    [SerializeField] TMP_Text _connectText;
    [Space]
    [SerializeField] string _lobbySceneName = "Lobby";
    [SerializeField] MenuManager _menuManager;

    public void CallOnUsernameMinCharLength()
    {
        

        if (_usernameInput.text.Length >= 1)
        {
            _connectBtn.SetActive(true);
        }
        else if(_usernameInput.text.Length < 1)
        {
            _connectBtn.SetActive(false);
        }
    }

    public void CallOnUsernameMaxCharLength()
    {
        if (_usernameInput.text.Length > 8)
        {
            _connectBtn.SetActive(false);
        }
        //else if (_usernameInput.text.Length < 8)
        //{
        //    _connectBtn.SetActive(true);
        //}
    }

    public void COnnect()
    {
        if(_usernameInput.text.Length <= 8)
        {
            Debug.Log("Connecting...", gameObject);
            _connectText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.NickName = _usernameInput.text;
        }
        else
        {
            Debug.Log("Username length more than 8");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master, loading lobby scene...", gameObject);
        _menuManager.LoadScene(_lobbySceneName);
    }
}
