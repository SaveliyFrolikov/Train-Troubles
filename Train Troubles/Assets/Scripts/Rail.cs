using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public Connector connector1;
    public Connector connector2;
    public Connector connector3;

    public bool isPlaced = false;

    [SerializeField] LayerMask mask;

    public GameObject straight1, straight2, straight3;
    public GameObject bend1, bend2, bend3;

    [SerializeField] AudioClip[] pop;
    AudioClip popClip;
    AudioSource audioSource;

    bool put;
    [SerializeField]bool tutRail = false;

    [SerializeField] GameObject img12, squares;
    
    void Start()
    {
        put = false;
        
        audioSource = GetComponent<AudioSource>();

        if (isPlaced)
        {
            put = true;
        }
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

            RailPlacer.holdingRail = true;
        }
        else
        {
            Cursor.visible = true;

            if (!put)
            {
                RailPlacer.holdingRail = false;
                MoneyManager manager = GameObject.Find("Manager").GetComponent<MoneyManager>();
                manager.money -= 3;
                int index = Random.Range(0, pop.Length);
                popClip = pop[index];
                audioSource.clip = popClip;
                audioSource.Play();
                put = true;
            }
        }
    }

    private void OnDestroy()
    {
        if (tutRail)
        {
            img12.SetActive(true);
            squares.SetActive(true);
            RailPlacer.holdingRail = false;
        }
    }
}
