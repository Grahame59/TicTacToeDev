using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    //declare/initialize

    public int whoseTurn; // 0 = X, & 1 = O
    public int turnCounter; // counts the number of turns
    public GameObject [] turnIcons; //displays who turn
    public Sprite [] playerIcons; // 0 = XIcon & 1 = OIcon
    public Button[] TTTSpaces; // playable spaces for the game
    public int [] markedSpaces; //Identifies which player marked which spaces
    public TextMeshProUGUI winnerText;
    public bool tieCounter = false;
    public AudioSource buttonClickAudio;
    public AudioSource soundtrackAudio; // Reference to the soundtrack AudioSource
    private bool isMuted = false; // Variable to track mute state
    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public Image muteButtonImage;
    public GameObject EasterEgg;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
        PlaySoundtrack();
    }

    void GameSetup()
    {
        whoseTurn = 0; //starts with X always
        turnCounter = 0; //starts the counter to hold amount of turns
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);

        for (int i = 0; i < TTTSpaces.Length; i++)
        {
            TTTSpaces[i] .interactable = true;
            TTTSpaces[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100; //have to use -100 b/c 0 = xplayer & the drastic number jump makes errors impossible
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int whichNum)
    {
        TTTSpaces [whichNum].image.sprite = playerIcons[whoseTurn]; //places x or o based on whoseTurn
        TTTSpaces[whichNum].interactable = false; //denies the player whose turn it isn't access

        markedSpaces[whichNum] = whoseTurn + 1; //+1 to avoid whose turn being 0 or 1
        turnCounter++;
        //after turn 4 b/c you can't win in 4 turns... turn 5 is quickest win possibility
        if(turnCounter > 4)
        {
            WinnerChecker();
        }

        if(whoseTurn == 0)
        {
            whoseTurn = 1;
            //logic for player turn icon
             turnIcons[0].SetActive(false);
             turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            //logic for player turn icon
             turnIcons[0].SetActive(true);
             turnIcons[1].SetActive(false);
        }
    }

    void WinnerChecker()
    {
        //using the MarkedSpaces [] to check for patterns of 3 in a row for WIN!
        //remember the markedSoaces array is either the value of 1 or 2. 1 = X & 2 = O

        //horozontal pattern for win
        int sol1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int sol2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int sol3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        
        //vertcial pattern for win
        int sol4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int sol5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int sol6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];

        //diagnol pattern for win
        int sol7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int sol8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];

        //array of the solutions
        var solution = new int [] {sol1, sol2, sol3, sol4, sol5, sol6, sol7, sol8};

        bool winFound = false;

        for (int i = 0; i< solution.Length; i++)
        {
            //winner player x = 3 ( 1+1+1 ) && winner player o = 6 (2+2+2).
            if (solution[i] == 3 *(whoseTurn + 1))
            {
                WinDisplay();
                Debug.Log("Player " + whoseTurn + " wins!");
                winFound = true;
                break;
                //-----------------------------------

            }
            else if ( !winFound == true && turnCounter == 9)
            {
                winnerText.gameObject.SetActive(true);
                winnerText.text = "TIE GAME :(";

            }
            
        }
    
    }
    void WinDisplay ()
    {
        winnerText.gameObject.SetActive(true);
        if (whoseTurn == 0)
        {
            winnerText.text = "Player X WINS!";
        }
        else if (whoseTurn == 1)
        {
            winnerText.text = "Player O WINS!";
        }
        for ( int i = 0; i < TTTSpaces.Length; i++)
        {
            TTTSpaces[i].interactable = false; 
        }
        

    }
    public void Rematch()
    {
        GameSetup();
        winnerText.gameObject.SetActive(false);
    }
    public void PlayButtonClick() //audio for buttons
    {
        buttonClickAudio.Play();
    }

    public void Mute()
    {
        isMuted = true;
        soundtrackAudio.volume = 0; // Mute the soundtrack by setting volume to 0
    }

    public void UnMute()
    {
        isMuted = false;
        soundtrackAudio.volume = 1; // Unmute the soundtrack by setting volume to 1 (full volume)
    }

      public void ToggleMute()
    {
        isMuted = !isMuted; // Toggle mute state
        if (isMuted)
        {
            soundtrackAudio.volume = 0; // Mute the soundtrack
            muteButtonImage.sprite = unmuteSprite; // Update button sprite to indicate unmuted state
        }
        else
        {
            soundtrackAudio.volume = 1; // Unmute the soundtrack
            muteButtonImage.sprite = muteSprite; // Update button sprite to indicate muted state
        }
    }
    void PlaySoundtrack()
    {
        soundtrackAudio.loop = true; // Enable looping for the soundtrack
        soundtrackAudio.Play(); // Start playing the soundtrack
    }
    // Called when the button is clicked
    public void EasterEggButton()
    {
        // Show the target image
        if (EasterEgg != null)
        {
            EasterEgg.gameObject.SetActive(true);
            StartCoroutine(HideObjectAfterDelay());
        }
    }

    // Coroutine to hide the image after a delay
    IEnumerator HideObjectAfterDelay()
    {
        // Wait for a few seconds
        yield return new WaitForSeconds(3f); // Adjust the delay time as needed
        
        // Hide the target image
        if (EasterEgg != null)
        {
            EasterEgg.gameObject.SetActive(false);
        }
    }
}

