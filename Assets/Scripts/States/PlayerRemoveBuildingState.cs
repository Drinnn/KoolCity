using UnityEngine;

public class PlayerRemoveBuildingState : PlayerState {
    private BuildingManager _buildingManager;

    public PlayerRemoveBuildingState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        _buildingManager = buildingManager;
    }

    public override void OnInputPointerDown(Vector3 inputPosition) {
        this._buildingManager.PrepareStructureForRemovalAt(inputPosition);
    }

    public override void OnBuildSingleStructure(string structureName) {
        this._buildingManager.CancelRemoval();
        base.OnBuildSingleStructure(structureName);
    }

    public override void OnBuildArea(string structureName) {
        this._buildingManager.CancelRemoval();
        base.OnBuildArea(structureName);
    }

    public override void OnBuildRoad(string structureName) {
        this._buildingManager.CancelRemoval();
        base.OnBuildRoad(structureName);
    }

    public override void OnConfirm() {
        this._buildingManager.ConfirmRemoval();
    }

    public override void OnCancel() {
        this._buildingManager.CancelRemoval();
        this._gameManager.TransitionToState(this._gameManager.selectionState, null);
    }
}
