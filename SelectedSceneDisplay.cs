using UnityEngine;
using TMPro;

public class SelectedSceneDisplay : MonoBehaviour
{
    public TMP_Text selectedSceneText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // If you want to set initial text in Start, you can do it like this
        selectedSceneText.text = "Initializing..."; 
    }

    void Update()
    {
        // Retrieve the saved scene data when the main menu scene is loaded
        string selectedScene = PlayerPrefs.GetString("SelectedScene");
        if (!string.IsNullOrEmpty(selectedScene))
        {
            // Update the text with the name of the selected scene
            selectedSceneText.text = "Selected Scene: " + selectedScene;
        }
        else
        {
            selectedSceneText.text = "No scene selected";
        }
    }
}

