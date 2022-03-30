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
            Game.Instance.Stats.Changed.AddListener(DoneCheck);
        }

        public void RemoveDoneCheck()
        {
            Game.Instance.Stats.Changed.RemoveListener(DoneCheck);
        }

        private void DoneCheck()
        {
            if (Game.Instance.Stats.GetMobsLive(mobType.name) == 0)
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