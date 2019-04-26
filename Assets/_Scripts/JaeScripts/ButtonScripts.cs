using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public SceneTransition st;

    public GameObject confirmPanel;

    public MenuTransitions mt;

    private void Start()
    {
        confirmPanel.SetActive(false);
        mt.buttonNullAnim.SetBool("OnScreen", true);
    }

    public void MoveToGame()
    {
        StartCoroutine(st.LoadScene());
    }

    public void OptionsOpen()
    {

    }

    public void OptionsClose()
    {

    }

    public void QuitConfirmOpen()
    {
        confirmPanel.SetActive(true);
        mt.buttonNullAnim.SetBool("OnScreen", false);
    }

    public void QuitConfirmClose()
    {
        confirmPanel.SetActive(false);
        mt.buttonNullAnim.SetBool("OnScreen", true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
