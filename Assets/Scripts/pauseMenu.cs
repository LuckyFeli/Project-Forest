using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class pauseMenu : MonoBehaviour
{
    private PlayerControls menu;
    public void Awake()
    {
        menu = new PlayerControls();
        menu.Menu.Enable();
    }
    public void Resume(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.UnloadSceneAsync("Settings");
            pauseManager.instance.resumeGame();
        }
    }
    public void ResumeClick()
    {
        SceneManager.UnloadSceneAsync("Settings");
        pauseManager.instance.resumeGame();
    }
    public void quitwithoutSave()
    {
        Application.Quit();
    }
    public void SavePlayer()
    {
        Debug.Log("saving");
        SaveSystem.SavePlayer(pauseManager.instance.movement.gameObject.GetComponent<Movement>());
    }
    public void LoadPlayer()
    {
        Debug.Log("loading");
        PlayerData data = SaveSystem.loadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        pauseManager.instance.loadGame(position);
        
        
    }
}
