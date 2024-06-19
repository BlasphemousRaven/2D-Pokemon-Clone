using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] float loadingDelay = 1f;


    public void LoadNextScene(int i){
        StartCoroutine(LoadSceneDelayed(i));
    }

    private IEnumerator LoadSceneDelayed(int i){
        yield return new WaitForSeconds(loadingDelay);
        SceneManager.LoadScene(i);
    }
}
