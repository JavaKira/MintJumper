using System;
using Behaviour;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlayerBehaviour _playerBehaviour;
    private BoxCollider2D[] _playerColliders;
    private bool _triggerEnter;
    private bool _getDown;
    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (_getDown)
        {
            SetIgnore(true);
            if ((_playerBehaviour.transform.position - transform.position).y < 0.3)
                _getDown = false;
        }
        else if (_triggerEnter)
        {
            SetIgnore((_playerBehaviour.transform.position - transform.position).y < 0.3);
        }
    }

    private void SetIgnore(bool ignore)
    {
        if (!_triggerEnter) return;
        foreach (var boxCollider2D in _playerColliders)
        {
            Physics2D.IgnoreCollision(_collider2D, boxCollider2D, ignore);
        }
    }

    private void OnPlayerDown()
    {
        _getDown = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerBehaviour>();
        if (player == null) return;
        _playerBehaviour = player;
        _playerColliders = player.GetComponentsInChildren<BoxCollider2D>();
        _triggerEnter = true;
        _playerBehaviour.OnDown.AddListener(OnPlayerDown);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerBehaviour>();
        if (player == null) return;
        if (Physics2D.GetIgnoreCollision(_collider2D, other))
            Physics2D.IgnoreCollision(_collider2D, other, false);
        _triggerEnter = false;
        _getDown = false;
        SetIgnore(false);
        _playerBehaviour.OnDown.RemoveListener(OnPlayerDown);
    }
}