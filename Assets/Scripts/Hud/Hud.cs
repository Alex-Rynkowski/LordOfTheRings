using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
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