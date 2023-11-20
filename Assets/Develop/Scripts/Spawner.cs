using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] protected TextAsset currentLevel;

    // Ground Prefabs
    public GameObject grassPrefab;
    public GameObject dirtPrefab;

    [Header("Object Prefabs")] 
    public GameObject treePrefab;
    public GameObject playerPrefab;

    public int currentLayer;

    void Start()
    {
        if (currentLevel != null)
        {
            string[] lines = currentLevel.text.Split('\n');
            bool spawningGroundBlocks = true; // Flag for spawning ground blocks or objects
            int treePlayerStartY = 0;

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y].Trim();
                string[] blocks = line.Split(' ');

                for (int x = 0; x < blocks.Length; x++)
                {
                    if (blocks[x] == "*")
                    {
                        spawningGroundBlocks = false; // Switch to spawning objects
                        treePlayerStartY = y + 1; // Store the start of objects' spawning y-coordinate
                        break; // Exit the loop for ground blocks
                    }

                    if (spawningGroundBlocks)
                    {
                        if (blocks[x] == "0")
                        {
                            Instantiate(grassPrefab, new Vector3(x, 0, -y), Quaternion.identity);
                        }
                        else if (blocks[x] == "1")
                        {
                            Instantiate(dirtPrefab, new Vector3(x, 0, -y), Quaternion.identity);
                        }
                    }
                }
            }

            // Spawning trees and players
            for (int y = treePlayerStartY; y < lines.Length; y++)
            {
                string line = lines[y].Trim();
                string[] blocks = line.Split(' ');

                for (int x = 0; x < blocks.Length; x++)
                {
                    if (blocks[x] == "t")
                    {
                        Instantiate(treePrefab, new Vector3(x, 0.5f, -(y - treePlayerStartY)), Quaternion.identity);
                    }
                    else if (blocks[x] == "p")
                    {
                        Instantiate(playerPrefab, new Vector3(x, 1.1f, -(y - treePlayerStartY)), Quaternion.identity);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No text file assigned!");
        }
    }



    private void Update()
    {
        // Loop over the array, instaniating elements
    }


}
