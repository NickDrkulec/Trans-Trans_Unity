using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public GameObject[] conditions;
    public int randomIndex;

    void Start()
    {
        Pick();
    }

    void Pick()
    {
        randomIndex = Random.Range(0, conditions.Length);
        GameObject clone = Instantiate(conditions[randomIndex], transform.position, Quaternion.identity);
    }
}
