using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    [RequireComponent(typeof(Gold)), RequireComponent(typeof(GoldPress))]
    public class Hud : MonoBehaviour
    {
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