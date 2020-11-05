using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public class Necromancer : Unit, IPointerClickHandler
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
        
        public void OnPointerClick(PointerEventData eventData)
        {
            FindObjectOfType<Target>().PlayerTarget = gameObject;
        }
    }
}