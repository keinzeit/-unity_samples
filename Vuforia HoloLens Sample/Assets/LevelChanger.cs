using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class LevelChanger : MonoBehaviour {

    private int levelToLoad;

    public static LevelChanger instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }



    void Update()
    {
        // clicking left mouse button loads the map scene
        if (Input.GetMouseButtonDown(0))
        {
            levelToLoad = 3;
            LoadLevel(levelToLoad);
        }
    }

    public void LoadNextLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevel(levelToLoad);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        TrackerManager.Instance.GetStateManager().ReassociateTrackables();
    }
}
