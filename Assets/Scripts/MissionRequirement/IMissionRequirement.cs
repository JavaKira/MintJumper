using UnityEngine.Events;
using UnityEngine.Localization;

namespace MissionRequirement
{
    public interface IMissionRequirement
    {
        void AddDoneCheck();
        
        void RemoveDoneCheck();

        LocalizedString GetStringReference();

        UnityEvent GetDoneEvent();
    }
}