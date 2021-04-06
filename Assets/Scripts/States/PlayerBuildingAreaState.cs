public class PlayerBuildingAreaState : PlayerState {
    private BuildingManager _buildingManager;

    public PlayerBuildingAreaState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager) {
        this._buildingManager = buildingManager;
    }

    public override void OnCancel() {
        base.OnCancel();
    }
}
