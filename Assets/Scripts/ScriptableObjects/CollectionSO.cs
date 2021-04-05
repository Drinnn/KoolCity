using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Collection", menuName = "Collection")]
public class CollectionSO : ScriptableObject {
    public RoadStructureSO roadStructure;
    public List<SingleStructureBaseSO> singleStructureList;
    public List<ZoneStructureSO> zonesList;
}
