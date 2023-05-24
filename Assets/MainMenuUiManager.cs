using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUiManager : MonoBehaviour
{
    public List<GameObject> menuList = new List<GameObject>();


    private void Start()
    {
        ChangeMainMenu();
        AudioManager.instance.Play("Background");
    }
    public void ChangeMenu(MenuState menuState)
    {
        AudioManager.instance.Play("Click");
        foreach (var menu in menuList)
        {
            menu.SetActive(false);  

        }

        foreach (var menu in menuList)
        {
            if(menu.GetComponent<MenuStats>().state == menuState) 
            {
                menu.SetActive(true);
                LeanTween.scale(menu.gameObject, new Vector3(1.2f, 1.2f, 0), 0.1f).setEaseInExpo().setOnComplete(() =>
                {
                    LeanTween.scale(menu.gameObject, new Vector3(1f, 1f, 0), 0.2f).setEaseInBack();
                    


                });


            }
            else
            {

            }

        }
    }

    public void ChangeTutorial()
    {
        ChangeMenu(MenuState.Tutorial); 
    }

    public void ChangeMainMenu()
    {
        ChangeMenu(MenuState.MainMenu);
    }
    public void ChangeSynopsis()
    {
        ChangeMenu(MenuState.Synopsis); 
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

}
public enum MenuState
{
    Tutorial, MainMenu, Synopsis
}






