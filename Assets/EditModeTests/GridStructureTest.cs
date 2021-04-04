using System;
using NUnit.Framework;
using UnityEngine;

public class GridStructureTest {
    GridStructure _gridStructure;

    [OneTimeSetUp]
    public void Init() {
        _gridStructure = new GridStructure(100, 100, 3);
    }

    #region GridPositionTests
    [Test]
    public void CalculateGridPositionPasses() {
        Vector3 mockInputPosition = new Vector3(0, 0, 0);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);

        Assert.AreEqual(Vector3.zero, gridPosition);
    }

    [Test]
    public void CalculateGridPositionFloatPasses() {
        Vector3 mockInputPosition = new Vector3(2.9f, 1.5f, 0f);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);

        Assert.AreEqual(Vector3.zero, gridPosition);
    }

    [Test]
    public void CalculateGridPositionFails() {
        Vector3 mockInputPosition = new Vector3(3.1f, 0, 0);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);

        Assert.AreNotEqual(Vector3.zero, gridPosition);
    }
    #endregion

    #region GridIndexTests
    [Test]
    public void PlaceStructure303AndCheckIsTakenPasses() {
        Vector3 mockInputPosition = new Vector3(3, 0, 3);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);
        GameObject testGameObject = new GameObject("TestGameObject");
        _gridStructure.PlaceStructureOnGrid(testGameObject, gridPosition);

        Assert.IsTrue(_gridStructure.IsCellTaken(gridPosition));
    }

    [Test]
    public void PlaceStructureMinAndCheckIsTakenPasses() {
        Vector3 mockInputPosition = new Vector3(0, 0, 0);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);
        GameObject testGameObject = new GameObject("TestGameObject");
        _gridStructure.PlaceStructureOnGrid(testGameObject, gridPosition);

        Assert.IsTrue(_gridStructure.IsCellTaken(gridPosition));
    }

    [Test]
    public void PlaceStructureMaxAndCheckIsTakenPasses() {
        Vector3 mockInputPosition = new Vector3(297, 0, 297);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);
        GameObject testGameObject = new GameObject("TestGameObject");
        _gridStructure.PlaceStructureOnGrid(testGameObject, gridPosition);

        Assert.IsTrue(_gridStructure.IsCellTaken(gridPosition));
    }

    [Test]
    public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail() {
        Vector3 mockInputPosition = new Vector3(3, 0, 3);

        Vector3 gridPosition = _gridStructure.CalculateGridPosition(mockInputPosition);
        GameObject testGameObject = null;
        _gridStructure.PlaceStructureOnGrid(testGameObject, gridPosition);

        Assert.IsFalse(_gridStructure.IsCellTaken(gridPosition));
    }

    [Test]
    public void PlaceStructure303AndCheckIsTakenIndexOutOfBoundsFail() {
        Vector3 mockInputPosition = new Vector3(303, 0, 303);

        Assert.Throws<IndexOutOfRangeException>(() => _gridStructure.IsCellTaken(mockInputPosition));
    }
    #endregion
}