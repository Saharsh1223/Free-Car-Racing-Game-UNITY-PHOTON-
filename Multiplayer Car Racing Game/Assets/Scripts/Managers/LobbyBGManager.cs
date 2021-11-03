using UnityEngine;

public class LobbyBGManager : MonoBehaviour
{
    [SerializeField] GameObject _BG;
    [SerializeField] Transform _bgHolder;

    void Start()
    {
        Instantiate(_BG, _bgHolder);
    }
}
