using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaphore : MonoBehaviour
{
    [SerializeField][Header("Monitor")]
    private bool redLight;
    [SerializeField]
    private bool greenLight;
    [Header("Timmers")]
    public float startRedLightTimmer;
    private float redLightTimmer;
    public float startGreenLightTimmer;
    private float greenLightTimmer;
    [Header("Lights")]
    public GameObject redLightObject;
    public GameObject greenLightObject;
    public GameObject yellowLightObject;
    [SerializeField][Range(0f,1f)][Tooltip("Trasition duration from yellow light to red light")]
    private float transitionDuration;
    private bool noTransition = true;
    public bool RedLight { get => redLight; set => redLight = value; }
    public bool GreenLight { get => greenLight; set => greenLight = value; }
    public Semaphore opositeSemaphore;
    public int semaphoreId;
    void Start()
    {
        greenLightTimmer = startGreenLightTimmer;
        redLightTimmer = startRedLightTimmer;
        greenLightObject.SetActive(false);
        redLightObject.SetActive(false);
        yellowLightObject.SetActive(false);

        //greenLight = true;
        //redLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (greenLight == true) {
            greenLightTimmer -= Time.deltaTime;
            greenLightObject.SetActive(true);
            if (greenLightTimmer <= 0f)
            {
                greenLight = false;
                greenLightObject.SetActive(false);
                redLight = true;
                greenLightTimmer = startGreenLightTimmer;
            }
        }
        if (redLight == true) {
            redLightTimmer -= Time.deltaTime;
            if (noTransition)
            {
                StartCoroutine("RedLightTransition");
            }
            if (redLightTimmer <= 0f) {
                redLight = false;
                redLightObject.SetActive(false);
                greenLight = true;
                redLightTimmer = startRedLightTimmer;
                noTransition = true;
            }
        }
    }

    IEnumerator RedLightTransition() {
        yellowLightObject.SetActive(true);
        yield return new WaitForSeconds(transitionDuration);
        yellowLightObject.SetActive(false);
        redLightObject.SetActive(true);
        noTransition = false;
    }
}
