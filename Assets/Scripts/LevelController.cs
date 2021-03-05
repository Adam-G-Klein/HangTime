using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject curLevel;
    private GameObject curObject;
    private Vector3 spawnLocation;
    private Vector3 spawnOffset = new Vector3(0, .5f, 0);
    void Start()
    {
        curLevel = GameObject.Find("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckLevelUpdate(GameObject GO){
        // if the object is under a new parent this means the player has gotten to a new level
        GameObject nextLevel = GO.transform.parent.gameObject;
        if(!nextLevel.name.Equals(curLevel.name))
        {
            curLevel.transform.Find("StartingPlatform").transform.gameObject.SetActive(false);
            curLevel = nextLevel;
            
            Transform newStartingPlatform = nextLevel.transform.Find("StartingPlatform").transform;
            newStartingPlatform.gameObject.SetActive(true);
            spawnLocation = newStartingPlatform.transform.position + spawnOffset;
            // This was simply here to test ResetCurrentLevel   
            // ResetCurrentLevel(curLevel);
        }
    }
    
    // When a player dies all spheres in that level should respawn to make the level possible
    // should loop through all sphers and make them active
    // should be called when the player dies to repawn them
    public void ResetCurrentLevel(GameObject GO)
    {
        foreach (Transform child in GO.transform)
        {
            if (child.gameObject.tag == "Sphere")
            {
                child.gameObject.SetActive(true);
            }
        }
        
        // Respawns the player at the current spawn location
        GameObject Player = GameObject.Find("Player");
        Player.transform.position = spawnLocation;
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
}
