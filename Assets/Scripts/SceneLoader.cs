using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

   

    void Awake()
    {
       
    }

        public void LoadSceneOnClick(int sceneNo)
    {
        
        SceneManager.LoadScene(sceneNo);
    }

}