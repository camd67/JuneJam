using TMPro;
using UnityEngine;

namespace Player
{
    public class OnPlayerDeath : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI deathText;

        private void Awake()
        {
            GetComponent<Health>().OnDeath += () => deathText.enabled = true;
        }
    }
}
