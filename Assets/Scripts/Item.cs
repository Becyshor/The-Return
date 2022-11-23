using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;
    public bool itemEnabled = true;

    public Interaction[] interactions;

    public bool InteractWith(GameController controller, string actionKeyword)
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyword)
            {
                foreach (Item disableItem in interaction.itemsToDisable)
                    disableItem.itemEnabled = false;

                foreach (Item enableItem in interaction.itemsToEnable)
                    enableItem.itemEnabled = true;

                foreach (Connection disableConnection in interaction.connectionsToDisable)
                    disableConnection.connectionEnabled = false;

                foreach (Connection enableConnection in interaction.connectionsToEnable)
                    enableConnection.connectionEnabled = true;

                controller.currentText.text = interaction.response;

                return true;
            }
        }
        return false;
    }
}
