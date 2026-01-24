using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public int _sceneIndex = 0;
    public KeyCode _moveKey = KeyCode.L;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(_moveKey))
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}
