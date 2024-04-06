using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManager namespace


public class BackgroundMenuController : MonoBehaviour
{
     // Method to return to the main menu scene
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
    }

    // Method to save the selected scene data
    public void SaveSelectedScene(string sceneName)
    {
        PlayerPrefs.SetString("SelectedScene", sceneName); // Save the selected scene name to PlayerPrefs
    }

     void Start()
    {
        // Retrieve the saved scene data when the main menu scene is loaded
        string selectedScene = PlayerPrefs.GetString("SelectedScene");
        if (!string.IsNullOrEmpty(selectedScene))
        {
            // Load the selected scene
            SceneManager.LoadScene(selectedScene);
        }
    }

}
