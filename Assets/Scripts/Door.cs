using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private Sprite openedSprite;

    private BoxCollider2D _collider2D;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Open()
    {
        _spriteRenderer.sprite = openedSprite;
        _collider2D.enabled = false;
    }

    private void Close()
    {
        _spriteRenderer.sprite = closedSprite;
        _collider2D.enabled = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mob>() != null)
            Open();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Mob>() != null)
            Close();
    }
}