using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
 //public GameObject ABC;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
     // DontDestroyOnLoad(ABC);
    }
    
}
