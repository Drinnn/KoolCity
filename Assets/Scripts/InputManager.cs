using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager {
    private Action<Vector3> OnPointerDownHandler;
    private Action OnPointerUpHandler;
    private Action<Vector3> OnPointerSecondChangeHandler;
    private Action<Vector3> OnPointerChangeHandler;
    private Action OnPointerSecondUpHandler;

    [SerializeField] private LayerMask groundLayerMask;

    private void Update() {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            CallActionOnPointer((position) => OnPointerDownHandler?.Invoke(position));
        }
        if (Input.GetMouseButton(0)) {
            CallActionOnPointer((position) => OnPointerChangeHandler?.Invoke(position));
        }
        if (Input.GetMouseButtonUp(0)) {
            OnPointerUpHandler?.Invoke();
        }
    }

    private void CallActionOnPointer(Action<Vector3> action) {
        Vector3? position = GetMousePosition();
        if (position.HasValue) {
            action(position.Value);
            position = null;
        }
    }

    private Vector3? GetMousePosition() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3? position = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, groundLayerMask)) {
            position = hit.point - transform.position;
        }

        return position;
    }

    private void GetPanningPointer() {
        if (Input.GetMouseButton(1)) {
            Vector3 position = Input.mousePosition;
            OnPointerSecondChangeHandler?.Invoke(position);
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

    public void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener) {
        OnPointerSecondChangeHandler += listener;
    }

    public void RemoveListenerOnPointerSecondChangeEvent(Action<Vector3> listener) {
        OnPointerSecondChangeHandler -= listener;
    }

    public void AddListenerOnPointerSecondUpEvent(Action listener) {
        OnPointerSecondUpHandler += listener;
    }

    public void RemoveListenerOnPointerSecondUpEvent(Action listener) {
        OnPointerSecondUpHandler -= listener;
    }

    public void AddListenerOnPointerUpEvent(Action listener) {
        OnPointerUpHandler += listener;
    }

    public void RemoveListenerOnPointerUpEvent(Action listener) {
        OnPointerUpHandler -= listener;
    }


    public void AddListenerOnPointerChangeEvent(Action<Vector3> listener) {
        OnPointerChangeHandler += listener;
    }

    public void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener) {
        OnPointerChangeHandler -= listener;
    }
}
