using UnityEngine.Events;

namespace MissionRequirement
{
    public interface IMissionRequirement
    {
        void AddDoneCheck();
        
        void RemoveDoneCheck();

        string GetTitle();

        UnityEvent GetDoneEvent();
    }
}