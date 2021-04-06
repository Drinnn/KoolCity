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

    public override void OnBuildArea(string structureName) {
        this._gameManager.TransitionToState(this._gameManager.buildingAreaState, structureName);
    }

    public override void OnBuildSingleStructure(string structureName) {
        this._gameManager.TransitionToState(this._gameManager.buildingSingleStructureState, structureName);
    }

    public override void OnBuildRoad(string structureName) {
        this._gameManager.TransitionToState(this._gameManager.buildingRoadState, structureName);
    }

    public override void OnDemolishAction() {
        this._gameManager.TransitionToState(this._gameManager.removeBuildingState, null);
    }

}
