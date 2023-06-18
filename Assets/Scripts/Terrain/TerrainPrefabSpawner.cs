using UnityEngine;

namespace Terrain
{
    public class TerrainPrefabSpawner
    {
        public GameObject prefab;

        void SpawnTerrain(GameObject spawnPrefab)
        {
            GameObject.Instantiate(spawnPrefab);
        }
        void SpawnTerrain()
        {
            SpawnTerrain(prefab);
        }
        
    }
}