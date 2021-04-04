using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager {
    private Action<Vector3> OnPointerDownHandler;
    private Action<Vector3> OnPointerSecondDownHandler;
    private Action OnPointerSecondUpHandler;

    [SerializeField] private LayerMask groundLayerMask;

    private void Update() {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, groundLayerMask)) {
                Vector3 position = hit.point - transform.position;
                OnPointerDownHandler?.Invoke(position);
            }
        }
    }

    private void GetPanningPointer() {
        if (Input.GetMouseButton(1)) {
            Vector3 position = Input.mousePosition;
            OnPointerSecondDownHandler?.Invoke(position);
        }
        if (Input.GetMouseButtonUp(1)) {
            OnPointerSecondUpHandler?.Invoke();
        }
    }

    public void AddListenerOnPointerDownEvent(Action<Vector3> listener) {
        OnPointerDownHandler += listener;
    }

    public void RemoveListenerOnPointerDownEvent(Action<Vector3> listener) {
        OnPointerDownHandler -= listener;
    }

    public void AddListenerOnPointerSecondDownEvent(Action<Vector3> listener) {
        OnPointerSecondDownHandler += listener;
    }

    public void RemoveListenerOnPointerSecondDownEvent(Action<Vector3> listener) {
        OnPointerSecondDownHandler -= listener;
    }

    public void AddListenerOnPointerSecondUpEvent(Action listener) {
        OnPointerSecondUpHandler += listener;
    }

    public void RemoveListenerOnPointerSecondUpEvent(Action listener) {
        OnPointerSecondUpHandler -= listener;
    }
}
