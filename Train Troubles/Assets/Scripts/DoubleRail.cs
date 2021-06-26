using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleRail : MonoBehaviour
{
    public bool right;

    [SerializeField] GameObject g1;
    [SerializeField] GameObject g2;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        if (right)
        {
            g1.SetActive(true);
            g2.SetActive(false);
        }

        if (!right)
        {
            g1.SetActive(false);
            g2.SetActive(true);
        }
    }
}
