using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState {
    private BuildingManager _buildingManager;
    private string _structureName;

    public PlayerBuildingSingleStructureState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        this._buildingManager = buildingManager;
    }
    public override void OnInputPointerDown(Vector3 inputPosition) {
        this._buildingManager.PlaceStructureAt(inputPosition, this._structureName, StructureType.SingleStructure);
    }

    public override void OnCancel() {
        this._gameManager.TransitionToState(this._gameManager.selectionState, null);
    }

    public override void EnterState(string structureName) {
        this._structureName = structureName;
    }
}
