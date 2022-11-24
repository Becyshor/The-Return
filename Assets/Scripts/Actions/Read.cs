using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check items in room
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
            return;

        //check items in inventory
        if (ReadItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "You can't see a " + noun + ".";
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun && item.itemEnabled)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "Nothing on " + noun + " you could read.";
                return true;
            }
        }
        return false;
    }
}
