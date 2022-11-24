using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();

    //GetItemsText returns the description of all the items
    public string GetItemsText()
    {
        if (items.Count == 0) return "";

        string result = "You see ";
        bool first = true;

        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first) result += " and ";
                result += item.description;
                first = false;
            }
        }
        result += ".\n";
        return result;
    }

    //GetConnectionsText returns the description of all the connections
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

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
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
