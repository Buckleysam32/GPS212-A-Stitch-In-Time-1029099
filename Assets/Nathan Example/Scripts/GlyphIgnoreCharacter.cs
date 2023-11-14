using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GlyphIgnoreCharacter
{
    [SerializeField] private char glyphCharacter;

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
}
