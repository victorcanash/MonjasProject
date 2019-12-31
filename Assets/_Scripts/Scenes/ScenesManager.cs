using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using MonjasProject.Utils;

namespace MonjasProject.Scenes
{
    public class ScenesManager : Singleton<ScenesManager>
    {
        /// <summary>
        /// Loads a scene
        /// </summary>
        /// <param name="sceneToLoad"> Scene to load </param>
        public void LoadScene(string sceneToLoad)
        {
            SceneManager.LoadScene("LoadScreen");
            StartCoroutine(LoadSceneCoroutine(sceneToLoad));
        }

        private IEnumerator LoadSceneCoroutine(string sceneToLoad)
        {
            yield return null;

            yield return new WaitForSecondsRealtime(2f);

            //Begin to load the Scene you specify
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            //Don't let the Scene activate until you allow it to
            asyncOperation.allowSceneActivation = false;
            //Debug.Log("Pro :" + asyncOperation.progress);
            //When the load is still in progress, output the Text and progress bar
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //Change the Text to show the Scene is ready
                    //m_Text.text = "Press the space bar to continue";
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
            StopAllCoroutines();
        }
    }
}
