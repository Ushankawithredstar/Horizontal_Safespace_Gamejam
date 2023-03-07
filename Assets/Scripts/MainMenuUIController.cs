using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Button playButton = this.playButton.GetComponent<Button>();
        playButton.onClick.AddListener(PlayGame);

        Button quitButton = this.quitButton.GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
