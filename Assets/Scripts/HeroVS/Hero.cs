﻿using System;
using UnityEngine;

namespace HeroVS
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] int heroDamage = 5;
        [SerializeField] int heroLife = 100;
        float _lastAttack;
        bool CanAttack => Time.time - _lastAttack > .6f;


        void Update()
        {
            if (CanAttack)
            {
                print("Hero is attacking");

                _lastAttack = Time.time;
            }
        }
    }
}
