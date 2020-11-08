using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Player_Specific
{
    public class PlayerGold : MonoBehaviour
    {
        int _gold;

        public int Gold
        {
            get => PlayerPrefs.GetInt("Gold", _gold);
            set
            {
                PlayerPrefs.SetInt("Gold", value);
                GetComponent<TextMeshProUGUI>().text = ToString();
            }
        }

        void Start()
        {
            GetComponent<TextMeshProUGUI>().text = ToString();
        }

        public override string ToString()
        {
            return $"Gold: {Gold}";
        }
    }
}