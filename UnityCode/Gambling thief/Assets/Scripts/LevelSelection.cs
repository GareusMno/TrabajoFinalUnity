using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;
    private void UpdateLevelImage(){
        if(!unlocked){
            unlockImage.gameObject.SetActive(true);
            for( int i = 0; i < stars.Length; i++){
                stars[i].gameObject.SetActive(false);
            }
        }else{
            unlockImage.gameObject.SetActive(false);
            for( int i = 0; i < stars.Length; i++){
                stars[i].gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    public void PressSelection(string _LevelName){
        if(unlocked==true){
            SceneManager.LoadScene(_LevelName);
        }
    }
    private void UpdateLevelStatus(){
        int previousLevelNum = int.Parse(gameObject.name) -1;
        Debug.Log(previousLevelNum);
        Debug.Log(PlayerPrefs.GetInt("Lv" + previousLevelNum));
        if(PlayerPrefs.GetInt("Lv" + previousLevelNum) > 0){
            unlocked = true;
        }
    }
}
