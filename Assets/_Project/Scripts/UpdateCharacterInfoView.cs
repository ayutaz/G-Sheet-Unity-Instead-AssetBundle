using TMPro;
using UnityEngine;

namespace _Project
{
    public class UpdateCharacterInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private TextMeshProUGUI mpText;
        [SerializeField] private TextMeshProUGUI atkText;
        [SerializeField] private TextMeshProUGUI defText;
        [SerializeField] private TextMeshProUGUI uuidText;

        public void UpdateInfoView(CharacterInfo characterInfo)
        {
            nameText.text = $"name:{characterInfo.name}";
            hpText.text = $"hp:{characterInfo.hp}";
            mpText.text = $"mp:{characterInfo.mp}";
            atkText.text = $"atk:{characterInfo.atk}";
            defText.text = $"def:{characterInfo.def}";
            uuidText.text = $"uuid:{characterInfo.uuid}";
        }
    }
}