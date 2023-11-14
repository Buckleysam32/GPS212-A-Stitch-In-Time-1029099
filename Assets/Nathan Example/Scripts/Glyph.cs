using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Glyph Data", menuName = "ScriptableObjects/Glyph Data", order = 1)]
public class Glyph : ScriptableObject
{
    [SerializeField] private char layerBreakCharacter = '*';
    
    [SerializeField] protected List<GlyphItem> glyphItems = new List<GlyphItem>();
    private Dictionary<char, GlyphItem> allGlyphsData = new Dictionary<char, GlyphItem>();

    [SerializeField] protected List<GlyphRotationData> glyphRotationData = new List<GlyphRotationData>();
    private Dictionary<char, GlyphRotationData> allGlyphRotationData = new Dictionary<char, GlyphRotationData>();


    [SerializeField] protected List<GlyphIgnoreCharacter> ignoreGlyphCharacters = new List<GlyphIgnoreCharacter>();
    private Dictionary<char, GlyphIgnoreCharacter> allGlyphIgnoreData = new Dictionary<char, GlyphIgnoreCharacter>();

    [SerializeField] protected List<GlyphLayer> glyphLayers = new List<GlyphLayer>();
    private Dictionary<int, GlyphLayer> allGlyphLayerData = new Dictionary<int, GlyphLayer>();


    public void Setup()
    {
        SetUpGlyphDictionary(ref allGlyphsData, ref glyphItems);
        SetUpRotationalDictionary(ref allGlyphRotationData, ref glyphRotationData);
        SetUpGlyphIgnoreDictionary(ref allGlyphIgnoreData, ref ignoreGlyphCharacters);
        SetUpGlyphLayerDictionary(ref allGlyphLayerData, ref glyphLayers);
    }

    /// <summary>
    /// Spawns the object if it exists within our glyph with the given rotation etc.
    /// </summary>
    /// <param name="character"></param>
    /// <param name="position"></param>
    /// <param name="rotationalChar"></param>
    /// <param name="parent"></param>
    public void SpawnGlyphItem(char character, Vector3 position, int layerOffset, char rotationalChar, Transform parent = null)
    {
        // we probably want to search our dictionaries for our chars... and then tell the glyph to spawn in.
        GlyphItem glyph;
        GlyphRotationData rotationData;
        GlyphLayer layer;

        if (allGlyphRotationData.TryGetValue(rotationalChar, out rotationData))
        {
            if (allGlyphLayerData.TryGetValue(layerOffset, out layer))
            {
                if (allGlyphsData.TryGetValue(character, out glyph))
                {
                    glyph.SpawnObject(position + layer.ReturnLayerOffset(), rotationData.ReturnEulerRotation(), parent);
                }
                else
                {
                    Debug.LogError("Glyph Character does not exist in glyph: " + character);
                }
            }
            else
            {
                Debug.LogError("No Layer Offset exists in glyph for: " + layerOffset);
            }
        }
        else
        {
            Debug.LogError("Rotational Character does not exist in glyph: " + rotationalChar);
        }
    }

    /// <summary>
    /// returns if the character is in the glyph ignore
    /// </summary>
    /// <param name="characterToCheck"></param>
    /// <returns></returns>
    public bool IsCharacterInGlyphIgnore(char characterToCheck)
    {
        return allGlyphIgnoreData.ContainsKey(characterToCheck);
    }

    /// <summary>
    /// Passes in a dictionary and a list, the list we want to add our values to the dictionary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="list"></param>
    private void SetUpGlyphDictionary(ref Dictionary<char,GlyphItem> dictionary, ref List<GlyphItem> list)
    {
        dictionary.Clear(); // clear our dictionary.
        for (int i = 0; i < list.Count; i++)
        {
            allGlyphsData.Add(list[i].GetGlyphCharacter, list[i]);
        }
    }
    
    /// <summary>
    /// Passes in a dictionary and a list, the list we want to add our values to the dictionary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="list"></param>
    private void SetUpRotationalDictionary(ref Dictionary<char, GlyphRotationData> dictionary, ref List<GlyphRotationData> list)
    {
        dictionary.Clear(); // clear our dictionary.
        for (int i = 0; i < list.Count; i++)
        {
            dictionary.Add(list[i].GetGlyphCharacter, list[i]);
        }
    }

    /// <summary>
    /// Passes in a dictionary and a list, the list we want to add our values to the dictionary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="list"></param>
    private void SetUpGlyphIgnoreDictionary(ref Dictionary<char, GlyphIgnoreCharacter> dictionary, ref List<GlyphIgnoreCharacter> list)
    {
        dictionary.Clear(); // clear our dictionary.
        for (int i = 0; i < list.Count; i++)
        {
            dictionary.Add(list[i].GetGlyphCharacter, list[i]);
        }
    }

    /// <summary>
    /// Passes in a dictionary and a list, the list we want to add our values to the dictionary.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dictionary"></param>
    /// <param name="list"></param>
    private void SetUpGlyphLayerDictionary(ref Dictionary<int, GlyphLayer> dictionary, ref List<GlyphLayer> list)
    {
        dictionary.Clear(); // clear our dictionary.
        for (int i = 0; i < list.Count; i++)
        {
            dictionary.Add(list[i].ReturnLayerNumber(), list[i]);
        }
    }
}
