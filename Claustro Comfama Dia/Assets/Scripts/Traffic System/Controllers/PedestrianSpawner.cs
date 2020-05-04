using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public int pedestriansToSpawn;
    public GameObject pedestrianPrefab;
    public Transform pedestrianParent;
    void Start()
    {
        StartCoroutine(Spawn());    
    }

    IEnumerator Spawn() {
        int count = 0;

        while (count < pedestriansToSpawn) {
            GameObject obj = Instantiate(pedestrianPrefab, pedestrianParent);

            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<NavigatorController>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();
            count++;
        }
    }
}
