using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] protected bool onlyCardinal = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (onlyCardinal)
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.z != (Spawner.h - 0.5f))
            {
                transform.position += new Vector3(0, 0, 1);
            }
            else if (Input.GetKeyDown(KeyCode.S) && transform.position.z != 0.5)
            {
                transform.position += new Vector3(0, 0, -1);
            }
            else if (Input.GetKeyDown(KeyCode.A) && transform.position.x != 0.5)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x != (Spawner.w - 0.5f))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) && transform.position.z != 0.5)
            {
                transform.position += new Vector3(0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.S) && transform.position.z != Spawner.h)
            {
                transform.position += new Vector3(0, 0, -1);
            }
            if (Input.GetKeyDown(KeyCode.A) && transform.position.x != 0.5)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D) && transform.position.x != Spawner.w)
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
    }
}
