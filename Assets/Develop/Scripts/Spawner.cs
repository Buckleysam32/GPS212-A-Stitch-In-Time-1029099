using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;

public class Spawner : MonoBehaviour
{

    [SerializeField] protected TextAsset currentLevel;

    // Ground Prefabs
    [Header("Ground Prefabs")]
    public GameObject grassPrefab;
    public GameObject dirtPrefab;

    [Header("Object Prefabs")] 
    public GameObject treePrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public int currentLayer;
    public bool isWorldSpawned;

    public static int w = 0;
    public static int h = 0;

    private void Awake()
    {
        isWorldSpawned = false;
    }

    public void SpawnWorld()
    {
        

        if (currentLevel != null && isWorldSpawned == false)
        {
            string[] lines = currentLevel.text.Split('\n');
            bool spawningGroundBlocks = true; 
            int treePlayerStartY = 0;

            // Prepass first layer to find width and height.
            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y].Trim();
                string[] blocks = line.Split(' ');
                if (w < blocks.Length) { w = blocks.Length; }

                for (int x = 0; x < blocks.Length; x++)
                {
                    if (blocks[x] == "*")
                    {
                        h = y;
                        break;
                    }
                }
            }

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y].Trim();
                string[] blocks = line.Split(' ');

                for (int x = 0; x < blocks.Length; x++)
                {
                    if (blocks[x] == "*")
                    {
                        spawningGroundBlocks = false; 
                        treePlayerStartY = y + 1; 
                        break; 
                    }

                    if (spawningGroundBlocks)
                    {
                        if (blocks[x] == "0")
                        {
                            Instantiate(grassPrefab, new Vector3(x+0.5f, 0, h-y-1 + 0.5f), Quaternion.identity);
                        }
                        else if (blocks[x] == "1")
                        {

                            Instantiate(dirtPrefab, new Vector3(x + 0.5f, 0, h - y - 1 + 0.5f), Quaternion.identity);

                        }
                    }
                }
            }
            Pathfind.CreateMap(w, h);
            for (int y = treePlayerStartY; y < lines.Length; y++)
            {
                string line = lines[y].Trim();
                string[] blocks = line.Split(' ');

                for (int x = 0; x < blocks.Length; x++)
                {
                    if (blocks[x] == "t")
                    {
                        Pathfind.GetNode(new Vector2Int(x, h-(y - treePlayerStartY)-1)).Wall = true;

                        Instantiate(treePrefab, new Vector3(x + 0.5f, 0.5f, h-(y - treePlayerStartY)-1 + 0.5f), Quaternion.identity);
                    }
                    else if (blocks[x] == "p")
                    {
                        Instantiate(playerPrefab, new Vector3(x + 0.5f, 1.1f, h-(y - treePlayerStartY)-1 + 0.5f), Quaternion.identity);
                    }
                    else if (blocks[x] == "e")
                    {
                        Instantiate(enemyPrefab, new Vector3(x + 0.5f, 1.1f, h-(y - treePlayerStartY)-1 + 0.5f), Quaternion.identity);
                    }
                }
            }

            isWorldSpawned = true;
            //var aaa = Pathfind.Nodes;

        }
        else
        {
            Debug.LogError("World has already been spawned.");
        }



    }

    public void ResetWorld()
    {
        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach(GameObject Obj in GameObject.FindGameObjectsWithTag("Grass"))
        {
            objectsToRemove.Add(Obj);
        }
        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("Dirt"))
        {
            objectsToRemove.Add(Obj);
        }
        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            objectsToRemove.Add(Obj);
        }
        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            objectsToRemove.Add(Obj);
        }
            foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("Tree"))
        {
            objectsToRemove.Add(Obj);
        }

        if (isWorldSpawned == true)
        {
            foreach (GameObject gameObject in objectsToRemove)
            {
                DestroyImmediate(gameObject);
            }
            Debug.Log("Reset World");
            isWorldSpawned = false;
        }
        else
        {
            Debug.LogError("No world to reset");
        }

        

    }

}


[CustomEditor(typeof(Spawner))]
public class InspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Spawner spawner = (Spawner)target;
        
        if(GUILayout.Button("Spawn World"))
        {
            spawner.SpawnWorld();
        }

        if(GUILayout.Button("Reset World"))
        {
            spawner.ResetWorld();
        }

    }

}
