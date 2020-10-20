using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    [RequireComponent(typeof(Gold)), RequireComponent(typeof(GoldPress))]
    public class Hud : MonoBehaviour
    {
        public Product[] products;

        void Start()
        {
            ProductInfo();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventSystem.current.IsPointerOverGameObject();
                GetComponent<Gold>().CurrentGold += 5;
            }
        }

        public void ProductInfo()
        {
            foreach (var product in products)
            {
                product.nameText.text = product.name.ToString();
                product.costText.text = $"Cost: {product.cost}$";
                product.productionsTimeText.text = $"Production time: {product.productionTime}s";
                product.productionAmountText.text = $"Production: {product.productionAmount}x";
            }
        }
    }
}