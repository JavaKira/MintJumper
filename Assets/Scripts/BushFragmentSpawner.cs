using UnityEngine;
using UnityEngine.Events;

public class BushFragmentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bushDestroyFragment;
    [SerializeField] private Sprite destroyedSprite;
    [SerializeField] private GameObject mintFragment;
   
    public void Spawn()
    {
        int angle;
        for (var i = 0; i < 5; i++)
        {
            angle = Random.Range(120, 60);
            var fragment = SpawnFragment(Mathf.Sin(angle), Mathf.Cos(angle));
            SetGameObjectParams(fragment, angle);
        }
        
        angle = Random.Range(120, 60);
        var position = transform.position;
        mintFragment.transform.position =
            new Vector3(position.x + Mathf.Sin(angle), position.y + Mathf.Cos(angle), position.z);
        SetGameObjectParams(mintFragment, angle);

        GetComponent<SpriteRenderer>().sprite = destroyedSprite;
    }

    private void SetGameObjectParams(GameObject objectToSet, float angle)
    {
        objectToSet.GetComponent<Rigidbody2D>().velocity += new Vector2(Mathf.Sin(angle) * 3, Mathf.Cos(angle) * 3);
        var rotation = objectToSet.transform.rotation;
        rotation = new Quaternion(
            angle,
            rotation.y,
            rotation.z, 
            rotation.w
        );
        objectToSet.transform.rotation = rotation;
    }
    
    private GameObject SpawnFragment(float relativeX, float relativeY)
    {
        var fragment = Instantiate(bushDestroyFragment);
        var position = transform.position;
        fragment.transform.position = new Vector3(position.x + relativeX, position.y + relativeY, position.z);
        return fragment;
    }
}