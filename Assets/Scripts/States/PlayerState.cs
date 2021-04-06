using UnityEngine;

public abstract class PlayerState {
    protected GameManager _gameManager;

    public PlayerState(GameManager gameManager) {
        this._gameManager = gameManager;
    }

    public virtual void OnInputPointerDown(Vector3 position) {

    }
    public virtual void OnInputPointerChange(Vector3 position) {

    }
    public virtual void OnInputPointerUp() {

    }
    public virtual void OnInputPanChange(Vector3 position) {

    }
    public virtual void OnInputPanUp() {

    }
    public virtual void OnCancel() {

    }

    public virtual void OnBuildArea(string structureName) {
        this._gameManager.TransitionToState(this._gameManager.buildingAreaState, structureName);
    }

    public virtual void OnBuildSingleStructure(string structureName) {
        this._gameManager.TransitionToState(this._gameManager.buildingSingleStructureState, structureName);
    }

    public virtual void OnBuildRoad(string structureName) {
        this._gameManager.TransitionToState(this._gameManager.buildingRoadState, structureName);
    }

    public virtual void OnDemolishAction() {
        this._gameManager.TransitionToState(this._gameManager.removeBuildingState, null);
    }

    public virtual void EnterState(string structureName) {

    }
}

