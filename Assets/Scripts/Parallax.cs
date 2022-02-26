using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    [SerializeField] private new GameObject camera;
    
    private float _startPos, _length;

    private void Start() {
        _startPos = transform.position.x;
        _length   = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() {
        var position = camera.transform.position;
        var temp = position.x * (1 - parallaxEffect);
        var dist = position.x * parallaxEffect;

        var transform1 = transform;
        var position1 = transform1.position;
        position1 = new Vector3(_startPos + dist, position1.y, position1.z);
        transform1.position = position1;

        if (temp > _startPos + _length)
            _startPos += _length;
        else if (temp < _startPos - _length)
            _startPos -= _length;
    }
}