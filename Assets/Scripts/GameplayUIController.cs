using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    [SerializeField] private Text healthText;
    //[SerializeField] private Text scoreText;

    private int healthValue;

    // Update is called once per frame
    void Update()
    {
        healthValue = PlayerManager.Health;
        healthText.text = "Health: " + healthValue;
    }
}
