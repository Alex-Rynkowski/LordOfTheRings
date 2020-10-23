using System.Collections;
using Production;
using TMPro;
using Units;
using UnityEngine;

namespace Hud
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] RType resourceType;
        [SerializeField] float textLenght = 2;
        [SerializeField] float textFloatSpeed = 2;
        [SerializeField] TextMeshProUGUI floatingText;
        
        [Tooltip("Where should the text move from?")] [SerializeField]
        Transform textStartPosition;

        [Tooltip("Where should the text float towards?")] [SerializeField]
        Transform textTargetPosition;

        ProduceResources _produceResources;

        void Start()
        {
            print(System.Guid.NewGuid());
            _produceResources = FindObjectOfType<ProduceResources>();
        }

        void Update()
        {
            if (!FindObjectOfType<ProduceResources>().GoldProduceTimer && resourceType == RType.Gold && _produceResources.GoldToText > 0)
            {
                StartCoroutine(FloatingResourceText(textLenght, _produceResources.GoldToText, "$"));
            }
            if (!FindObjectOfType<ProduceResources>().WoodProduceTimer && resourceType == RType.Wood && _produceResources.WoodToText > 0)
            {
                StartCoroutine(FloatingResourceText(textLenght, _produceResources.WoodToText, ""));
            }
        }

        IEnumerator FloatingResourceText(float lenght, int produceAmount, string textIcon)
        {
            var floatText = Instantiate(floatingText, textStartPosition.position, Quaternion.identity);
            floatText.transform.parent = FindObjectOfType<Hud>().transform;
            floatText.transform.position = textStartPosition.position;

            floatingText.text = $"{produceAmount}" + textIcon;

            while (lenght > 0)
            {
                lenght -= Time.deltaTime;

                var velocity = Vector3.zero;
                var target =
                    new Vector3(floatText.transform.position.x * (textTargetPosition.position.x - textStartPosition.position.x),
                        floatText.transform.position.y * (textTargetPosition.position.y - textStartPosition.position.y), 0);

                floatText.transform.position = Vector3.SmoothDamp(floatText.transform.position, target, ref velocity,
                    this.textFloatSpeed);

                floatText.GetComponent<TextMeshProUGUI>().alpha -= Time.deltaTime;

                yield return null;
            }

            Destroy(floatText.gameObject);
        }
    }
}