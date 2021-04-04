using UnityEngine;

public class Cell {
    private bool _isTaken = false;
    private GameObject _structureModel = null;

    public bool IsTaken { get => _isTaken; }

    public void SetConstruction(GameObject structureModel) {
        this._structureModel = structureModel;
        this._isTaken = true;
    }

}
