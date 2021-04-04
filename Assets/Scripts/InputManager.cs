using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager {
    [SerializeField] private LayerMask groundLayerMask;

    private Action<Vector3> OnPointerDownHandler;

    private void Update() {
        GetInput();
    }

    private void GetInput() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, groundLayerMask)) {
                Vector3 position = hit.point - transform.position;
                OnPointerDownHandler?.Invoke(position);
            }
        }
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener) {
        OnPointerDownHandler += listener;
    }

    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener) {
        OnPointerDownHandler -= listener;
    }
}
