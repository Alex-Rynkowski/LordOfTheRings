using System.Collections;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] float textLenght = 2;
        [SerializeField] float textFloatSpeed = 2;
        [SerializeField] TextMeshProUGUI floatingGoldText;
        [SerializeField] TextMeshProUGUI floatingWoodText;

        [Tooltip("Where should the text move from?")] [SerializeField]
        Transform goldTextStartPosition;

        [Tooltip("Where should the text float towards?")] [SerializeField]
        Transform goldTextTargetPosition;

        void Update()
        {
            if (!GetComponent<ProduceResources>().GoldProduceTimer)
            {
                StartCoroutine(FloatingResourceText(goldTextStartPosition, goldTextTargetPosition));
            }
        }

        IEnumerator FloatingResourceText(Transform startPosition, Transform targetPosition)
        {
            var floatText = Instantiate(floatingGoldText, startPosition.position, Quaternion.identity);
            floatText.transform.parent = FindObjectOfType<Hud>().transform;
            floatText.transform.position = startPosition.position;

            while (this.textLenght > 0)
            {
                this.textLenght -= Time.deltaTime;

                var velocity = Vector3.zero;
                var target =
                    new Vector3(floatText.transform.position.x * (targetPosition.position.x - startPosition.position.x),
                        floatText.transform.position.y * (targetPosition.position.y - startPosition.position.y), 0);

                floatText.transform.position = Vector3.SmoothDamp(floatText.transform.position, target, ref velocity,
                    this.textFloatSpeed);

                floatText.GetComponent<TextMeshProUGUI>().alpha -= Time.deltaTime;

                yield return null;
            }

            Destroy(floatText.gameObject);
        }
    }
}