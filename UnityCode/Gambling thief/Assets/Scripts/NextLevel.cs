using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int nextSceneLoad;
    public int levelIndex;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "NextLevel"){
            PlayerPrefs.SetInt("Lv"+levelIndex,1);
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount){
                Debug.Log("Se acabo");
                Application.Quit();
            }else{
                
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                Debug.Log(SceneManager.sceneCount);
                SceneManager.LoadScene(nextSceneLoad);
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt")){
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
    public void IniciarNivel(int level){
        SceneManager.LoadScene(level);
    }
    public void BackToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void GoToSelectLevel(){
        SceneManager.LoadScene(1);
    }
    public void ReiniciarNivel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit(){
        Application.Quit();
    }
}
