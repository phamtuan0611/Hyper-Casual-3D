using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private Chunk[] chunkPrefab;
    [SerializeField] private Chunk[] levelChunk;

    // Start is called before the first frame update
    void Start()
    {
        CreateOrderedLevel();
        //CreateRandomLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateOrderedLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunk.Length; i++)
        {
            Chunk chunkToCreate = levelChunk[i];

            if (i > 0) chunkPosition.z += chunkToCreate.GetLength() / 2;

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }

    private void CreateRandomLevel()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = chunkPrefab[Random.Range(0, chunkPrefab.Length)];

            if (i > 0) chunkPosition.z += chunkToCreate.GetLength() / 2;

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }
}
