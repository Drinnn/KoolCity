using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingRoadState : PlayerState {
    private BuildingManager _buildingManager;

    public PlayerBuildingRoadState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        this._buildingManager = buildingManager;
    }

    public override void OnCancel() {
        base.OnCancel();
    }
}
