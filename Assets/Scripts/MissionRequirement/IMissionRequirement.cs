using UnityEngine.Events;

namespace MissionRequirement
{
    public interface IMissionRequirement
    {
        void AddDoneCheck();

        string GetTitle();

        UnityEvent GetDoneEvent();
    }
}