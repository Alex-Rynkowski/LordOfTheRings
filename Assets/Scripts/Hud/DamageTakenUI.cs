using Units;
using UnityEngine;
using UnityEngine.UI;

namespace Hud
{
    public class DamageTakenUI : MonoBehaviour
    {
        public Text damageTakenText;

        public void SpawnDamageText(float value)
        {
            var dmgText = Instantiate(damageTakenText, new Vector3(transform.position.x - 300,transform.position.y, 0), Quaternion.identity);
            dmgText.transform.parent = FindObjectOfType<Canvas>().transform;
            dmgText.text = value.ToString();
            Destroy(dmgText.gameObject, 1f);
        }
    }
}