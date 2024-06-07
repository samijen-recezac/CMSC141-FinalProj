using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1toFight : MonoBehaviour
{
    public void MovetoFight()
    {
        SceneManager.LoadScene("Fight");
    }

    public void MovetoScene2()
    {
        SceneManager.LoadScene("Scene 2");
    }
}
