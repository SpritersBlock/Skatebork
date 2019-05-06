using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public SceneTransition st;

    public GameObject buttonNull;
    public GameObject optionsPanel;
    public GameObject confirmPanel;

    public MenuTransitions mt;

    private void Start()
    {
        if (buttonNull != null)
        {
            buttonNull.SetActive(true);
            optionsPanel.SetActive(false);
            confirmPanel.SetActive(false);
        }
        //mt.buttonNullAnim.SetBool("OnScreen", true);
        //mt.quitConfirmAnim.SetBool("OnScreen", false);
    }

    public void MoveToGame()
    {
        StartCoroutine(st.LoadScene());
    }

    public void OptionsOpen()
    {
        buttonNull.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OptionsClose()
    {
        optionsPanel.SetActive(false);
        buttonNull.SetActive(true);
    }

    public void QuitConfirmOpen()
    {
        buttonNull.SetActive(false);
        confirmPanel.SetActive(true);
        //mt.buttonNullAnim.SetBool("OnScreen", false);
        //mt.quitConfirmAnim.SetBool("OnScreen", true);
    }

    public void QuitConfirmClose()
    {
        buttonNull.SetActive(true);
        confirmPanel.SetActive(false);
        //mt.buttonNullAnim.SetBool("OnScreen", true);
        //mt.quitConfirmAnim.SetBool("OnScreen", false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
