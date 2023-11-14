using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] protected Glyph currentGlpyh;
    [SerializeField] protected TextAsset currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentGlpyh.Setup();
        currentGlpyh.SpawnGlyphItem('p', new Vector3(1, 0, 1),1, '>');   
        currentGlpyh.SpawnGlyphItem('1', new Vector3(1, 0, 1),0, '.');   
        currentGlpyh.SpawnGlyphItem('1', new Vector3(1, 0, 1),2, '.');   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
