using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene sceneToLoad;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        //int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //print(SceneManager.sceneCountInBuildSettings);
        //if(currentIndex + 1 < SceneManager.sceneCountInBuildSettings)
        //{
        //    sceneToLoad = SceneManager.GetSceneByBuildIndex(currentIndex + 1);
        //    print(sceneToLoad.buildIndex);
        //}
        //else
        //{
        //    sceneToLoad = SceneManager.GetSceneByBuildIndex(0);
        //    print(0);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Locomotion>() && !once)
        {
            once = true;
            //print("pasando de nivel");
            //SceneManager.LoadSceneAsync(sceneToLoad.buildIndex);
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            print(SceneManager.sceneCountInBuildSettings);
            if (currentIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadSceneAsync(currentIndex + 1);
                print(sceneToLoad.buildIndex);
            }
            else
            {
                SceneManager.LoadSceneAsync(0);
                print(0);
            }
        }
    }
}
