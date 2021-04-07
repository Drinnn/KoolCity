using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StructureRepository : MonoBehaviour {
    [SerializeField] public CollectionSO modelDataCollection;

    public List<string> GetZoneNames() {
        return modelDataCollection.zonesList.Select(zone => zone.buildingName).ToList();
    }

    public List<string> GetSingleStructureNames() {
        return modelDataCollection.singleStructureList.Select(facility => facility.buildingName).ToList();
    }

    public string GetRoadStructureName() {
        return modelDataCollection.roadStructure.buildingName;
    }

    public GameObject GetBuildingPrefabByName(string structureName, StructureType structureType) {
        GameObject structurePrefab = null;
        switch (structureType) {
            case StructureType.Zone:
                structurePrefab = GetZoneBuildingPrefabByName(structureName);
                break;
            case StructureType.SingleStructure:
                structurePrefab = GetSingleStructureBuildingPrefabByName(structureName);
                break;
            case StructureType.Road:
                structurePrefab = GetRoadBuildingPrefabByName();
                break;
            default:
                throw new Exception("No prefab for that name " + structureName);
        }

        if (structurePrefab == null)
            throw new Exception("No such type. Not implemented for " + structureType);

        return structurePrefab;
    }

    private GameObject GetZoneBuildingPrefabByName(string structureName) {
        ZoneStructureSO structure = this.modelDataCollection.zonesList.Where(structure => structure.buildingName == structureName).FirstOrDefault();
        if (structure)
            return structure.prefab;

        return null;
    }

    private GameObject GetSingleStructureBuildingPrefabByName(string structureName) {
        SingleStructureBaseSO structure = this.modelDataCollection.singleStructureList.Where(structure => structure.buildingName == structureName).FirstOrDefault();
        if (structure)
            return structure.prefab;

        return null;
    }

    private GameObject GetRoadBuildingPrefabByName() {
        return this.modelDataCollection.roadStructure.prefab;
    }
}

public enum StructureType {
    Zone,
    SingleStructure,
    Road
}

