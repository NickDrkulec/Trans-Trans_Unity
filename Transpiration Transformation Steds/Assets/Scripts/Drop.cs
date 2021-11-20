using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Monstralia.InputSystem {
    public class Drop : MonoBehaviour, IDropHandler {

        [SerializeField] protected GameObject[] acceptedGameObjects;

        public UnityEvent OnDragDropCheck = new UnityEvent();
        public UnityEvent OnDragDropAccept = new UnityEvent();

        public void OnDrop(PointerEventData eventData) {
            if (eventData.pointerDrag != null) {
                Debug.Log ("Dropped object was: "  + eventData.pointerDrag);
                if (OnDragDropCheck != null) {
                    OnDragDropCheck.Invoke();
                }

                foreach (GameObject objType in acceptedGameObjects) {
                    print (objType.GetType());
                    print (objType.name);
                    if (eventData.pointerDrag == objType) {
                        Debug.Log ("ACCEPTED OBJECT was: "  + eventData.pointerDrag);
                        if (OnDragDropAccept != null) {
                            OnDragDropAccept.Invoke();
                        }
                        Score scoreComp = eventData.pointerDrag.GetComponent<Score>();
                        if (scoreComp) {
                            scoreComp.OnScore();
                        }
                        break;
                    }
                }
            }
        }
    }
}
