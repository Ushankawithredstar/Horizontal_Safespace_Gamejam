using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{


    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
