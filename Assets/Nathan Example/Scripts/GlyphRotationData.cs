using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GlyphRotationData 
{
    [SerializeField] private char glyphCharacter;
    [SerializeField] private Vector3 eulerRotation;

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
    /// Returns the Euler rotation angle of this Glyph
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnEulerRotation()
    {
        return eulerRotation;
    }

}
