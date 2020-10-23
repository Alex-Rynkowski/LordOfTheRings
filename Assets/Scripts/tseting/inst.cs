using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inst : MonoBehaviour
{

    public UID me;
    public static List<UID> lista = new List<UID>();

    void Start()
    {
        foreach (var l in lista)                     
        {                                            
            print(l.Uiid);                           
            PlayerPrefs.GetInt(l.Uiid.ToString(), 1);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            var asd = Instantiate(me);
            lista.Add(asd);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var l in lista)
            {
                print(l.Uiid);
                PlayerPrefs.SetInt(l.Uiid.ToString(), 1);
            }
        }
        
        
        
        
        
    }
}
