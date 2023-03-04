using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playGame;

    private void Awake()
    {
        Button playGame = this.playGame.GetComponent<Button>();
        playGame.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
