using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public InputManager inputManager;
    [SerializeField] public PlacementManager placementManager;

    private GridStructure _grid;
    private int _cellSize = 3;

    private void Start() {
        _grid = new GridStructure(_cellSize);
    }

}
