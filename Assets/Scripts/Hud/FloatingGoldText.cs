using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class FloatingGoldText : MonoBehaviour
    {
        public float speed;
        public float duration = 2f;
        public TextMeshProUGUI _goldText;

        readonly Vector3 _moveDirection = Vector3.up;
        float _resetDuration;
        public TextMeshProUGUI GoldText { get; }

        void Start()
        {
            this.GetComponent<TextMeshProUGUI>();
            this._resetDuration = this.duration;
        }



        public void SpawnGoldText(float goldValue)
        {
            this.duration = this._resetDuration;
            var instance = Instantiate(this._goldText, this.transform);
            instance.text = $"+{goldValue.ToString()} gold";
            this.StartCoroutine(this.GoldTextAnimation(instance));
        }

        IEnumerator GoldTextAnimation(TMP_Text text)
        {
            var canvasGroup = text.GetComponent<CanvasGroup>();
            while (this.duration > 0)
            {
                this.duration -= Time.deltaTime;
                canvasGroup.alpha -= (Time.deltaTime / this._resetDuration);
                text.transform.position += this._moveDirection * this.speed * Time.deltaTime;
                yield return null;
            }

            Destroy(text.gameObject);
        }
    }
}