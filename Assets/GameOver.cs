using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameController gameController; 
    public void RestartButtonClicked()
    {
        gameController.RestartGame(); 
    }
}
