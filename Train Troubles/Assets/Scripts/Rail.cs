using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public Connector connector1;
    public Connector connector2;

    public bool isPlaced = false;

    [SerializeField] LayerMask mask;

    public GameObject straight1, straight2;
    
    void Start()
    {
        
    }

 
    void Update()
    {
        if (!isPlaced)
        {
            Cursor.visible = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, mask))
            {
                transform.position = hit.point;
            }

            if (Input.GetMouseButtonDown(1))
            {
                transform.Rotate(0, 0, 30);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Cursor.visible = true;

                if (connector1.canConnect)
                {
                    if (connector1.conConnector.tag == "Connector_1")
                    {
                        transform.position = connector1.conConnector.transform.parent.GetComponent<Rail>().straight1.transform.position;
                        
                        connector1.conConnector.GetComponent<Connector>().isConnected = true;
                        connector1.isConnected = true;
                        isPlaced = true;
                    }

                    if (connector1.conConnector.tag == "Connector_2")
                    {
                        transform.position = connector1.conConnector.transform.parent.GetComponent<Rail>().straight2.transform.position;
                        connector1.conConnector.GetComponent<Connector>().isConnected = true;
                        connector1.isConnected = true;
                        isPlaced = true;
                    }
                }
                if (connector2.canConnect)
                {
                    if (connector2.conConnector.tag == "Connector_1")
                    {
                        transform.position = connector2.conConnector.transform.parent.GetComponent<Rail>().straight1.transform.position;
                        connector2.conConnector.GetComponent<Connector>().isConnected = true;
                        connector2.isConnected = true;
                        isPlaced = true;
                    }

                    if (connector2.conConnector.tag == "Connector_2")
                    {
                        transform.position = connector2.conConnector.transform.parent.GetComponent<Rail>().straight2.transform.position;
                        connector2.conConnector.GetComponent<Connector>().isConnected = true;
                        connector2.isConnected = true;
                        isPlaced = true;
                    }
                }
            }
        }
    }
}
