using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject animations;
    void Start()
    {
        animations.SetActive(false);
        GetComponent<AudioSource>().time = GetComponent<AudioSource>().clip.length * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
     {
          animations.SetActive(true);
     }
      else if (Input.GetKeyDown("escape") )
      {
        animations.SetActive(false);
      }
    }
}


