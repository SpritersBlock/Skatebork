using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public SceneTransition st;

	public void MoveToGame()
    {
        //Do whatever animation thing is to be done here
        //SceneManager.LoadScene("Gameplay");
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

    }

    public void QuitConfirmClose()
    {

    }
}
