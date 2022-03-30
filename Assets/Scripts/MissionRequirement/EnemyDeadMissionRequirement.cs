using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MissionRequirement
{
    [CreateAssetMenu(menuName = "MissionRequirement/EnemyDeadMissionRequirement")]
    public class EnemyDeadMissionRequirement : ScriptableObject, IMissionRequirement
    {
        [SerializeField] private string title;

        private readonly UnityEvent _doneEvent = new UnityEvent();

        public void AddDoneCheck()
        {
            Game.Instance.Stats.Changed.AddListener(DoneCheck);
        }

        public void RemoveDoneCheck()
        {
            Game.Instance.Stats.Changed.RemoveListener(DoneCheck);
        }

        private void DoneCheck()
        {
            if (!Game.Instance.Stats.GetMobsLive().Any(pair =>
            {
                var mob = Mob.GetByName(pair.Key);
                return mob != null && mob.Enemy && pair.Value != 0;
            }))
                _doneEvent.Invoke();
        }

        public string GetTitle()
        {
            return title;
        }

        public UnityEvent GetDoneEvent()
        {
            return _doneEvent;
        }
    }
}