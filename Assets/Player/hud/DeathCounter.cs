using TMPro;
using UnityEngine;

namespace Player.hud
{
    public class DeathCounter : MonoBehaviour
    {
        private static DeathCounter instance;

        [SerializeField]
        private int count;

        [SerializeField]
        private TextMeshProUGUI deathText;

        private void Awake()
        {
            instance = this;
        }

        public static void Increment()
        {
            instance.count++;
            instance.deathText.text = $"x {instance.count:N0}";
        }
    }
}
