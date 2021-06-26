using UnityEngine;

public class Connector : MonoBehaviour
{
    [SerializeField] GameObject rail;

    public GameObject conConnector;

    GameObject ground;

    Rigidbody rb;

    [SerializeField] float bendRailOffset;

    public bool canConnect = false;
    public bool isConnected;

    void Start()
    {
        rail = transform.parent.gameObject;
        conConnector = null;
        rb = transform.parent.GetComponent<Rigidbody>();
        ground = GameObject.Find("Cube");
    }
   
    void Update()
    {
       
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), ground.GetComponent<Collider>(), true);

        if (canConnect && !rail.GetComponent<Rail>().isPlaced)
        {
            //Debug.Log(conConnector);

            if (Input.GetMouseButtonDown(0))
            {
                

                // Debug.Log(gameObject.tag + ":" + conConnector);

                if (transform.parent.tag == "StraightRail")
                {
                    if (conConnector.tag == "Connector_1")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight1.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight1.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }

                    if (conConnector.tag == "Connector_2")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight2.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight2.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }

                    if (conConnector.tag == "Connector_3")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight3.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight3.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().straight3.transform.position;
                            isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                        }
                    }
                }


                if (rail.tag == "BendRail")
                {
                    if (conConnector.tag == "Connector_1")
                    {
                        if (tag == "Connector_1")
                        {
                            if (conConnector.transform.parent.tag == "DoubleRail")
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                rail.transform.position += new Vector3(transform.forward.x * (bendRailOffset - 1f), 0, transform.forward.z * (bendRailOffset - 1f));
                            }
                            else if (conConnector.transform.parent.tag == "StraightRail")
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                rail.transform.position += new Vector3(transform.forward.x * (bendRailOffset - 0.9f), 0, transform.forward.z * (bendRailOffset - 0.9f));
                            }
                            else
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                            }
                        }

                        if (tag == "Connector_2")
                        {
                            if (conConnector.transform.parent.tag == "DoubleRail")
                            {
                                
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                rail.transform.position += new Vector3(transform.forward.x * (bendRailOffset - 0.1f), 0, transform.forward.z * (bendRailOffset - 0.1f));
                            }
                            else if(conConnector.transform.parent.tag == "StraightRail")
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                rail.transform.position += new Vector3(transform.forward.x * (bendRailOffset), 0, transform.forward.z * (bendRailOffset));
                            }
                            else
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                            }
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;
                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }

                    if (conConnector.tag == "Connector_2")
                    {
                        

                        if (tag == "Connector_1")
                        {
                            if (conConnector.transform.parent.tag == "StraightRail")
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                                rail.transform.position -= new Vector3(transform.forward.x * (bendRailOffset - 0.3f), 0, transform.forward.z * (bendRailOffset - 0.3f));
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                
                            }
                            else
                            {
                                
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                                rail.transform.position -= new Vector3(transform.forward.x * (bendRailOffset - 0f), 0, transform.forward.z * (bendRailOffset - 0f));
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                
                            }
                        }

                        
                        if (tag == "Connector_2")
                        {
                            if (conConnector.transform.parent.tag == "BendRail" || conConnector.transform.parent.tag == "DoubleRail")
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                                rail.transform.position += new Vector3(transform.forward.x * (bendRailOffset - 0.34f), 0, transform.forward.z * (bendRailOffset - 0.34f));
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                
                            }
                            else
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                                rail.transform.position += new Vector3(transform.forward.x * (bendRailOffset - 0f), 0, transform.forward.z * (bendRailOffset - 0f));
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                
                            }
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }

                    if (conConnector.tag == "Connector_3")
                    {
                        if (tag == "Connector_1")
                        {

                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }
                }

                if (transform.parent.tag == "DoubleRail")
                {
                    if (conConnector.tag == "Connector_1")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend1.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                    }

                    if (conConnector.tag == "Connector_2")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }
                        if (tag == "Connector_3")
                        {
                            if (conConnector.transform.parent.tag == "BendRail" || conConnector.transform.parent.tag == "DoubleRail")
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                                rail.transform.position += new Vector3(bendRailOffset - 0.6f, 0, bendRailOffset - 0.6f);
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                               
                            }
                            else
                            {
                                rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;
                                rail.transform.position += new Vector3(bendRailOffset - 0.4f, 0, bendRailOffset - 0.4f);
                                //isConnected = true;
                                rail.GetComponent<Rail>().isPlaced = true;
                                
                            }
                                
                        }
                    }

                    if (conConnector.tag == "Connector_3")
                    {
                        if (tag == "Connector_1")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                           //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_2")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
                            rail.GetComponent<Rail>().isPlaced = true;
                            rail.transform.position -= new Vector3(transform.forward.x * bendRailOffset, 0, transform.forward.z * bendRailOffset);
                        }

                        if (tag == "Connector_3")
                        {
                            rail.transform.position = conConnector.transform.parent.GetComponent<Rail>().bend2.transform.position;

                            //isConnected = true;
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
        if (other.gameObject.tag == "Connector_1" || other.gameObject.tag == "Connector_2" || other.gameObject.tag == "Connector_3")
        {
            conConnector = other.gameObject;

            if (!rail.GetComponent<Rail>().isPlaced)
            {
                if (!conConnector.GetComponent<Connector>().isConnected && !isConnected)
                {
                    canConnect = true;
                }
            }
            else if (other.gameObject.transform.parent.gameObject.GetComponent<Rail>().isPlaced && rail.GetComponent<Rail>().isPlaced)
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
                canConnect = false;
                conConnector = null;
            }
        }
        else
        {
            isConnected = false;
            canConnect = false;
            conConnector = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isConnected = false;
        canConnect = false;
        conConnector = null;
    }
}
