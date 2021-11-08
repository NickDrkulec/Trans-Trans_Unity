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
        plant = Instantiate(plants[plantIndex], new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        plant.transform.SetParent(UI_Canvas, true);
        correctButton = buttons[plantIndex];
    }

    // Update is called once per frame
    void Update()
    {
        correctButton.onClick.AddListener(CorrectAnswer);
    }

    void CorrectAnswer()
    {
        // Play a random correct choice VO line
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            correctChoiceClip = RandomClip(correctChoices, lastCorrectChoiceClip);
            audioSource.PlayOneShot(correctChoiceClip);
            lastCorrectChoiceClip = correctChoiceClip;
        }
        else
        {
            correctChoiceClip = RandomClip(correctChoices, lastCorrectChoiceClip);
            audioSource.PlayOneShot(correctChoiceClip);
            lastCorrectChoiceClip = correctChoiceClip;
        }
        
        // Destroy current plant
        Destroy(plant);

        // Spawn new plant & set correct button
        plantIndex = Random.Range(0, 3);
        plant = Instantiate(plants[plantIndex], new Vector3(plantSpawnX, plantSpawnY, plantSpawnZ), Quaternion.identity);
        plant.transform.SetParent(UI_Canvas, true);
        correctButton = buttons[plantIndex];
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