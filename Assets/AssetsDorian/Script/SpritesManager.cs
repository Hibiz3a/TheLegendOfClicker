using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites; 
    [SerializeField] private List<Sprite> _brokenSprites;

    Image _image;


    public static SpritesManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        _image = GetComponent<Image>();
    }

    public Sprite ChoseOneSprite()
    {
        return _sprites[Random.Range(0, _sprites.Count)];
    }

    public Sprite ChoseOneBrokenSprite()
    {
        return _brokenSprites[_sprites.IndexOf(_image.sprite)];
    }
}
