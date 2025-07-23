using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void periodicTableScene()
    {
        //When called loads peridoic table scene
        SceneManager.LoadScene(1);
    }

    public void quizScene()
    {
        //when called loads quiz scene
        SceneManager.LoadScene(2);
    }

    public void menuScene()
    {
        //when called loads menu scene
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        //when called quits application
        Application.Quit();
    }

}
