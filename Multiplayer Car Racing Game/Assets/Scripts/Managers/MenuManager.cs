using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class MenuManager : MonoBehaviour
{
    public void CloseMenu(GameObject _menu)
    {
        _menu.SetActive(false);
        Debug.Log("Closed " + _menu.name + " menu", _menu);
    }

    public void OpenMenu(GameObject _menu)
    {
        _menu.SetActive(true);
        Debug.Log("Opened " + _menu.name + " menu", _menu);
    }

    public void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        Debug.Log("Loaded " + _sceneName + " scene", gameObject);
    }

    public void LoadPhotonLevel(string _sceneName)
    {
        PhotonNetwork.LoadLevel(_sceneName);
        Debug.Log("Loaded " + _sceneName + " scene", gameObject);
    }
}
