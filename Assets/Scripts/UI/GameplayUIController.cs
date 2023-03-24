using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;

    // public static int ScoreCount;

    private int scoreValue;

    private void Update()
    {
        //Outputs current health and score.
        int healthValue = PlayerHealthManager._Health;
        // scoreValue = ScoreCount;

        healthText.text = "Health: " + healthValue;
        scoreText.text = "Score: " + scoreValue;
    }
}
