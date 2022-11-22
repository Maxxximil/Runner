using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] public Transform Player;
    [SerializeField] public Chunk[] ChunkPrefabs;
    [SerializeField] public Chunk FirstChunk;
    [SerializeField] public Block[] BlockPrefabs;
    [SerializeField] public Block FirstBlock;

    private List<Chunk> spawnedChanks = new List<Chunk>();
    private List<Block> spawnedBlocks = new List<Block>();


    private void Start()
    {
        spawnedChanks.Add(FirstChunk);
        spawnedBlocks.Add(FirstBlock);
    }
    private void Update()
    {
        if(Player.position.z > spawnedChanks[spawnedChanks.Count - 1].End.position.z - 40)
        {
            SpawnChunk();
        }

        if ((Player.position.z > spawnedBlocks[spawnedBlocks.Count - 1].place.position.z + 5))
        {
            SpawnBlocks();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChanks[spawnedChanks.Count-1].End.position - newChunk.Begin.position;
        spawnedChanks.Add(newChunk);
        if(spawnedChanks.Count >= 3)
        {
            DestroyImmediate(spawnedChanks[0].gameObject, true);
            spawnedChanks.RemoveAt(0);
        }
    }

    private void SpawnBlocks()
    {
        Block newBlock = Instantiate(BlockPrefabs[Random.Range(0, BlockPrefabs.Length)]);
        int[] num = { -3, 0, 3 };
        int pos = num[Random.Range(0, num.Length)];
        Vector3 posBlock = new Vector3(pos, 1, Player.position.z + 20);
        newBlock.transform.position = posBlock;
        spawnedBlocks.Add(newBlock);
        if(spawnedBlocks.Count >= 3)
        {
            DestroyImmediate(spawnedBlocks[0].gameObject, true);
            spawnedBlocks.RemoveAt(0);
        }
    }
}
