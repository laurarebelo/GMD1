using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    // A bit of a weird class.
    // It can be used either for dynamically spawning
    // slimes alongside a dialogue or for checking
    // whether a level is over depending on the number
    // of slimes killed.
    
    // Kill count! Incremented once every kill, with a public function.
    private int killCount;
    
    // Array that contains a list of: the number of enemies
    // that must be killed before a dialogue is triggered.
    private List<int> dialogueTriggerKillCounts;
    
    // Parameters that work for the dynamic slime spawning.
    public TextAsset slimeSpawnListJson;
    private DialogueSlimeSpawn[] slimeSpawnList;
    public DialogueTrigger dialogueTrigger;
    
    // Boolean to determine what to count for.
    public bool level;

    private void Awake()
    {
        dialogueTriggerKillCounts = new List<int>();
        
        // If the Scene at hand is not a level, which means
        // it must be the tutorial (hence the dynamic slime spawning),
        // this class is going to get the "numbers of kills at which
        // to trigger a dialogue" from the same .json file that
        // is spawning the slimes.
        if (!level)
        {
            string jsonString = slimeSpawnListJson.ToString();
            DialogueSlimeSpawnList spawnListObj = JsonUtility.FromJson<DialogueSlimeSpawnList>(jsonString);
            slimeSpawnList = spawnListObj.spawnList;
            for (int i = 0; i < slimeSpawnList.Length; i++)
            {
                int currSlimeNum = slimeSpawnList[0].slimeNumber;
                if (i == 0)
                {
                    dialogueTriggerKillCounts.Add(currSlimeNum);
                }
                else
                {
                    dialogueTriggerKillCounts.Add(dialogueTriggerKillCounts[i - 1] + currSlimeNum);
                }
            }  
        }
    }

    void Start()
    {
        // At Start, if the Scene is a normal level, count the enemies
        // and put that number in the Dialogue Trigger kill list.
        if (level)
        {
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            dialogueTriggerKillCounts.Add(allEnemies.Length);
            Debug.Log("Total number of enemies: " + dialogueTriggerKillCounts[0]);
        }
        killCount = 0;
    }

    public void IncrementKillCount()
    {
        killCount++;
        CheckForNewDialogue();
    }

    // If the current level of kills matches one of those
    // that should trigger a dialogue, then trigger a dialogue.
    private void CheckForNewDialogue()
    {
        if (dialogueTriggerKillCounts.Contains(killCount))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
}
