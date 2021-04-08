using UnityEngine;

public class PlayerBuildingZoneState : PlayerState {
    private BuildingManager _buildingManager;
    private string _structureName;

    public PlayerBuildingZoneState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        this._buildingManager = buildingManager;
    }

    public override void OnInputPointerDown(Vector3 inputPosition) {
        this._buildingManager.PlaceStructureAt(inputPosition, this._structureName, StructureType.Zone);
    }

    public override void OnBuildSingleStructure(string structureName) {
        this._buildingManager.CancelPlacement();
        base.OnBuildSingleStructure(structureName);
    }

    public override void OnBuildRoad(string structureName) {
        this._buildingManager.CancelPlacement();
        base.OnBuildRoad(structureName);
    }

    public override void OnConfirm() {
        this._buildingManager.ConfirmPlacement();
    }

    public override void OnCancel() {
        this._buildingManager.CancelPlacement();
        this._gameManager.TransitionToState(this._gameManager.selectionState, null);
    }

    public override void EnterState(string structureName) {
        this._structureName = structureName;
    }
}
