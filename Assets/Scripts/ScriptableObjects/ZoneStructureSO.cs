using UnityEngine;

[CreateAssetMenu(fileName = "New Zone Structure", menuName = "Structure Data/Zone Structure")]
public class ZoneStructureSO : StructureBaseSO {
    public bool upgradable;
    public GameObject[] prefabVariants;
    public UpgradeType[] availableUpgrades;
    public ZoneType zoneType;
}

[System.Serializable]
public struct UpgradeType {
    public GameObject[] prefabVariants;
    public float happinessTreshold;
    public float newIncome;
    public float newUnkeep;
}

public enum ZoneType {
    Residential,
    Agricultural,
    Commercial
}
