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
            HudServices.ProductInfo();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    HudServices.HideProductInfo();
                }
            }
        }
    }
}