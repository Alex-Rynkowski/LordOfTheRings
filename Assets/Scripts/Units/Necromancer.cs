using UnityEngine;

namespace Units
{
    public class Necromancer : Unit
    {
        protected override void UpdateTarget()
        {
            throw new System.NotImplementedException();
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth { get; }
        protected override void UnitSetup()
        {
            throw new System.NotImplementedException();
        }
    }
}