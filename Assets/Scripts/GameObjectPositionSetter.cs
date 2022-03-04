using UnityEngine;

public class GameObjectPositionSetter : MonoBehaviour
{
    [SerializeField] private GameObject objectToSet;
    [SerializeField] private Transform position;

    public void Set()
    {
        var position1 = position.position;
        objectToSet.transform.position = new Vector3(position1.x, position1.y, position1.z);
    }
}