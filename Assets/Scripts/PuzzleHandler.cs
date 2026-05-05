using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleHandler : MonoBehaviour
{
    //attach the empty square
    public Button emptyButton;

    public CharacterMovement movementScript;
    public PlayerPoint playerPoint;
    public MouseRotate mouseScript;
    public GameObject puzzleCanvas;

    private void Start()
    {
        Shuffle();
    }

    //checker that takes two indices (from hierarchy) of two squares and returns whether they're adjacent
    private bool IsAdjacent(int index1, int index2)
    {
        //row changes every 3 indices, column increases in a cycle of 1-3 each index
        int row1 = index1 / 3;
        int col1 = 1 + index1 % 3;

        int row2 = index2 / 3;
        int col2 = 1 + index2 % 3;

        int rowDiff = Mathf.Abs(row1 - row2);
        int colDiff = Mathf.Abs(col1 - col2);

        //they should be right next to each other on row or column, but not diagonally
        if ((rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1))
        {
            return true;
        }
        return false;
    }


    //When player clicks button, check if it's next to empty slot. If so, swap. Otherwise, do nothing.
    public void OnSquareClick(Button clickedButton)
    {
        //get the hierarchy indices for the empty slot and the button attached
        int emptyIndex = emptyButton.transform.GetSiblingIndex();
        int clickedIndex = clickedButton.transform.GetSiblingIndex();

        //if the clicked button is adjacent to an empty one, swap their indices
        if (IsAdjacent(emptyIndex, clickedIndex))
        {
            clickedButton.transform.SetSiblingIndex(emptyIndex);
            emptyButton.transform.SetSiblingIndex(clickedIndex);
        }

        CheckWin();
    }

    public void Shuffle()
    {
        //do a hundred random swaps
        for (int i = 0; i < 100; i++)
        {
            //get index of the empty slot
            int emptyIndex = emptyButton.transform.GetSiblingIndex();

            //declare array of up to 4 neighbors, count will check how many neighbors there are
            int[] neighborIndex = new int[4];
            int count = 0;

            //check each button, add any neighboring indices to the array
            for (int j = 0; j < 9; j++)
            {
                if (IsAdjacent(emptyIndex, j))
                {
                    neighborIndex[count] = j;
                    count++;
                }
            }

            //pick a random index from the array
            int randomIndex = neighborIndex[Random.Range(0, count)];

            //swap empty button with the selected random neighbor
            Button neighborButton = transform.GetChild(randomIndex).GetComponent<Button>();
            neighborButton.transform.SetSiblingIndex(emptyIndex);
            emptyButton.transform.SetSiblingIndex(randomIndex);
        }
    }

    private void exitPuzzle()
    {
        movementScript.enabled = true;
        mouseScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        puzzleCanvas.SetActive(false);
    }

    public void OnPauseClick(Button pauseButton)
    {
        exitPuzzle();
    }

    public void CheckWin()
    {
        bool isComplete = true;

        //loop through all the buttons except empty
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            //check if the button name matches the position (which means it's correct)
            if (transform.GetChild(i).name != i.ToString())
            {
                Debug.Log(i + " " + transform.GetChild(i));
                isComplete = false;
                break;
            }
        }

        if (isComplete)
        {
            exitPuzzle();
            playerPoint.AddPoint();
            SceneManager.LoadScene("Scenes/Puzzle Complete");
        }
    }
}
