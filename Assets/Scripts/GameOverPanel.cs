using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public void Open(Mob mob)
    {
        if (mob.Health <= 0) 
            Open();
    }
    
    private void Open()
    {
        GameObject o;
        (o = gameObject).SetActive(true);
        FindObjectOfType<UIHider>()?.HideAll(o);
    }
}