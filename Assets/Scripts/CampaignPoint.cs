using UnityEngine;
using UnityEngine.UI;

public class CampaignPoint : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private CampaignPoint next;
    [SerializeField] private Color noCompletedColor;
    [SerializeField] private Color availableColor;
    [SerializeField] private Color completedColor;
    
    public bool Available { get; private set; }
    public CampaignPointData Data { get; private set; }
    
    private CampaignPoint Previous { get; set; }

    private void Awake()
    {
        Data = new CampaignPointData(title);
    }
    
    private void Start()
    {
        UpdateColor();
                
        if (next == null) return;
        BuildGraph();
        next.BuildGraph();
        next.UpdateColor();
    }
    
    private void BuildGraph()
    {
        if (next != null)
            next.Previous = this;    
    }
    
    private void UpdateColor()
    {
        if (Previous != null && Previous.Data.Completed && !Data.Completed)
        {
            Available = true;
        } else if (Previous == null && !Data.Completed)
        {
            Available = true;
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

        public CampaignPointData(string campaignPointTitle)
        {
            CampaignPointTitle = campaignPointTitle;
        }
    }        
}