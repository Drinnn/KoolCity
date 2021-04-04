using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] private float speed = 0.05f;

    private Vector3? _basePointerPosition = null;
    private int _cameraXMin, _cameraXMax, _cameraZMin, _cameraZMax;

    public void MoveCamera(Vector3 pointerPosition) {
        if (_basePointerPosition.HasValue == false) {
            _basePointerPosition = pointerPosition;
        }

        Vector3 newPosition = pointerPosition - _basePointerPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);

        transform.Translate(newPosition * speed);
        LimitPositionInsideBounds();
    }

    private void LimitPositionInsideBounds() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _cameraXMin, _cameraXMax), 0, Mathf.Clamp(transform.position.z, _cameraZMin, _cameraZMax));
    }

    public void StopCameraMovement() {
        _basePointerPosition = null;
    }

    public void SetCameraBounds(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax) {
        this._cameraXMin = cameraXMin;
        this._cameraXMax = cameraXMax;
        this._cameraZMin = cameraZMin;
        this._cameraZMax = cameraZMax;
    }
}
