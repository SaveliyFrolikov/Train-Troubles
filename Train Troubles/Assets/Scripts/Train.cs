using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    public float timer;

    float singleStep;
    float step;

    Vector3 current;
    Vector3 past;

    bool stop;
    bool sound;
    bool timerSound;

    float timeTaken = 30;
    [SerializeField] int seconds = 30;
    bool timerEnded;

    [SerializeField]GameObject trainMaterial;
    Material trainColor;

    GameObject target;

    [SerializeField] AudioSource  audioSource;
    [SerializeField] AudioSource audioSource2;

    public GameObject wagon1;
    public GameObject wagon2;

    Material mat;

    void Start()
    {
        trainColor = trainMaterial.GetComponent<MeshRenderer>().materials[1];
        sound = false;
        audioSource.loop = false;
        timerSound = true;
        timerEnded = false;
    }

    
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerSound = true;
            timerEnded = true;
        }
        else
        {
            if (timerEnded)
            {
                InvokeRepeating("Timer", 0, 1);
                timerEnded = false;
            }

            if (timerSound)
            {
                audioSource.Play();
                timerSound = false;
            }

            current = transform.position;

            if (current != past)
            {
                stop = false;

                if (!audioSource2.isPlaying)
                {
                    audioSource2.Play();
                }
            }
            else
            {
                stop = true;
                sound = true;
                audioSource2.Stop();
              
            }
            past = current;

            timer = 0;
            singleStep = speed * Time.deltaTime;
            step = speed * Time.deltaTime;

            
            
                Vector3 targetPos = target.gameObject.transform.position - transform.position;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetPos, singleStep, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            

            if (sound && !stop)
            {
                audioSource.Play();
                sound = false;
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TrainStation")
        {
            if (transform.Find("TrainModel").transform.Find("Cylinder.007").GetComponent<MeshRenderer>().sharedMaterials[1].name.Replace(" (Instance)", "") == other.gameObject.GetComponent<MeshRenderer>().sharedMaterials[2].name.Replace(" (Instance)", ""))
            {
                mat = other.gameObject.GetComponent<MeshRenderer>().materials[2];
                other.gameObject.GetComponent<TrainStation>().correctStation = true;

                MoneyManager manager = GameObject.Find("Manager").GetComponent<MoneyManager>();
                if (timeTaken > 0)
                {
                    manager.money += 30;
                }
                if (timeTaken < 0 && timeTaken > -10)
                {
                    manager.money += 25;
                }

                if (timeTaken < -10)
                {
                    manager.money += 20;
                }
                Destroy(wagon1);
                Destroy(wagon2);
                Destroy(gameObject);
                
            }
            else
            {
                Debug.Log(transform.Find("TrainModel").transform.Find("Cylinder.007").GetComponent<MeshRenderer>().sharedMaterials[1].name.Replace(" (Instance)", "") + ":" + other.gameObject.GetComponent<MeshRenderer>().sharedMaterials[2].name.Replace(" (Instance)", ""));
                other.gameObject.GetComponent<TrainStation>().correctStation = false;
                MoneyManager manager = GameObject.Find("Manager").GetComponent<MoneyManager>();
                manager.money -= 20;
                Destroy(wagon1);
                Destroy(wagon2);
                Destroy(gameObject);
                
            }
        }
    }

    void Timer()
    {
        timeTaken--;
    }
}
