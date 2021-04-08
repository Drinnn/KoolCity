using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class StructureRepostiroy {
    private StructureRepository _structureRepo;
    private GameObject _testRoad;
    private GameObject _testSingleStructure;
    private GameObject _testZone;

    [OneTimeSetUp]
    public void Init() {
        _structureRepo = Substitute.For<StructureRepository>();
        CollectionSO collection = new CollectionSO();
        _testRoad = new GameObject();
        _testSingleStructure = new GameObject();
        _testZone = new GameObject();
        RoadStructureSO road = new RoadStructureSO();
        road.buildingName = "Road";
        road.prefab = _testRoad;
        SingleFacilitySO facility = new SingleFacilitySO();
        facility.buildingName = "Power Plant";
        facility.prefab = _testSingleStructure;
        ZoneStructureSO zone = new ZoneStructureSO();
        zone.buildingName = "Commercial";
        zone.prefab = _testZone;
        collection.roadStructure = road;
        collection.singleStructureList = new List<SingleStructureBaseSO>();
        collection.singleStructureList.Add(facility);
        collection.zonesList = new List<ZoneStructureSO>();
        collection.zonesList.Add(zone);
        _structureRepo.modelDataCollection = collection;
    }
    [Test]

    public void StructureRepositoryEditModeGetRoadPrefabPasses() {
        GameObject returnObject = _structureRepo.GetBuildingPrefabByName("Road", StructureType.Road);
        Assert.AreEqual(_testRoad, returnObject);
    }

    [Test]
    public void StructureRepositoryEditModeGetSingleStructurePrefabPasses() {
        GameObject returnObject = _structureRepo.GetBuildingPrefabByName("PowerPlant", StructureType.SingleStructure);
        Assert.AreEqual(_testSingleStructure, returnObject);
    }

    [Test]
    public void StructureRepositoryEditModeGetSingleStructurePrefabNullPasses() {
        Assert.That(() => _structureRepo.GetBuildingPrefabByName("PowerPlant2", StructureType.SingleStructure),
            Throws.Exception);
    }

    [Test]
    public void StructureRepositoryEditModeGetZonePrefabPasses() {
        GameObject returnObject = _structureRepo.GetBuildingPrefabByName("Commercial", StructureType.Zone);
        Assert.AreEqual(_testZone, returnObject);
    }

    [Test]
    public void StructureRepositoryEditModeGetZonePrefabNullPasses() {
        Assert.That(() => _structureRepo.GetBuildingPrefabByName("Commercial2", StructureType.Zone),
            Throws.Exception);
    }
}