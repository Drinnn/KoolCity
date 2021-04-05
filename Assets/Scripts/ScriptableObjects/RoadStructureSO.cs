using UnityEngine;

[CreateAssetMenu(fileName = "New Road Structure", menuName = "Structure Data/Road Structure")]
public class RoadStructureSO : StructureBaseSO {
    [Tooltip("Road facing up and right")]
    public GameObject cornerPrefab;
    [Tooltip("Road facing up, right and down")]
    public GameObject threeWayPrefab;
    public GameObject fourWayPrefab;
}
