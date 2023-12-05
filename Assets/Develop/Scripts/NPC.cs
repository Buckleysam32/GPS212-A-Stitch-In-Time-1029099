using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<Vector2Int> Path = new List<Vector2Int>();

    public Rigidbody enemyRigidBody;

    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Destroy(other.gameObject);
            Debug.Log("Player had been killed");
        }
    }

    void Update()
    {
        Vector2Int pos = new Vector2Int((int)transform.position.x, (int)transform.position.z);

        for (int i = 0; i < Path.Count - 1; ++i)
        {
            Debug.DrawLine(
                new Vector3(Path[i].x + 0.5f, 1.1f, Path[i].y + 0.5f),
                new Vector3(Path[i + 1].x + 0.5f, 1.1f, Path[i + 1].y + 0.5f),
                Color.yellow);
        }

        if (Path.Count == 0)
        {
            Vector2Int newtarget = new Vector2Int();
            
            
            do
            {
                newtarget.x = Random.Range(1, Pathfind.GridWidth - 1);
                newtarget.y = Random.Range(1, Pathfind.GridHeight - 1);
            } 
            while (Pathfind.GetNode(newtarget).Wall);

            Path = Pathfind.FindPath(
                new Vector2Int((int)transform.position.x, (int)transform.position.z),
                newtarget);
        }
        if (Path.Count != 0)
        {
            Vector3 target = new Vector3(
                Path[Path.Count - 1].x + Pathfind.CellSize * 0.5f,
                0.5f,
                Path[Path.Count - 1].y + Pathfind.CellSize * 0.5f);
            Vector3 vel = target - transform.position;
            vel.y = 0;
            GetComponent<Rigidbody>().velocity = (vel).normalized * 8.0f;
            Vector3 difference = transform.position - target;
            difference.y = 0;
            if (difference.magnitude < 0.1f)
            {
                Path.RemoveAt(Path.Count - 1);
            }
        }
        for(int z=0;z<Pathfind.GridHeight;z++) 
        {
            for (int x = 0; x < Pathfind.GridWidth; x++)
            {
                if(Pathfind.GetNode(new Vector2Int(x,z)).Wall)
                {
                    Debug.DrawLine(new Vector3(x + 0.5f, 0, z + 0.5f), new Vector3(x + 0.5f, 2.0f, z + 0.5f),Color.magenta);
                }
            }
        }
    }
}
