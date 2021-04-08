using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour {
    [SerializeField] private Transform ground;
    [SerializeField] private Material transparentMaterial;
    [SerializeField] private Dictionary<GameObject, Material[]> originalMaterials = new Dictionary<GameObject, Material[]>();

    public GameObject CreateGhostStructure(Vector3 gridPosition, GameObject buildingPrefab) {
        GameObject newStructure = Instantiate(buildingPrefab, ground.position + gridPosition, Quaternion.identity);
        Color colorToSet = Color.green;
        ModifyStructurePrefabLook(newStructure, colorToSet);

        return newStructure;
    }

    private void ModifyStructurePrefabLook(GameObject newStructure, Color colorToSet) {
        foreach (Transform child in newStructure.transform) {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();
            if (!originalMaterials.ContainsKey(child.gameObject)) {
                originalMaterials.Add(child.gameObject, renderer.materials);
            }

            Material[] materialsToSet = new Material[renderer.materials.Length];
            for (int i = 0; i < materialsToSet.Length; i++) {
                materialsToSet[i] = transparentMaterial;
                materialsToSet[i].color = colorToSet;
            }

            renderer.materials = materialsToSet;
        }
    }

    public void PlaceStructuresOnMap(IEnumerable<GameObject> structureCollection) {
        foreach (GameObject structure in structureCollection) {
            foreach (Transform child in structure.transform) {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                if (originalMaterials.ContainsKey(child.gameObject)) {
                    renderer.materials = originalMaterials[child.gameObject];
                }
            }
        }
        originalMaterials.Clear();
    }

    public void DestroyStructures(IEnumerable<GameObject> structureCollection) {
        foreach (GameObject structure in structureCollection) {
            Destroy(structure);
        }
        originalMaterials.Clear();
    }

    public void SetBuildingForRemoval(GameObject buildingToRemove) {
        Color colorToSet = Color.red;
        ModifyStructurePrefabLook(buildingToRemove, colorToSet);
    }
}
