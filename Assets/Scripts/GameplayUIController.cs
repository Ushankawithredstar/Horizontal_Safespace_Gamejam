using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;

    private int healthValue;
    private int scoreValue;

    // Update is called once per frame
    private void Update()
    {
        healthValue = PlayerManager.Health;
        scoreValue = Score.ScoreCount;

        healthText.text = "Health: " + healthValue;
        scoreText.text = "Score: " + scoreValue;
    }
}
