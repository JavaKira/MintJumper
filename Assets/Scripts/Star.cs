using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
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
        gameObject.SetActive(true);
        _image.sprite = active ? activeSprite : deactiveSprite;
    }    
}