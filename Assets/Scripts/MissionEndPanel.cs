using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MissionEndPanel : MonoBehaviour
{
    private Star[] _stars;
    private ParticleSystem[] _particleSystems;

    private void Awake()
    {
        _stars = GetComponentsInChildren<Star>();
        _particleSystems = new ParticleSystem[_stars.Length];
        for (var i = 0; i < _particleSystems.Length; i++)
        {
            _particleSystems[i] = _stars[i].GetComponent<ParticleSystem>();
        }
    }

    public void Open(CampaignPoint.CampaignPointData data)
    {
        GameObject o;
        (o = gameObject).SetActive(true);
        FindObjectOfType<UIHider>()?.HideAll(o);
        StartCoroutine(WaitAnimationEnd(GetComponent<Animation>(), () =>
        {
            for (var i = 0; i < _stars.Length; i++)
            {
                _stars[i].UpdateState(i < data.Stars);
                if (_stars[i].GetState())
                    _particleSystems[i].Play();
            }
        }));
    }

    private static IEnumerator WaitAnimationEnd(Animation animation, UnityAction action)
    {
        while (animation.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }
        
        action.Invoke();
    }
    
    public void Back()
    {
        Game.Instance.Resume();
        SceneManager.LoadScene("CampaignRoadScene");
    }
}