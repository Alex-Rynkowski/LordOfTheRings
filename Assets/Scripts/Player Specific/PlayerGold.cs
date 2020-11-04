using UnityEngine;
using UnityEngine.UI;

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
                GetComponent<Text>().text = Gold.ToString();
            }
        }

        void Start()
        {
            GetComponent<Text>().text = Gold.ToString();
        }
    }
}