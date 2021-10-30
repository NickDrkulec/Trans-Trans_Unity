using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject plant;
    public GameObject[] Levels;
    public GameObject ResetScreen, End;

    int currentLevel;
    float plantSpawnX = 0;
    float plantSpawnY = 143;
    float plantSpawnZ = -1;

    public void Start()
    {
        // Instantiate(plant, new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
    }

    public void Update()
    {
        if (gotCorrectAnswer())
        {
            nextLevel();
            Destroy(plant);
            // Update progress bar
            // Play correct sfx
            // Instantiate(plant, new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        }
        else
        {
            wrongAnswer();
        }
    }


    public bool gotCorrectAnswer()
    {
        // Peseudocode:
        // rv = (button clicked == object)
        bool rv = false;
        return rv;
    }

    // When question answered wrong nothing happens for now but this will be the code for something to happen
    public void wrongAnswer()
    {
        ResetScreen.SetActive(true);
    }
    
    // When a question is answered correctly, the next level is loaded. If there is no next level to load, it will load an "end scene"
    public void nextLevel()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else
        {
            End.SetActive(true);
            Levels[currentLevel].SetActive(false);
        }
    }




}