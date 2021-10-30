using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] plants;
    GameObject plant;
    int plantIndex;
    public float plantSpawnX, plantSpawnY, plantSpawnZ;

    public UnityEngine.UI.Button[] buttons;
    UnityEngine.UI.Button correctButton;

    // Start is called before the first frame update
    void Start()
    {
        plantIndex = Random.Range(0, 2);
        plant = Instantiate(plants[plantIndex], new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        correctButton = buttons[plantIndex];
    }

    // Update is called once per frame
    void Update()
    {
        correctButton.onClick.AddListener(CorrectAnswer);
    }

    void CorrectAnswer()
    {
        // Destroy current plant
        Destroy(plant);
        // Correct choice sfx & VO
        // Spawn new plant & set correct button
        plant = Instantiate(plants[plantIndex], new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        correctButton = buttons[plantIndex];
    }
}