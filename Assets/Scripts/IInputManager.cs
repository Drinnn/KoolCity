using System;
using UnityEngine;

public interface IInputManager {
    void AddListenerOnPointerDownEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerDownEvent(Action<Vector3> listener);
    void AddListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerSecondChangeEvent(Action<Vector3> listener);
    void AddListenerOnPointerSecondUpEvent(Action listener);
    void RemoveListenerOnPointerSecondUpEvent(Action listener);
    void AddListenerOnPointerUpEvent(Action listener);
    void RemoveListenerOnPointerUpEvent(Action listener);
    void AddListenerOnPointerChangeEvent(Action<Vector3> listener);
    void RemoveListenerOnPointerChangeEvent(Action<Vector3> listener);
}
