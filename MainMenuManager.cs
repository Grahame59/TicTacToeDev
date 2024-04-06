using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManager namespace

public class MainMenuManager : MonoBehaviour
{

 // Method to load the new scene when the background button is clicked
    public void OpenBackgroundScene()
    {
        SceneManager.LoadScene("BackGroundSelector"); 
    }
    
}