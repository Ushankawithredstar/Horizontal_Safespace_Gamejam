using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private static GameManager _instance;

    private string sceneName;

    private bool isSceneChanging;

    private readonly float transitionTime = 1f;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        sceneName = SceneManager.GetActiveScene().name;
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        //Changes the scene back to Main Menu if the player dies.
        if (player is null && sceneName == "Gameplay" && isSceneChanging == false)
            StartCoroutine(SceneTransition());
        if (sceneName == "MainMenu")
         isSceneChanging = false;
    }

    private IEnumerator SceneTransition()
    {
        /* It was supposed to be smooth scene transition,
         * but I failed to implement it. */
        isSceneChanging = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainMenu");
    }
}
