using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RailPlacer : MonoBehaviour
{
    [SerializeField] GameObject straightRail;
    [SerializeField] GameObject bendRail;
    [SerializeField] GameObject doubleRail;

    [SerializeField] GameObject img;

    bool deleting = false;
    public bool tut;

    public static bool holdingRail = false;

    void Start()
    {
        Time.timeScale = 1;
        img.SetActive(false);
        deleting = false;
    }


    void Update()
    {
        Debug.Log(holdingRail);

        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100))
            {
                if (!tut && !holdingRail)
                {
                    if (hitInfo.collider.gameObject.tag == "StraightRailPile")
                    {
                        Instantiate(straightRail);
                    }

                    if (hitInfo.collider.gameObject.tag == "BendRailPile")
                    {
                        Instantiate(bendRail);
                    }
                    if (hitInfo.collider.gameObject.tag == "DoubleRailPile")
                    {
                        Instantiate(doubleRail);
                    }

                    if (hitInfo.collider.gameObject.tag == "DoubleRail" && hitInfo.collider.gameObject.GetComponent<Rail>().isPlaced && !deleting)
                    {
                        hitInfo.collider.gameObject.GetComponent<DoubleRail>().right = !hitInfo.collider.gameObject.GetComponent<DoubleRail>().right;
                    }
                }

                if ((hitInfo.collider.gameObject.tag == "StraightRail" || hitInfo.collider.gameObject.tag == "BendRail" || hitInfo.collider.gameObject.tag == "DoubleRail") && deleting)
                {
                    deleting = false;
                    img.SetActive(false);
                    Destroy(hitInfo.collider.gameObject);
                    //hitInfo.collider.gameObject.SetActive(false);
                }
                else if(!(hitInfo.collider.gameObject.tag == "StraightRail" || hitInfo.collider.gameObject.tag == "BendRail" || hitInfo.collider.gameObject.tag == "DoubleRail") && deleting)
                {
                    deleting = false;
                    img.SetActive(false);
                }
                
            }
        }
    }

    private bool MouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void DeleteRail()
    {
        deleting = true;
        img.SetActive(true);
    }

}
