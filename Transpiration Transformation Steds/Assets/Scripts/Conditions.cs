using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public GameObject[] conditions;
    public int randomIndex;


    //At game start, a condition is picked
    void Start()
    {
        Pick();
    }


    //A condition is randomly picked and a clone of that object is made
    void Pick()
    {
        randomIndex = Random.Range(0, conditions.Length);
        GameObject clone = Instantiate(conditions[randomIndex], transform.position, Quaternion.identity);
    }
}
