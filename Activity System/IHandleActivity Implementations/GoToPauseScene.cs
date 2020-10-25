using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPauseScene : MonoBehaviour, IHandleActivity
{
    public void OnActivityTracked()
    {
        throw new System.NotImplementedException();
    }

    public void OnNoActivityTracked()
    {
        SceneManager.LoadScene("Pause Scene");
    }
}
