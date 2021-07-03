using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassangerCounter : MonoBehaviour
{
    [SerializeField] TrainStation station;
    public GameObject sign;

    void Start()
    {
        InvokeRepeating("Passanger", 0, Random.Range(4, 10));
    }

    
    void Update()
    {
        if (station.correctStation)
        {
            GetComponent<TextMeshProUGUI>().text = 0.ToString();
        }

        if (float.Parse(GetComponent<TextMeshProUGUI>().text) >= 30)
        {
            sign.SetActive(true);
            float timer = 5;
            timer -= Time.deltaTime;
            if (timer == 0)
            {
                MoneyManager menu = GameObject.Find("Manager").GetComponent<MoneyManager>();
                menu.money -= 1;
                timer = 5;
            }
        }
        else
        {
            sign.SetActive(false);
        }
    }

    void Passanger()
    {
        GetComponent<TextMeshProUGUI>().text = (float.Parse(GetComponent<TextMeshProUGUI>().text) + 1).ToString();
    }
}
