using UnityEngine;
using UnityEngine.UI;

namespace Player.hud
{
    public class HpManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject heartUiImage;

        [SerializeField]
        private Canvas parentCanvas;

        private GameObject[] heartsOnScreen;

        private int numHeartsVisible;

        private void Start()
        {
            var health = GetComponent<Health>();
            InitializeToHp(health.maxHealth);
            health.OnHealthChange += UpdateHp;
        }

        private void InitializeToHp(float amount)
        {
            if (heartsOnScreen != null)
            {
                foreach (var heart in heartsOnScreen) Destroy(heart);
            }

            numHeartsVisible = (int)amount;
            heartsOnScreen = new GameObject[numHeartsVisible];

            for (var i = 0; i < numHeartsVisible; i++)
            {
                var heart = Instantiate(heartUiImage, parentCanvas.transform);
                var rect = heart.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(i * 75f + 37.5f, -37.5f);
                heartsOnScreen[i] = heart;
            }
        }

        private void UpdateHp(float amount)
        {
            if ((int)amount == numHeartsVisible)
            {
                return;
            }

            numHeartsVisible = (int)amount;

            for (var i = 0; i < heartsOnScreen.Length; i++)
            {
                heartsOnScreen[i].GetComponent<Image>().enabled = i < numHeartsVisible;
            }
        }
    }
}
