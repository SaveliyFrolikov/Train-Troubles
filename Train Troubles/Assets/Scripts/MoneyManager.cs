using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int money;

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI[] numbersAtStationsText;
    [SerializeField]float[] numbersAtStations;
    [SerializeField] int winAmount;
    [SerializeField] GameObject lose, win;

    int rndn;

    void Start()
    {
        InvokeRepeating("TrainFine", 5, 5);

        for (int i = 0; i < numbersAtStations.Length; i++)
        {
            numbersAtStations[i] = Random.Range(1, 7);
        }

        for (int i = 0; i < numbersAtStations.Length; i++)
        {
            numbersAtStationsText[i].text = numbersAtStations[i].ToString();
        }

        
    }

    
    void Update()
    {
        coinText.text = money.ToString();

        if (money <= 0)
        {
            money = 0;
            Time.timeScale = 0;
            lose.SetActive(true);
        }

        if (money >= winAmount)
        {
            money = winAmount;
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }

    void TrainFine()
    {
        money -= 1;
    }

    

    void RandomNumber()
    {
        rndn = Random.Range(1, 10);
    }
}
