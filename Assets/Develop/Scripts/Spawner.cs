using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] protected TextAsset currentLevel;

    public GameObject grassPrefab;
    public GameObject dirtPrefab;

    private void Start()
    {
        if (currentLevel != null)
        {
            string[] lines = currentLevel.text.Split('\n');

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y].Trim();
                string[] blocks = line.Split(' ');

                for (int x = 0; x < blocks.Length; x++)
                {
                    int blockType;
                    if (int.TryParse(blocks[x], out blockType))
                    {
                        GameObject prefabToSpawn = blockType == 0 ? grassPrefab : dirtPrefab;
                        Vector3 spawnPosition = new Vector3(x, 0, y);

                        GameObject spawnedBlock = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

                        spawnedBlock.transform.parent = transform;

                    }
                        

                }
            }
        }
    }

    private void Update()
    {
        // Loop over the array, instaniating elements
    }


}
