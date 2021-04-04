using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public InputManager inputManager;
    [SerializeField] public PlacementManager placementManager;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;


    private GridStructure _grid;
    private int _cellSize = 3;

    private void Start() {
        _grid = new GridStructure(gridWidth, gridLength, _cellSize);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position) {
        Vector3 gridPosition = _grid.CalculateGridPosition(position);
        if (!_grid.IsCellTaken(gridPosition)) {
            placementManager.PlaceBuilding(gridPosition);
        }
    }

}
