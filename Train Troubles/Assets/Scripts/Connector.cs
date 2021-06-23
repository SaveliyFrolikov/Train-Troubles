using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] GameObject rail;

    public GameObject conConnector;

    Rigidbody rb;

    [SerializeField] float bendRailOffset;

    public bool canConnect = false;
    public bool isConnected;

    void Start()
    {
        conConnector = null;
        rb = transform.parent.GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        if (transform.parent.tag == "BendRail" && !transform.parent.GetComponent<Rail>().isPlaced)
        {
            
        }

        if (canConnect && !rail.GetComponent<Rail>().isPlaced)
        {
           

            if (Input.GetMouseButtonDown(0))
            {
                

                if (transform.parent.tag == "StraightRail")
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
                }

                if (transform.parent.tag == "BendRail")
                {
                    if (conConnector.tag == "Connector_1")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                            
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                          
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }

                    if (conConnector.tag == "Connector_2")
                    {
                        
                        if (tag == "Connector_1")
                        {
                           

                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                            
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                            
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    { 
        if ((other.gameObject.tag == "Connector_1" || other.gameObject.tag == "Connector_2") && !rail.GetComponent<Rail>().isPlaced)
        {
            
            conConnector = other.gameObject;
            

            if (!other.gameObject.GetComponent<Connector>().isConnected && !isConnected)
            {
                
                canConnect = true;
                Debug.Log("s");
            }
            else
            {
                canConnect = false;
            }

        }
       
    }
}
