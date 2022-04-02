using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Image progressBarImage;
    [SerializeField] private TMP_Text title;
    
    private Mob _lastMob;

    public void Open(Boss boss)
    {
        gameObject.SetActive(true);
        _lastMob = boss.Mob;
        title.text = boss.Mob.name;
        boss.Mob.healthChanged.AddListener(UpdateHealth);
    }

    private void UpdateHealth(float health)
    {
        progressBarImage.fillAmount = health / _lastMob.MaxHealth;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _lastMob.healthChanged.RemoveListener(UpdateHealth);
    }
}