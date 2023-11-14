using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    [SerializeField] protected GridLocation gridLocation;

    public GridLocation CurrentGridLocation
    {
        get
        {
            return gridLocation;
        }
        set
        {
            gridLocation = value;
        }
    }
}
