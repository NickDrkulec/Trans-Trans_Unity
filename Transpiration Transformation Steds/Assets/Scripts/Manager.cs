using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject[] Levels;
    public GameObject ResetScreen, End;

    int currentLevel;

    //when question answered wrong nothing happens for now but this will be the code for something to happen
    public void wrongAnswer()
    {
        ResetScreen.SetActive(true);
    }







    //when a question is answered correctly, the next level is loaded. If there is no next level to load, it will load an "end scene"
    public void correctAnswer()
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