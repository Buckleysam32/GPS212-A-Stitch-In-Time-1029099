using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] protected TextAsset currentLevel;

    public static string[] characters;

    // Start is called before the first frame update
    void Awake()
    {
        characters = currentLevel.text.Split();

        Debug.Log(characters[0]);

        // Convert text to a string array

    }

    private void Update()
    {
        // Loop over the array, instaniating elements
    }


}
