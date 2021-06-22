using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPlacer : MonoBehaviour
{
    [SerializeField] GameObject straightRail;
    [SerializeField] GameObject bendRail;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100))
            {
                if (hitInfo.collider.gameObject.tag == "StraightRailPile")
                {
                    Instantiate(straightRail);
                }

                if (hitInfo.collider.gameObject.tag == "BendRailPile")
                {
                    Instantiate(bendRail);
                }
            }
        }
    }
}
