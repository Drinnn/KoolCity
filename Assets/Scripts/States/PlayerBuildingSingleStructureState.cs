using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState {
    private PlacementManager _placementManager;
    private GridStructure _grid;

    public PlayerBuildingSingleStructureState(GameManager gameManager, PlacementManager placementManager, GridStructure grid) : base(gameManager) {
        this._placementManager = placementManager;
        this._grid = grid;
    }
    public override void OnInputPointerDown(Vector3 position) {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (!_grid.IsCellTaken(gridPosition)) {
            _placementManager.PlaceBuilding(gridPosition, _grid);
        }
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
        this._gameManager.TransitionToState(this._gameManager.selectionState);
    }
}
