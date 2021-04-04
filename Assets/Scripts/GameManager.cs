using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public InputManager inputManager;
    [SerializeField] public PlacementManager placementManager;

    private GridStructure _grid;
    private int _cellSize = 3;

    private void Start() {
        _grid = new GridStructure(_cellSize);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position) {
        placementManager.PlaceBuilding(_grid.CalculateGridPosition(position));
    }

}
