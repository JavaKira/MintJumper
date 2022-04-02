using IO;
using UnityEngine;

namespace Behaviour
{
    public class CampaignResetButtonBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                CampaignIO.Clear();
                EquipmentIO.Clear();
                Campaign.ReloadData();
            });
        }
    }
}