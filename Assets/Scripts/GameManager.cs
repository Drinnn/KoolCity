using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] public IInputManager inputManager;
    [SerializeField] public PlacementManager placementManager;
    [SerializeField] public StructureRepository structureRepository;
    [SerializeField] public UIController uIController;
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridLength;
    [SerializeField] private LayerMask inputMask;

    private int _cellSize = 3;

    private BuildingManager _buildingManager;

    private PlayerState state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;
    public PlayerBuildingZoneState buildingAreaState;
    public PlayerBuildingRoadState buildingRoadState;
    public PlayerRemoveBuildingState removeBuildingState;

    public PlayerState State { get => state; }

    private void Awake() {
        PrepareStates();

#if (UNITY_EDITOR && TEST) || !(UNITY_IOS || UNITY_ANDROID)
        inputManager = gameObject.AddComponent<InputManager>();
#endif
    }

    private void Start() {
        PrepareGameComponents();
        AssignInputListeners();
        AssignUIControllerListeners();
    }

    private void PrepareStates() {
        _buildingManager = new BuildingManager(placementManager, structureRepository, gridWidth, gridLength, _cellSize);
        selectionState = new PlayerSelectionState(this);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, _buildingManager);
        buildingAreaState = new PlayerBuildingZoneState(this, _buildingManager);
        buildingRoadState = new PlayerBuildingRoadState(this, _buildingManager);
        removeBuildingState = new PlayerRemoveBuildingState(this, _buildingManager);

        state = selectionState;
    }

    private void PrepareGameComponents() {
        inputManager.MouseInputMask = inputMask;
        cameraMovement.SetCameraBounds(0, gridWidth, 0, gridLength);
    }

    private void AssignInputListeners() {
        inputManager.AddListenerOnPointerDownEvent((position) => state.OnInputPointerDown(position));
        inputManager.AddListenerOnPointerSecondChangeEvent((position) => state.OnInputPanChange(position));
        inputManager.AddListenerOnPointerSecondUpEvent(() => state.OnInputPanUp());
        inputManager.AddListenerOnPointerChangeEvent((position) => state.OnInputPointerChange(position));
    }

    private void AssignUIControllerListeners() {
        uIController.AddListenerOnBuildAreaEvent((structureName) => state.OnBuildArea(structureName));
        uIController.AddListenerOnBuildSingleStructureEvent((structureName) => state.OnBuildSingleStructure(structureName));
        uIController.AddListenerOnBuildRoadEvent((structureName) => state.OnBuildRoad(structureName));
        uIController.AddListenerOnConfirmEvent(() => state.OnConfirm());
        uIController.AddListenerOnCancelEvent(() => state.OnCancel());
        uIController.AddListenerOnDemolishActionEvent(() => state.OnDemolishAction());
    }

    public void TransitionToState(PlayerState newState, string structureName) {
        this.state = newState;
        this.state.EnterState(structureName);
    }

}
