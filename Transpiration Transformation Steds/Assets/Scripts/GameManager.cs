using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] plants;
    GameObject plant;
    public int plantIndex;
    int lastPlantIndex;
    public float plantSpawnX, plantSpawnY, plantSpawnZ;

    public GameObject unhealthySoil;
    GameObject badSoil;
    public float soilSpawnX, soilSpawnY, soilSpawnZ;

    public UnityEngine.UI.Button[] resources;
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
        SpawnNewPlant();
    }

    // Update is called once per frame
    void Update()
    {
        //resources[plantIndex].onClick.AddListener(CorrectAnswer);
        CheckChoice();
    }

    public void CorrectAnswer()
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

        SpawnNewPlant();
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

    void SpawnNewPlant()
    {
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
        //correctButton = resources[plantIndex];

        // Adds bad soil if needed
        if (plantIndex == 0 && !unhealthySoil.activeInHierarchy)
        {
            badSoil = Instantiate(unhealthySoil, new Vector3(soilSpawnX, soilSpawnY, soilSpawnZ), Quaternion.identity);
        }
    }

    void CheckChoice()
    {
        // if plant index equals resource colliding with plant's index
    }
        
}