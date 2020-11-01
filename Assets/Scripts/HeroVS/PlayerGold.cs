using UnityEngine;

namespace HeroVS
{
    public class PlayerGold : MonoBehaviour
    {
        [SerializeField] int gold;

        public int Gold
        {
            get => gold;
            set => gold = value;
        }
    }
}