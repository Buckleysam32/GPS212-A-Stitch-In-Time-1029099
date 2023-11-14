using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GridLocation
{
    [SerializeField] private int xCoordinate;
    [SerializeField] private int yCoordinate;

    /// <summary>
    /// Constructor used to initalise this struct with data
    /// takes in a x and y location.
    /// </summary>
    /// <param name="xLocation"></param>
    /// <param name="yLocation"></param>
    public GridLocation(int xLocation, int yLocation)
    {
        xCoordinate = xLocation;
        yCoordinate = yLocation;
    }

    /// <summary>
    /// Returns the current grid location of xcoordinate, ycoordinate.
    /// </summary>
    /// <returns></returns>
    public Vector2 ReturnGridLocation()
    {
        return new Vector2(xCoordinate, yCoordinate);
    }

    /// <summary>
    /// Set the location of our item to an int grid location
    /// </summary>
    /// <param name="location"></param>
    public void SetGridLocation(Vector2 location)
    {
        xCoordinate = (int)location.x;
        yCoordinate = (int)location.y;
    }

}
