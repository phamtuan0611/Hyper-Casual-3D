using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;

    [Header(" Settings ")]
    //[SerializeField] private Chunk[] chunkPrefab;
    //[SerializeField] private Chunk[] levelChunk;
    [SerializeField] private LevelSO[] levels;

    private GameObject finishLine;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //CreateOrderedLevel();
        //CreateRandomLevel();
        GenerateLevel();

        finishLine = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateLevel()
    {
        int currentLevel = GetLevel();

        currentLevel = currentLevel % levels.Length;

        LevelSO level = levels[currentLevel];

        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks)
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];

            if (i > 0) chunkPosition.z += chunkToCreate.GetLength() / 2;

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }

    //private void CreateOrderedLevel()
    //{
    //    Vector3 chunkPosition = Vector3.zero;
    //    for (int i = 0; i < levelChunk.Length; i++)
    //    {
    //        Chunk chunkToCreate = levelChunk[i];

    //        if (i > 0) chunkPosition.z += chunkToCreate.GetLength() / 2;

    //        Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

    //        chunkPosition.z += chunkInstance.GetLength() / 2;
    //    }
    //}

    //private void CreateRandomLevel()
    //{
    //    Vector3 chunkPosition = Vector3.zero;
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Chunk chunkToCreate = chunkPrefab[Random.Range(0, chunkPrefab.Length)];

    //        if (i > 0) chunkPosition.z += chunkToCreate.GetLength() / 2;

    //        Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);

    //        chunkPosition.z += chunkInstance.GetLength() / 2;
    //    }
    //}

    public float GetFinishZ()
    {
        return finishLine.transform.position.z;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);
    }
}
