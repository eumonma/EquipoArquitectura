using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraSize
{

    public static Vector2 GetDimensionsInWorldUnits()
    {
        float width = 0f;
        float height = 0f;

        Camera cam = Camera.main;

        return new Vector2(width, height);
    }
}
