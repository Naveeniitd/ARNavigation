using System.Diagnostics;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

[System.Serializable]
public class Main
{
    public routes[] routes;
    public waypoints[] waypoints;
    public string code;
    public string Server;
    public string version;


}

[System.Serializable]

public class routes
{
    public Legs[] legs;
    public string weight_name;
    public float distance;
    public float duration;
    public string geometry;

}

[System.Serializable]
public class Legs
{
    public Steps[] steps;
    public float distance;
    public float duration;
    public string summary;
    public string weight;
}

[System.Serializable]
public class Steps
{
    public float weight;
    public float distance;
    public float duration;
    public string geometry;
    public intersection[] intersections;
    public string driving_side;
    public string name;
    public maneuver maneuver;
    public string mode;
    public string @ref;
}

[System.Serializable]
public class intersection
{
    public float[] location;
    public string[] classes;
    public int[] bearings;
    public bool[] entry;
    public int @in;
    public int @out;
    public lanes[] lanes;
}

[System.Serializable]
public class lanes
{
    public bool valid;
    public string[] indications;
}

[System.Serializable]
public class maneuver
{
    public float[] location;
    public int bearing_before;
    public int bearing_after;
    public string modifier;
    public string type;
}
[System.Serializable]
public class waypoints
{
    public string hint;
    public string name;
    public float distance;
    public float[] location;
}