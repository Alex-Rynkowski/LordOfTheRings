using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI floatingGoldText;
        [SerializeField] TextMeshProUGUI floatingWoodText;

        void Update()
        {
            if (!GetComponent<ProduceResources>().GoldProduceTimer)
            {
                StartCoroutine(FloatingGold(2f));
            }
        }


        IEnumerator FloatingGold(float floatTimer)
        {
            var floatText = Instantiate(floatingGoldText, transform.position, Quaternion.identity);
            floatText.transform.parent = FindObjectOfType<Hud>().transform;
            floatText.transform.position = floatingGoldText.transform.position;

            while (floatTimer > 0)
            {
                floatTimer -= Time.deltaTime;
                var velocity = Vector3.zero;
                floatText.transform.position = Vector3.SmoothDamp(floatText.transform.position,
                    new Vector3(floatText.transform.position.x, floatText.transform.position.y * 70, 0), ref velocity,
                    2);

                floatText.GetComponent<TextMeshProUGUI>().alpha -= Time.deltaTime;
                
                yield return null;
            }

            Destroy(floatText.gameObject);
        }

        void FloatingWoodText()
        {
        }
    }
}