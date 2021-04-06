using UnityEngine;

public class PlayerSelectionState : PlayerState {
    private CameraMovement _cameraMovement;

    public PlayerSelectionState(GameManager gameManager, CameraMovement cameraMovement) : base(gameManager) {
        _cameraMovement = cameraMovement;
    }

    public override void OnInputPointerDown(Vector3 position) {
        return;
    }

    public override void OnInputPointerChange(Vector3 position) {
        return;
    }

    public override void OnInputPointerUp() {
        return;
    }

    public override void OnInputPanChange(Vector3 panPosition) {
        this._cameraMovement.MoveCamera(panPosition);
    }

    public override void OnInputPanUp() {
        this._cameraMovement.StopCameraMovement();
    }

    public override void OnCancel() {
        return;
    }
}
