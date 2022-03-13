using UnityEngine;

public abstract class MissionRequirementBuilder : MonoBehaviour
{
    [SerializeField] protected string title;
        
    public abstract MissionRequirement Build();
}