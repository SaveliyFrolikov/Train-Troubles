using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    float singleStep;
    float step;
    bool newPointFound;
    GameObject target;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        singleStep = speed * Time.deltaTime;
        step = speed * Time.deltaTime;

        if (target.transform.parent.parent.GetComponent<Rail>().isPlaced)
        {
            Vector3 targetPos = target.gameObject.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetPos, singleStep, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "WayPoint")
        {
            target = other.gameObject;
        }
        else
        {
            target = null;
        }
    }
}
