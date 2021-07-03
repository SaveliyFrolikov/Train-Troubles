using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    

    
    bool firstRailPlaced = false;
    bool secondRailPlaced = false;

    [SerializeField]RailPlacer railPlacer;

    

    public Train train;

    [SerializeField] GameObject tutPart2, part2Rails, counter, railDir;

    [SerializeField] GameObject outro;

    [SerializeField] LevelLoader loader;

    [SerializeField] GameObject tutCounter;
    
    void Start()
    {
        
        
        firstRailPlaced = false;
        tutPart2.SetActive(false);
        part2Rails.SetActive(false);
        counter.SetActive(false);
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            if (!firstRailPlaced)
            {
                train.timer = 10;
            }

            if (!secondRailPlaced && part2Rails.activeSelf)
            {
                train.timer = 10;
            }
        }

       
    }

    

    

    public void F1()
    {
        railPlacer.tut = false;
    }

    public void F2()
    {
        railPlacer.tut = true;
    }

    public void PutFirstRail()
    {
        firstRailPlaced = true;
        train.timer = 0;
        tutCounter.GetComponent<TextMeshProUGUI>().text = 0.ToString();
    }

    public void PutSecondRail()
    {
        secondRailPlaced = true;
        railDir.SetActive(true);
        train.timer = 10;
    }

    public void TutPart2()
    {
        tutPart2.SetActive(true);
        part2Rails.SetActive(true);
        counter.SetActive(true);
    }

    public void On(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void FinishTutorial()
    {
        outro.SetActive(true);
        loader.LoadNextLevel(0);
    }
}
