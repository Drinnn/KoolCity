using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;

public class StructureRepositoryTest {
    StructureRepository _repository;

    [OneTimeSetUp]
    public void Init() {
        CollectionSO collection = new CollectionSO();

        RoadStructureSO road = new RoadStructureSO();
        road.buildingName = "Road";

        SingleFacilitySO facility = new SingleFacilitySO();
        facility.buildingName = "Power Plant";

        ZoneStructureSO zone = new ZoneStructureSO();
        zone.buildingName = "Commercial";

        collection.roadStructure = road;
        collection.singleStructureList = new List<SingleStructureBaseSO>();
        collection.singleStructureList.Add(facility);
        collection.zonesList = new List<ZoneStructureSO>();
        collection.zonesList.Add(zone);

        GameObject testObject = new GameObject();

        _repository = testObject.AddComponent<StructureRepository>();
        _repository.modelDataCollection = collection;
    }

    [UnityTest]
    public IEnumerator StructureRepositoryTestZoneListQuantityPasses() {
        int quantity = _repository.GetZoneNames().Count();
        yield return new WaitForEndOfFrame();
        Assert.AreEqual(1, quantity);
    }

    [UnityTest]
    public IEnumerator StructureRepositoryTestZoneListNamePasses() {
        string name = _repository.GetZoneNames()[0];
        yield return new WaitForEndOfFrame();
        Assert.AreEqual("Commercial", name);
    }

    [UnityTest]
    public IEnumerator StructureRepositoryTestSingleStructureListQuantityPasses() {
        int quantity = _repository.GetSingleStructureNames().Count;
        yield return new WaitForEndOfFrame();
        Assert.AreEqual(1, quantity);
    }
    [UnityTest]
    public IEnumerator StructureRepositoryTestSingleStructureListNamePasses() {
        string name = _repository.GetSingleStructureNames()[0];
        yield return new WaitForEndOfFrame();
        Assert.AreEqual("Power Plant", name);
    }

    [UnityTest]
    public IEnumerator StructureRepositoryTestRoadListNamePasses() {
        string name = _repository.GetRoadStructureName();
        yield return new WaitForEndOfFrame();
        Assert.AreEqual("Road", name);
    }
}
