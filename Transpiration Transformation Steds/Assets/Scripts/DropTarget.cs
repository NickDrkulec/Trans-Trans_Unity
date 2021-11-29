using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropTarget : MonoBehaviour, IDropHandler
{
    public GameObject GameManager;
    
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (GameManager.GetComponent<GameManager>().plantIndex == 0 && eventData.pointerDrag == GameObject.Find("Soil_Drag"))
        {
            GameManager.GetComponent<GameManager>().CorrectAnswer();
        }

        else if (GameManager.GetComponent<GameManager>().plantIndex == 1 && eventData.pointerDrag == GameObject.Find("Water_Drag"))
        {
            GameManager.GetComponent<GameManager>().CorrectAnswer();
        }

        else if (GameManager.GetComponent<GameManager>().plantIndex == 2 && eventData.pointerDrag == GameObject.Find("Sun_Drag"))
        {
            GameManager.GetComponent<GameManager>().CorrectAnswer();
        }
    }

}
