using UnityEngine;
using UnityEngine.UI;

public class CampaignPoint : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private bool startResponsibilityChain;
    [SerializeField] private CampaignPoint next;
    [SerializeField] private Color noCompletedColor;
    [SerializeField] private Color availableColor;
    [SerializeField] private Color completedColor;
    [SerializeField] private MissionType missionType;

    public MissionType MissionType => missionType;
    
    public bool Available { get; private set; }
    public CampaignPointData Data { get; private set; }

    private CampaignPoint _previous;

    private void Awake()
    {
        var data = Campaign.GetData().GetData(title);
        Data = data ?? new CampaignPointData(title);
    }

    private void Start()
    {
        if (startResponsibilityChain)
        {
            UpdateState();
            UpdateColor();
        }
        
        if (next == null) return;
        
        next._previous = this;
        next.UpdateState();
        next.UpdateColor();
    }

    private void UpdateState()
    {
        if (Data.Completed)
            Available = true;
        else if (_previous != null && _previous.Data.Completed && !Data.Completed)
        {
            Available = true;
        } else if (_previous == null && !Data.Completed)
        {
            Available = true;
        }
    }
    
    private void UpdateColor()
    {
        if (Available && Data.Completed)
        {
            GetComponent<Image>().color = completedColor;
            return; 
        }
        
        if (Available)
        {
            GetComponent<Image>().color = availableColor;
            return;
        }
    
        GetComponent<Image>().color = Data.Completed ? 
            new Color(completedColor.r, completedColor.g, completedColor.b) : 
            new Color(noCompletedColor.r, noCompletedColor.g, noCompletedColor.b);
    }
    
    public void Complete()
    {
        Data.Completed = true;
    }
            
    public class CampaignPointData
    {
        public readonly string CampaignPointTitle;
        public bool Completed { get; set; }

        public int Stars;

        public CampaignPointData(string campaignPointTitle)
        {
            CampaignPointTitle = campaignPointTitle;
        }
    }        
}