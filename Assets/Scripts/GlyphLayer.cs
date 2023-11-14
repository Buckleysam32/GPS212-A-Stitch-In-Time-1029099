using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct GlyphLayer
{
    [SerializeField] private int layernumber;
    [SerializeField] private Vector3 layerOffset;

    public int ReturnLayerNumber()
    {
        return layernumber;
    }

    public Vector3 ReturnLayerOffset()
    {
        return layerOffset;
    }
}
