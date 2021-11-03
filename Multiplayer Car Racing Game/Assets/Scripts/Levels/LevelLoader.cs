using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LevelLoader : MonoBehaviourPunCallbacks
{
    [SerializeField] Animator _anim;
    [SerializeField] string _gameScene = "GAme";
    [SerializeField] float _transitionTime = 0.3f;
    [SerializeField] MenuManager _menuManager;

    public override void OnJoinedRoom()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        //_anim.SetTrigger("start");
        _anim.enabled = true;
        yield return new WaitForSeconds(_transitionTime);
        _menuManager.LoadPhotonLevel(_gameScene);
    }
}
