using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public class Necromancer : Unit, IPointerClickHandler, IUnitDeath
    {
        protected override void UpdateTarget()
        {
            this.Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => this.maxHealth;

        protected override void UnitSetup()
        {
            this.maxHealth = this.MaxHealth;
            this.Health = this.MaxHealth;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            FindObjectOfType<Target>().PlayerTarget = this.gameObject;
        }
        public void OnDeath()
        {
            if (!this.IsDead) return;
            this.SendMessage("Fader", SendMessageOptions.DontRequireReceiver);
        }
    }
}