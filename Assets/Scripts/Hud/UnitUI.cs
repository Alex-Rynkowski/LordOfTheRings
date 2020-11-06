using System;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace Hud
{
    public class UnitUI : MonoBehaviour
    {
        public Text damageTakenText;

        void Start()
        {
            FindObjectOfType<Hero>().UpdateUI += SpawnDamageText;
        }

        void SpawnDamageText(object value)
        {
            var dmgText = Instantiate(damageTakenText, new Vector3(transform.position.x - 100,transform.position.y, 0), Quaternion.identity);
            //var dmgText = Instantiate(damageTakenText, new Vector3(FindObjectOfType<Target>().PlayerTarget.transform.position.x - 100, FindObjectOfType<Target>().PlayerTarget.transform.position.y, 0), Quaternion.identity);
            dmgText.transform.parent = FindObjectOfType<Canvas>().transform;
            dmgText.text = value.ToString();
            Destroy(dmgText.gameObject, 10f );
        }
    }
}