using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject objectToDelete;
    
    public void Destroy()
    {
        Destroy(objectToDelete);
    }
}