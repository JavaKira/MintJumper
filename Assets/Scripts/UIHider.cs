using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIHider : MonoBehaviour
{
    private IEnumerable<GameObject> _childrens;

    private void Start()
    {
        _childrens = from gameObj in GetComponentsInChildren<Transform>() select gameObj.gameObject;
        _childrens = _childrens.Except(new []{gameObject});
    }

    public void HideAll(GameObject except)
    {
        foreach (var children in _childrens)
        {
            if (children.Equals(except))
                continue;
            
            children.SetActive(false);
        }
    }
    
    public void SeekAll(GameObject except)
    {
        foreach (var children in _childrens)
        {
            if (children.Equals(except))
                continue;
            
            children.SetActive(true);
        }
    }
}