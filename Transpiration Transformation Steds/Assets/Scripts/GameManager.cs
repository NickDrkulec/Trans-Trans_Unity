using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] plants;
    GameObject plant;
    int plantIndex;
    int lastPlantIndex;
    public float plantSpawnX, plantSpawnY, plantSpawnZ;

    public GameObject unhealthySoil;
    GameObject badSoil;
    public float soilSpawnX, soilSpawnY, soilSpawnZ;

    public UnityEngine.UI.Button[] buttons;
    UnityEngine.UI.Button correctButton;
    public Transform UI_Canvas;

    public AudioSource audioSource;
    public AudioClip[] correctChoices;
    AudioClip correctChoiceClip;
    AudioClip lastCorrectChoiceClip;
    public float VO_Volume;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn new plant & set correct button
        plantIndex = Random.Range(0, plants.Length);
        lastPlantIndex = plantIndex;
        plant = Instantiate(plants[plantIndex], new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        plant.transform.SetParent(UI_Canvas, true);
        correctButton = buttons[plantIndex];

        // Adds bad soil if needed
        if (plantIndex == 0)
        {
            badSoil = Instantiate(unhealthySoil, new Vector3(soilSpawnX, soilSpawnY, soilSpawnZ), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttons[plantIndex].onClick.AddListener(CorrectAnswer);
    }

    void CorrectAnswer()
    {
        // Play a random correct choice VO line
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            while (correctChoiceClip == lastCorrectChoiceClip)
            {
                correctChoiceClip = RandomClip(correctChoices, lastCorrectChoiceClip);
            }
            audioSource.PlayOneShot(correctChoiceClip);
            lastCorrectChoiceClip = correctChoiceClip;
        }
        else
        {
            while (correctChoiceClip == lastCorrectChoiceClip)
            {
                correctChoiceClip = RandomClip(correctChoices, lastCorrectChoiceClip);
            }
            audioSource.PlayOneShot(correctChoiceClip);
            lastCorrectChoiceClip = correctChoiceClip;
        }
        
        // Destroy current plant
        Destroy(plant);

        // Spawn new plant & set correct button
        while (plantIndex == lastPlantIndex)
        {
            plantIndex = Random.Range(0, 3);
        }
        lastPlantIndex = plantIndex;

        if (plantIndex != 0)
        {
            Destroy(badSoil);
        }
        plant = Instantiate(plants[plantIndex], new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        plant.transform.SetParent(UI_Canvas, true);
        correctButton = buttons[plantIndex];

        // Adds bad soil if needed
        if (plantIndex == 0 && !unhealthySoil.activeInHierarchy)
        {
            badSoil = Instantiate(unhealthySoil, new Vector3(soilSpawnX, soilSpawnY, soilSpawnZ), Quaternion.identity);
        }
    }

    // Takes an array of audio clips and returns a random one
    AudioClip RandomClip(AudioClip[] audioClipArray, AudioClip lastClip)
    {
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];

        while (newClip == lastClip)
        {
            newClip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        }
        return newClip;
    }
}