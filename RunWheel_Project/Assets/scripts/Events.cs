using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    
    public void replay_game()
    {

        
        SceneManager.LoadScene("Level");
    }

    public void Exite()
    {
        
        SceneManager.LoadScene("Menu");
    }

}
