using UnityEngine;
using UnityEngine.UI;

public class GradientBGManager : MonoBehaviour
{
    [SerializeField] Image _bgImage;
    [SerializeField] Sprite[] _sprites;
    [SerializeField] int _selectedSprite;
    [Space]
    [SerializeField] GameObject _BG;
    [SerializeField] Transform _bgHolder;


    void Start()
    {
        _selectedSprite = Random.Range(0, _sprites.Length);
        Debug.Log(_selectedSprite);
        _bgImage.sprite = _sprites[_selectedSprite];

        Instantiate(_BG, _bgHolder);
    }
}
