using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public int nextSceneLoad;
    public int levelIndex;
    public GameObject Fin;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "NextLevel"){
            PlayerPrefs.SetInt("Lv"+levelIndex,1);
            if (SceneManager.GetActiveScene().buildIndex == 9){
                Debug.Log("Se acabo");
                Time.timeScale = 0f;
                Fin.SetActive(true);
            }else{
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void ReiniciarNivel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit(){
        Application.Quit();
    }
    public void ReiniciarAvance(){
        PlayerPrefs.DeleteAll();
    }
}
