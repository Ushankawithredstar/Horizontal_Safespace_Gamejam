using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;

    private string sceneName;

    private static GameManager _instance;

    private bool sceneIsChanging;

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
        if (player == null && sceneName == "Gameplay" && sceneIsChanging == false)
            StartCoroutine(SceneTransition());
        if (sceneName == "MainMenu")
            sceneIsChanging = false;
    }

    private IEnumerator SceneTransition()
    {
        sceneIsChanging = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainMenu");
    }

}
