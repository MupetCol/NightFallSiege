using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FMODLoader : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (FMODUnity.RuntimeManager.HaveAllBanksLoaded)
        {
            Debug.Log("Master Bank Loaded");
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}
