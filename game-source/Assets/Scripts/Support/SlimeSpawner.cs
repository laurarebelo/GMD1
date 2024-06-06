using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    // Player's transform to spawn the slimes relatively to him.
    public Transform player;
    
    public GameObject slimePrefab;
    
    // Text asset to load the Slime information
    public TextAsset slimeSpawnListJson;
    
    // Queue that will store the info fetched from the .json
    private Queue<DialogueSlimeSpawn> slimeSpawnList;

    private void Awake()
    {
        slimeSpawnList = new Queue<DialogueSlimeSpawn>();
        string jsonString = slimeSpawnListJson.ToString();
        DialogueSlimeSpawnList spawnListObj = JsonUtility.FromJson<DialogueSlimeSpawnList>(jsonString);
        DialogueSlimeSpawn[] spawnList = spawnListObj.spawnList;
        for (int i = 0; i < spawnList.Length; i++)
        {
            slimeSpawnList.Enqueue(spawnList[i]);
        } 
    }


    public void SpawnNext()
    {
        if (slimeSpawnList.Count > 0)
        {
            DialogueSlimeSpawn next = slimeSpawnList.Dequeue();
            SpawnSlimes(next.r, next.g, next.b, next.slimeNumber);
        }
    }

    private void SpawnSlimes(bool R, bool G, bool B, int numOfSlimes)
    {
        Color slimeColor = Colorz.GetColor(R, G, B);
        
        for (int i = 0; i < numOfSlimes; i++)
        {
            Vector3 nextOffset = Vector3.right * (2 * (i+1));
            Vector3 nextPosition = player.position + nextOffset;
            GameObject nextSlimeGo = Instantiate(slimePrefab, nextPosition, Quaternion.identity);
            ColorHealth nextSlimeCol = nextSlimeGo.gameObject.GetComponent<ColorHealth>();
            nextSlimeCol.SetColor(slimeColor);
        }
    }
    
}
