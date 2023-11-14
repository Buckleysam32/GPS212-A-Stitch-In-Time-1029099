using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GlyphItem 
{
    [SerializeField] private char glyphCharacter;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Vector3 worldOffset;
    
    /// <summary>
    /// Returns the glphy character
    /// </summary>
    public char GetGlyphCharacter
    {
        get
        {
            return glyphCharacter;
        }
    }
    

    /// <summary>
    /// returns true or false if the glyph matches the character, may not be needed
    /// </summary>
    /// <param name="character"></param>
    /// <returns></returns>
    public bool CompareCharacter(char character)
    {
        return glyphCharacter == character;
    }

    /// <summary>
    /// Spawns in an object.
    /// </summary>
    /// <param name="SpawnPosition"></param>
    /// <param name="rotation"></param>
    /// <param name="parent"></param>
    public void SpawnObject(Vector3 SpawnPosition, Vector3 rotation, Transform parent = null)
    {
        GameObject clone = Object.Instantiate(objectToSpawn, SpawnPosition + worldOffset, Quaternion.Euler(rotation), parent);
        GridItem gridItem = clone.GetComponent<GridItem>();
        if(gridItem)
        {
            gridItem.CurrentGridLocation = new GridLocation((int)SpawnPosition.x,(int)SpawnPosition.z);
        }
    }
}
