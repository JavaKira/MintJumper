using System;
using UnityEngine;
using UnityEngine.UI;

public class MobHealthBarHeart : MonoBehaviour
{
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite deactiveSprite;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateState(bool active)
    {
        _image.sprite = active ? activeSprite : deactiveSprite;
    }
}