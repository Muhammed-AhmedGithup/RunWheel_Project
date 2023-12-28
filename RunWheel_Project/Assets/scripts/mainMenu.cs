using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        FindAnyObjectByType<Button>().PlaySource();

        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        FindAnyObjectByType<Button>().PlaySource();
        Application.Quit();

    }
}
