using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

[TestFixture]
public class BuildingManagerTest {
    private BuildingManager _buildingManager;
    private Material _materialTransparent;

    [SetUp]
    public void InitBeforeEveryTest() {
        PlacementManager placementManager = Substitute.For<PlacementManager>();

        _materialTransparent = new Material(Shader.Find("Standard"));
        placementManager.transparentMaterial = _materialTransparent;

        GameObject ground = new GameObject();
        ground.transform.position = Vector3.zero;
        placementManager.ground = ground.transform;

        StructureRepository structureRepository = Substitute.For<StructureRepository>();
        CollectionSO collection = new CollectionSO();

        RoadStructureSO road = new RoadStructureSO();
        road.buildingName = "Road";
        GameObject roadChild = new GameObject("Road", typeof(MeshRenderer));
        roadChild.GetComponent<MeshRenderer>().material.color = Color.blue;
        GameObject roadPrefab = new GameObject("Road");
        roadChild.transform.SetParent(roadPrefab.transform);
        road.prefab = roadPrefab;
        collection.roadStructure = road;

        structureRepository.modelDataCollection = collection;

        _buildingManager = new BuildingManager(placementManager, structureRepository, 10, 10, 3);
    }

    [UnityTest]
    public IEnumerator DemolishConfirmationTest() {
        Vector3 inputPosition = PreparePlacement();
        PrepareDemolishion(inputPosition);

        _buildingManager.ConfirmRemoval();

        yield return new WaitForEndOfFrame();

        Assert.IsNull(_buildingManager.CheckForStructureInGrid(inputPosition));
    }

    [UnityTest]
    public IEnumerator DemolishNoConfirmationTest() {
        Vector3 inputPosition = PreparePlacement();
        PrepareDemolishion(inputPosition);

        yield return new WaitForEndOfFrame();

        Assert.IsNotNull(_buildingManager.CheckForStructureInGrid(inputPosition));
    }

    [UnityTest]
    public IEnumerator DemolishCancelTest() {
        Vector3 inputPosition = PreparePlacement();
        PrepareDemolishion(inputPosition);

        _buildingManager.CancelRemoval();

        yield return new WaitForEndOfFrame();

        Assert.IsNotNull(_buildingManager.CheckForStructureInGrid(inputPosition));
    }

    [UnityTest]
    public IEnumerator PlacementConfirmationPassTests() {
        Vector3 inputPosition = PreparePlacement();
        _buildingManager.ConfirmPlacement();

        yield return new WaitForEndOfFrame();

        Assert.IsNotNull(_buildingManager.CheckForStructureInGrid(inputPosition));
    }

    [UnityTest]
    public IEnumerator PlacementNoConfirmationTests() {
        Vector3 inputPosition = PreparePlacement();

        yield return new WaitForEndOfFrame();

        Assert.IsNull(_buildingManager.CheckForStructureInGrid(inputPosition));
    }

    [UnityTest]
    public IEnumerator ChangePlacementPrepareTests() {
        Vector3 inputPosition = PreparePlacement();
        Material material = AccessMaterial(() => _buildingManager.CheckForStructureInDictionary(inputPosition));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(material.color, Color.green);
    }

    [UnityTest]
    public IEnumerator ChangePlacementConfirmTests() {
        Vector3 inputPosition = PreparePlacement();

        _buildingManager.ConfirmPlacement();

        Material material = AccessMaterial(() => _buildingManager.CheckForStructureInGrid(inputPosition));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(material.color, Color.blue);
    }

    [UnityTest]
    public IEnumerator ChangeDemolishionPrepareTests() {
        Vector3 inputPosition = PreparePlacement();

        PrepareDemolishion(inputPosition);

        Material material = AccessMaterial(() => _buildingManager.CheckForStructureInDictionary(inputPosition));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(material.color, Color.red);
    }

    [UnityTest]
    public IEnumerator ChangeDemolishionCancelTests() {
        Vector3 inputPosition = PreparePlacement();

        PrepareDemolishion(inputPosition);

        _buildingManager.CancelRemoval();

        Material material = AccessMaterial(() => _buildingManager.CheckForStructureInGrid(inputPosition));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(material.color, Color.blue);
    }

    private Material AccessMaterial(Func<GameObject> accessMethod) {
        var roadObject = accessMethod();
        Material material = roadObject.GetComponentInChildren<MeshRenderer>().material;

        return material;
    }

    private Vector3 PreparePlacement() {
        Vector3 inputPosition = new Vector3(1, 0, 1);
        string structureName = "Road";

        _buildingManager.PrepareStructureForPlacement(inputPosition, structureName, StructureType.Road);
        return inputPosition;
    }

    private void PrepareDemolishion(Vector3 inputPosition) {
        _buildingManager.ConfirmPlacement();
        _buildingManager.PrepareStructureForRemovalAt(inputPosition);
    }


}
