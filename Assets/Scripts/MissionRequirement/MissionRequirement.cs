using UnityEngine.Events;

namespace MissionRequirement
{
    public abstract class MissionRequirement
    {
        public readonly UnityEvent DoneEvent = new UnityEvent();

        private string _title;

        protected MissionRequirement(string title)
        {
            _title = title;
        }

        public abstract void AddDoneCheck();

        public string GetTitle()
        {
            return _title;
        }        
    }
}