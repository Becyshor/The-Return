using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text historyText;
    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;

    void Start()
    {
        historyText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    void Update()
    {
        
    }

    //Displays all the information on the location
    public void DisplayLocation()
    {
        string description = player.currentLocation.desciption + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();
        currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void LogCurrentText()
    {
        historyText.text += "\n\n";
        historyText.text += currentText.text;

        historyText.text += "\n\n";
        historyText.text += "<color=#42FF46>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();
        char[] delimiter = {' '};
        string[] separateWords = input.Split(delimiter);

        foreach (Action action in actions)
        {
            if (action.keyword.ToLower() == separateWords[0])
            {
                if (separateWords.Length > 1)
                {
                    action.RespondToInput(this, separateWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens! (having trouble? type Help)";
    }
}
