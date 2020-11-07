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
        [SerializeField] Image unitImage;

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

        public void UpdateTargetImage(Sprite unitImage)
        {
            ShouldShowTarget(true);
            this.unitImage.sprite = unitImage;
        }

        public GameObject PlayerTarget { get; set; }

        public void ShouldShowTarget(bool shouldShow)
        {
            if (!shouldShow)
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