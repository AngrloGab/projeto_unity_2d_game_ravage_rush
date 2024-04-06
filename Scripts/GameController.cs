using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start(){
        Time.timeScale = 1;
    }
    
    public void RestartGame(){
        SceneManager.LoadScene(1);
    }
}
