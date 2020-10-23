using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UID : MonoBehaviour
{
    public static string uID = System.Guid.NewGuid().ToString();

    public string Uiid;
    void Start()
    {
        uID = System.Guid.NewGuid().ToString();

        Uiid = uID;
    }
}
