using UnityEngine;

namespace Terrain
{
    public class Chunk
    {
        public static Vector3 SizeVector { get; } = new Vector3(ChunkSize,ChunkSize,ChunkSize);
        public static int ChunkSize => 100;

        public static Vector3 LocationToChunk(Vector3 unityLocation)
        {
            int x = ((int)unityLocation.x / ChunkSize) - (unityLocation.x < 0 ? 1 : 0);
            int y = ((int)unityLocation.y / ChunkSize) - (unityLocation.y < 0 ? 1 : 0);
            int z = ((int)unityLocation.z / ChunkSize) - (unityLocation.z < 0 ? 1 : 0);

            return new Vector3(x, y, z);
        }

    }
}