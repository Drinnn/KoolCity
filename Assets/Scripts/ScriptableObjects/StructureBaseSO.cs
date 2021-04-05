using UnityEngine;

public abstract class StructureBaseSO : ScriptableObject {
    public string buildingName;
    public GameObject prefab;
    public float placementCost;
    public float upkeepCost;
    public float income;
    public bool requireRoadAccess;
    public bool requireWater;
    public bool requirePower;
}
