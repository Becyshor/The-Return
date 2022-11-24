using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Quit")]
public class Quit : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        Application.Quit();
    }

}
