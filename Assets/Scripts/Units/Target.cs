using UnityEngine;
using UnityEngine.UI;

namespace Units
{
    public class Target : MonoBehaviour
    {
        [SerializeField] Image health;
        [SerializeField] Image aTBGauge;
        [SerializeField] Text nameText;
        [SerializeField] Text damageTakenText;

        void Start()
        {
            ShouldShowTarget(false);
        }

        public void UpdateTargetInfo(float healthFillAmount, float atbGaugeFillAmount, string nameText, string damageTakenText, string atbText)
        {
            ShouldShowTarget(true);
            this.health.fillAmount = healthFillAmount;
            this.aTBGauge.fillAmount = atbGaugeFillAmount;
            this.nameText.text = nameText;
            this.damageTakenText.text = damageTakenText;
            this.aTBGauge.GetComponentInChildren<Text>().text = atbText;
        }

        public GameObject PlayerTarget { get; set; }

        bool HideTarget()
        {
            return health.fillAmount <= 0;
        }

        void ShouldShowTarget(bool shouldShow)
        {
            print(health.fillAmount);
            if (HideTarget())
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                return;
            }

            if (!shouldShow || HideTarget())
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                return;
            }

            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}