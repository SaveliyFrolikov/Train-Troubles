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
    public GameObject bend1, bend2;

   
    
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
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
