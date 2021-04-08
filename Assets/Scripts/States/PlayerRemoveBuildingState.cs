using UnityEngine;

public class PlayerRemoveBuildingState : PlayerState {
    private BuildingManager _buildingManager;

    public PlayerRemoveBuildingState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        _buildingManager = buildingManager;
    }

    public override void OnInputPointerDown(Vector3 inputPosition) {
        this._buildingManager.RemoveBuildingAt(inputPosition);
    }

    public override void OnCancel() {
        this._gameManager.TransitionToState(this._gameManager.selectionState, null);
    }
}
