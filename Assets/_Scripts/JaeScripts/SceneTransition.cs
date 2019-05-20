using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public Animator anim;
    public AudioSource song;
    //public string sceneName;

    public IEnumerator LoadScene(string sceneName)
    {
        anim.SetTrigger("End");
        song.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
