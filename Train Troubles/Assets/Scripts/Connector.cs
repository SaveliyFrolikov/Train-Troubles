using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] GameObject rail;

    public GameObject conConnector;

    public bool canConnect;
    public bool isConnected;

    void Start()
    {
        
    }
   
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Connector_1" || other.gameObject.tag == "Connector_2") && !rail.GetComponent<Rail>().isPlaced)
        {
            Debug.Log("s");
            conConnector = other.gameObject;

            if (!other.gameObject.GetComponent<Connector>().isConnected && !isConnected)
            {
                if (other.transform.parent.tag == "StraightRail")
                {
                    if (other.gameObject.transform.rotation.eulerAngles.z == transform.parent.rotation.eulerAngles.z)
                    {
                        canConnect = true;
                    }
                    else if (other.gameObject.transform.rotation.eulerAngles.z == transform.parent.rotation.eulerAngles.z + 180)
                    {
                        canConnect = true;
                    }
                    else if (other.gameObject.transform.rotation.eulerAngles.z == transform.parent.rotation.eulerAngles.z - 180)
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
}
