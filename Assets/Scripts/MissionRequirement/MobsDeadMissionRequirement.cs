using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace MissionRequirement
{
    [CreateAssetMenu(menuName = "MissionRequirement/MobDeadMissionRequirement")]
    public class MobsDeadMissionRequirement : ScriptableObject, IMissionRequirement
    {
        [SerializeField] private LocalizedString titleReference;

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

        public LocalizedString GetStringReference()
        {
            return titleReference;
        }

        public UnityEvent GetDoneEvent()
        {
            return _doneEvent;
        }
    }
}