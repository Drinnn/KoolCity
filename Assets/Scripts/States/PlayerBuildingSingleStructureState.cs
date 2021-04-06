using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState {
    private BuildingManager _buildingManager;

    public PlayerBuildingSingleStructureState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        this._buildingManager = buildingManager;
    }
    public override void OnInputPointerDown(Vector3 inputPosition) {
        this._buildingManager.PlaceStructureAt(inputPosition);
    }

    public override void OnInputPointerChange(Vector3 position) {
        return;
    }

    public override void OnInputPointerUp() {
        return;
    }

    public override void OnInputPanChange(Vector3 panPosition) {
        return;
    }

    public override void OnInputPanUp() {
        return;
    }

    public override void OnCancel() {
        this._gameManager.TransitionToState(this._gameManager.selectionState, null);
    }

    public override void EnterState(string structureName) {
        base.EnterState(structureName);
    }
}
