using UnityEngine;

public class BackgroundButtonHandler : MonoBehaviour
{
    public string sceneName; // Name of the scene linked to this button

    // Reference to the BackgroundMenuController script
    public BackgroundMenuController backgroundMenuController;

    // Method to handle button click event
    public void OnButtonClick()
    {
        // Call the SaveSelectedScene method from BackgroundMenuController
        backgroundMenuController.SaveSelectedScene(sceneName);
    }
}