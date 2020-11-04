using System.Collections;
using UnityEngine;

namespace Hud
{
    public class DamageTaken : MonoBehaviour
    {
        void Update()
        {
            StartCoroutine(FloatingText());
        }

        IEnumerator FloatingText()
        {
            var lenght = 1f;

            while (lenght > 0)
            {
                lenght -= Time.deltaTime;
                var velocity = Vector3.zero;
                var target = new Vector3(transform.position.x, transform.position.y * 100, 0);

                transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 20);

                GetComponent<CanvasGroup>().alpha = lenght;
                yield return null;
            }
        }
    }
}