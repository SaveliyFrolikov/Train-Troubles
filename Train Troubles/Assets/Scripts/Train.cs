﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    [SerializeField] float timer;
    float singleStep;
    float step;
    
    GameObject target;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
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
