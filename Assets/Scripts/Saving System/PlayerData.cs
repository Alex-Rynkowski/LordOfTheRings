using UnityEngine;
using Hud;

namespace Saving_System
{
    [System.Serializable]
    public class PlayerData
    {
        public int _gold;

        public PlayerData(Hud.Hud hud)
        {
            _gold = hud.Gold;
        }
    }
}