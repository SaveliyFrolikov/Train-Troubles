using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    
    float singleStep;
    float step;
    [SerializeField] float offset;
    public GameObject train;
    [SerializeField] GameObject target;
    bool stop = false;
    Vector3 current;
    Vector3 past;

    void Start()
    {

    }


    void Update()
    {
            current = train.transform.position;

            if (current != past)
            {
                stop = false;
            }
            else
            {
                stop = true;
            }
            past = current;

            
            singleStep = speed * Time.deltaTime;
            step = speed * Time.deltaTime;

            if (!stop)
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
            if (other.gameObject.transform.parent.parent.GetComponent<Rail>().isPlaced)
            {
                target = other.gameObject;
            }
        }
    }
}
