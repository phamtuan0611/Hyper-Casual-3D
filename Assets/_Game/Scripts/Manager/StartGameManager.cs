using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private string sceneMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneMainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
