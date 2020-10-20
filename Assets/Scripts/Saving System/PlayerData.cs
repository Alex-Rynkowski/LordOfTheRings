using UnityEngine;
using Hud;

namespace Saving_System
{
    [System.Serializable]
    public class PlayerData
    {
        public int gold;
        public int goldPresses;

        public PlayerData(Hud.Hud hud)
        {
            gold = hud.Gold;
            goldPresses = hud.GoldPressesOwned;
        }
    }
}