using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStation : MonoBehaviour
{
    public bool correctStation;

    [SerializeField] GameObject train, wagon1, wagon2;
    [SerializeField] GameObject point1, point2, point3;
    [SerializeField] Material[] colors;

    GameObject obj;

    public bool arrived;

    public bool tut2 = false;

    [SerializeField] bool tutStation;

    Material trainColor;
   

    [SerializeField]Material[] w2, w1;
     
    void Start()
    {
        arrived = false;
    }

    
    void Update()
    {
        Debug.Log(arrived);

        if (correctStation && arrived && !tut2 && !tutStation)
        {
            

            Material color = colors[Random.Range(0, colors.Length)];
            w1[2] = color;
            w2[1] = color;

            GameObject iWagon2 = Instantiate(wagon2, point2.transform.position, Quaternion.identity);
            iWagon2.transform.Find("PassangerWagon").transform.Find("Cube.006").GetComponent<Renderer>().materials = w2;
            iWagon2.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);
            

            GameObject iWagon1 = Instantiate(wagon1, point1.transform.position, Quaternion.identity);
            
            iWagon1.transform.Find("CoalWagon").transform.Find("Cube.004").GetComponent<Renderer>().materials = w1;
            iWagon1.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);


            arrived = false;

            GameObject iTrain = Instantiate(train, point3.transform.position, Quaternion.identity);
            iTrain.transform.Find("TrainModel").transform.Find("Cylinder.007").GetComponent<MeshRenderer>().materials = w2;
            
            iTrain.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);

            iWagon2.GetComponent<Wagon>().train = iTrain;
            iWagon1.GetComponent<Wagon>().train = iTrain;
            iTrain.GetComponent<Train>().wagon1 = iWagon1;
            iTrain.GetComponent<Train>().wagon2 = iWagon2;
            iTrain.GetComponent<Train>().timer = 2;
            MainMenu menu = GameObject.Find("Manager").GetComponent<MainMenu>();
            menu.train = iTrain.GetComponent<Train>();

            Debug.Log(iWagon2.transform.Find("PassangerWagon").transform.Find("Cube.006"));
            correctStation = false;
        }

        if (correctStation && arrived && tut2)
        {
            Material color = colors[Random.Range(0, colors.Length)];
            w1[2] = color;
            w2[1] = color;

            GameObject iWagon2 = Instantiate(wagon2, point2.transform.position, Quaternion.identity);
            iWagon2.transform.Find("PassangerWagon").transform.Find("Cube.006").GetComponent<Renderer>().materials = w2;
            iWagon2.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);


            GameObject iWagon1 = Instantiate(wagon1, point1.transform.position, Quaternion.identity);
            iWagon1.transform.Find("CoalWagon").transform.Find("Cube.004").GetComponent<Renderer>().materials = w1;
            iWagon1.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);


            arrived = false;

            GameObject iTrain = Instantiate(train, point3.transform.position, Quaternion.identity);
            iTrain.transform.Find("TrainModel").transform.Find("Cylinder.007").GetComponent<Renderer>().materials = w2;
            Debug.Log("s");
            iTrain.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);

            iWagon2.GetComponent<Wagon>().train = iTrain;
            iWagon1.GetComponent<Wagon>().train = iTrain;
            iTrain.GetComponent<Train>().wagon1 = iWagon1;
            iTrain.GetComponent<Train>().wagon2 = iWagon2;
            iTrain.GetComponent<Train>().timer = 2;

            
            
            MainMenu menu = GameObject.Find("Manager").GetComponent<MainMenu>();
            menu.train = iTrain.GetComponent<Train>();
            menu.TutPart2();
            correctStation = false;
        }

        if (correctStation && arrived && tutStation)
        {
            MainMenu menu = GameObject.Find("Manager").GetComponent<MainMenu>();
            menu.FinishTutorial();
        }

        if (!correctStation && arrived && !tut2 && !tutStation)
        {
            
            
            w1[2] = trainColor;
            w2[1] = trainColor;

            GameObject iWagon2 = Instantiate(wagon2, point2.transform.position, Quaternion.identity);
            iWagon2.transform.Find("PassangerWagon").transform.Find("Cube.006").GetComponent<Renderer>().materials = w2;
            iWagon2.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);


            GameObject iWagon1 = Instantiate(wagon1, point1.transform.position, Quaternion.identity);

            iWagon1.transform.Find("CoalWagon").transform.Find("Cube.004").GetComponent<Renderer>().materials = w1;
            iWagon1.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);


            arrived = false;

            GameObject iTrain = Instantiate(train, point3.transform.position, Quaternion.identity);
            iTrain.transform.Find("TrainModel").transform.Find("Cylinder.007").GetComponent<MeshRenderer>().materials = w2;
            
            iTrain.transform.Rotate(0, transform.rotation.eulerAngles.y, 0);

            

            iWagon2.GetComponent<Wagon>().train = iTrain;
            iWagon1.GetComponent<Wagon>().train = iTrain;
            iTrain.GetComponent<Train>().wagon1 = iWagon1;
            iTrain.GetComponent<Train>().wagon2 = iWagon2;
            iTrain.GetComponent<Train>().timer = 10;

            MainMenu menu = GameObject.Find("Manager").GetComponent<MainMenu>();
            menu.train = iTrain.GetComponent<Train>();
            correctStation = false;
        }

        if (obj == null)
        {
            correctStation = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        obj = other.gameObject;

        if (other.gameObject.tag == "Train")
        {
            arrived = true;
            trainColor = other.gameObject.transform.Find("TrainModel").transform.Find("Cylinder.007").GetComponent<MeshRenderer>().materials[1];
        }
        else
        {
            correctStation = false;
        }
    }
}
