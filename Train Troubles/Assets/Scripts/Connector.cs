using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] GameObject rail;

    public GameObject conConnector;

    public bool canConnect = false;
    public bool isConnected;

    void Start()
    {
        conConnector = null;
    }
   
    void Update()
    {
        if (canConnect)
        {
            

            if (Input.GetMouseButtonDown(0))
            {
                if (conConnector.tag == "Connector_1")
                {
                    if (tag == "Connector_1")
                    { 
                        rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight1.transform.position;
                       // conConnector.GetComponent<Connector>().isConnected = true;
                        isConnected = true;
                        rail.GetComponent<Rail>().isPlaced = true;
                    }

                    if (tag == "Connector_2")
                    {
                        rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight1.transform.position;
                        //conConnector.GetComponent<Connector>().isConnected = true;
                        isConnected = true;
                        rail.GetComponent<Rail>().isPlaced = true;
                    }
                }

                if (conConnector.tag == "Connector_2")
                {
                    if (tag == "Connector_1")
                    {
                        rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight2.transform.position;
                       // conConnector.GetComponent<Connector>().isConnected = true;
                        isConnected = true;
                        rail.GetComponent<Rail>().isPlaced = true;
                    }

                    if (tag == "Connector_2")
                    {
                        rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight2.transform.position;
                       // conConnector.GetComponent<Connector>().isConnected = true;
                        isConnected = true;
                        rail.GetComponent<Rail>().isPlaced = true;
                    }
                }

                Cursor.visible = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    { 
        if ((other.gameObject.CompareTag("Connector_1") || other.gameObject.CompareTag("Connector_2")) && !rail.GetComponent<Rail>().isPlaced)
        {

            conConnector = other.gameObject;
            

            if (!other.gameObject.GetComponent<Connector>().isConnected && !isConnected)
            {
                if (other.transform.parent.tag == "StraightRail")
                {
                       canConnect = true;
                }
                else
                {
                    canConnect = false;
                }

            }
        }
        
       
    }
}
