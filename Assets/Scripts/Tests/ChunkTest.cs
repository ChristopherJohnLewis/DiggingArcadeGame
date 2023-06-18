using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Terrain;

public class ChunkTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ChunkTestSimplePasses()
    {
        //Arrange
        Vector3 unityLocation = new Vector3(0,0,0);
        //Act
        Vector3 chunkLocation = Chunk.LocationToChunk(unityLocation);
        //Assert
        Assert.AreEqual(new Vector3(0,0,0), chunkLocation);
    }
    [Test]
    public void ChunkTestXYZIncrement()
    {
        //Arrange
        Vector3 unityLocation = new Vector3(Chunk.SizeVector.x+1,Chunk.SizeVector.y+1,Chunk.SizeVector.z+1);
        //Act
        Vector3 chunkLocation = Chunk.LocationToChunk(unityLocation);
        //Assert
        Assert.AreEqual(new Vector3(1,1,1), chunkLocation);
    }
    [Test]
    public void ChunkTestSizeEdgeCase()
    {
        //Arrange
        Vector3 unityLocation = new Vector3(Chunk.SizeVector.x-.1f,Chunk.SizeVector.y-.1f,Chunk.SizeVector.z-.1f);
        //Act
        Vector3 chunkLocation = Chunk.LocationToChunk(unityLocation);
        //Assert
        Assert.AreEqual(new Vector3(0,0,0), chunkLocation);
    }
    [Test]
    public void ChunkTestNegativeXYZIncrement()
    {
        //Arrange
        Vector3 unityLocation = new Vector3(0-(Chunk.SizeVector.x+1),0-(Chunk.SizeVector.y+1),0-(Chunk.SizeVector.z+1));
        //Act
        Vector3 chunkLocation = Chunk.LocationToChunk(unityLocation);
        //Assert
        Assert.AreEqual(new Vector3(-2,-2,-2), chunkLocation);
    }
    [Test]
    public void ChunkTestNegativeIncrementCase()
    {
        //Arrange
        Vector3 unityLocation = new Vector3(-1,-1,-1);
        //Act
        Vector3 chunkLocation = Chunk.LocationToChunk(unityLocation);
        //Assert
        Assert.AreEqual(new Vector3(-1,-1,-1), chunkLocation);
    }
}
