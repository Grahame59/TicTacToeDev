using UnityEngine;
using UnityEngine.UI;

public class CellButtonHandler : MonoBehaviour
{
    // Reference to the TicTacToeGameLogic script
    public TTTGameLogic gameLogic;

    // Method to handle button click events
    public void HandleButtonClick(int row, int col)
    {
        // Call the OnCellClicked() function from the TicTacToeGameLogic script
        gameLogic.OnCellClicked(row, col);
    }
}
