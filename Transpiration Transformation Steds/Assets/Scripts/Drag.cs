using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Objects with a Sprite Renderer component needs a Physics 2D Raycaster on the Camera.
// To make this work with Drop.cs, go in the Physics 2D Raycaster and under Event Mask, turn off the layer Ignore Raycast
namespace Monstralia.InputSystem {
    public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
        
        [SerializeField] private bool snapsToCursor;
        [SerializeField] private bool animate;
        private Vector3 pointerOffset = new Vector3 (0f,0f,0f);
        private int LTID;
        private Vector3 initialScale;
        
        private SpriteRenderer spriteRenderer;
        private Image imageRenderer;
        private LayerMask currentLayer;
        
        private void Awake() {
            initialScale = transform.localScale;
        }

        private void Start() {
            spriteRenderer = GetComponent<SpriteRenderer>();
            imageRenderer = GetComponent<Image>();
        }

        public void OnPointerDown(PointerEventData eventData) {
            if (animate) {
                LeanTween.cancel(LTID);
                LTID = LeanTween.scale(gameObject, initialScale * 0.8f, 0.25f).setEaseOutCirc().id;
            }
            if (!snapsToCursor) {
                pointerOffset = GetPointerWorldPosition(eventData) - transform.position;
            }
            transform.position = GetPointerWorldPosition(eventData) - pointerOffset;

            if (imageRenderer) {
                imageRenderer.raycastTarget = false;
            }
            if (spriteRenderer) {
                currentLayer = gameObject.layer;
                gameObject.layer = 2;
            }

        }

        public void OnPointerUp(PointerEventData eventData) {
            if (animate) {
                LeanTween.cancel(LTID);
                LTID = LeanTween.scale(gameObject, initialScale, 0.25f).setEaseOutCirc().id;
            }

            if (imageRenderer) {
                imageRenderer.raycastTarget = true;
            }
            if (spriteRenderer) {
                gameObject.layer = currentLayer;
            }
        }

        public void OnDrag (PointerEventData eventData) {
            transform.position = GetPointerWorldPosition(eventData) - pointerOffset;
        }

        private Vector3 GetPointerWorldPosition (PointerEventData eventData) {
            return Camera.main.ScreenToWorldPoint(
                    new Vector3(eventData.position.x, 
                    eventData.position.y, 
                    Camera.main.nearClipPlane + 10));
        }
    }
}
