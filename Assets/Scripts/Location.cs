using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string desciption;

    public Connection[] connections;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";
        }
        return result;
    }
}
