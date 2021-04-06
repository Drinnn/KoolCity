using UnityEngine;

public class PlayerRemoveBuildingState : PlayerState {
    private BuildingManager _buildingManager;

    public PlayerRemoveBuildingState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        _buildingManager = buildingManager;
    }

    public override void OnInputPointerDown(Vector3 inputPosition) {
        this._buildingManager.RemoveBuildingAt(inputPosition);
    }

    public override void OnInputPointerChange(Vector3 position) {
        return;
    }

    public override void OnInputPointerUp() {
        return;
    }

    public override void OnInputPanChange(Vector3 position) {
        return;
    }

    public override void OnInputPanUp() {
        return;
    }

    public override void OnCancel() {
        this._gameManager.TransitionToState(this._gameManager.selectionState, null);
    }
}
