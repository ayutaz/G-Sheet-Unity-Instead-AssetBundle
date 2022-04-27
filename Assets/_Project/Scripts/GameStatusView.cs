using TMPro;
using UnityEngine;

namespace _Project
{
    public class GameStatusView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gameStatusText;

        public void UpdateStatus(string status)
        {
            gameStatusText.text = status;
        }
    }
}