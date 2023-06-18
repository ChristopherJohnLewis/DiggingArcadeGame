using Player;
using UnityEngine;

namespace Terrain
{
    public class ChunkSpawner
    {
        public void SpawnChunk(Vector3 location)
        {
            PlayerControls.onMovedChunk += movedChunk;
        }

        public void movedChunk(Vector3 location)
        {
            
        }
    }
}