using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;

    public static int ScoreCount;

    private int healthValue;
    private int scoreValue;

    // Update is called once per frame
    private void Update()
    {

        //Outputs current health and score.
        healthValue = PlayerManager.Health;
        scoreValue = ScoreCount;

        healthText.text = "Health: " + healthValue;
        scoreText.text = "Score: " + scoreValue;
    }
}
