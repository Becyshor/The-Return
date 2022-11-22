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

    //GetConnectionsText returns the description of the connection
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

    //GetConnection method returns the connection based on a noud (e.g. north, south)
    public Connection GetConnection(string connectionNoun)
    {
        //scanning all the connections
        foreach (Connection connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return connection;
            }
        }
        return null;
    }
}
