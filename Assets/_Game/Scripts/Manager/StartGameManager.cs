using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private string sceneMainMenu;
    [SerializeField] private GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        settingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }

    public void HideSetting()
    {
        settingPanel.SetActive(false);
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
