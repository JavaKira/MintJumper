using UnityEngine;
using UnityEngine.Events;

namespace MissionRequirement
{
    [CreateAssetMenu(menuName = "MissionRequirement/MobDeadMissionRequirement")]
    public class MobsDeadMissionRequirement : ScriptableObject, IMissionRequirement
    {
        [SerializeField] private string title;

        [SerializeField] private Mob mobType;

        private readonly UnityEvent _doneEvent = new UnityEvent();

        public void AddDoneCheck()
        {
            Game.Instance.Stats.Changed.AddListener(() =>
            {
                if (Game.Instance.Stats.GetMobsLive(mobType.name) == 0)
                    _doneEvent.Invoke();
            });
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