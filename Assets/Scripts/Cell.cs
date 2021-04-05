using UnityEngine;

public class Cell {
    private bool _isTaken = false;
    private GameObject _structureModel = null;

    public bool IsTaken { get => _isTaken; }

    public void SetConstruction(GameObject structureModel) {
        if (structureModel != null) {
            this._structureModel = structureModel;
            this._isTaken = true;
        }
    }

    public GameObject GetStructure() {
        return this._structureModel;
    }

    public void RemoveStructure() {
        this._structureModel = null;
        this._isTaken = false;
    }
}
