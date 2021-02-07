using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lusofona
{
    public class CustomSceneManager : MonoBehaviour
    {
        #region SINGLETON
        private static CustomSceneManager instance;
        public static CustomSceneManager Instance
        {
            get
            {
                return instance;
            }
        }

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion

        // Isso é chamado quando a animação do mundo termina
        public void ChangeLevel()
        {
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            
            if(SceneManager.GetActiveScene().name == "tutorial_03")
            {
                Debug.Log("Finished tutorial");
                SceneManager.LoadScene(0);
                Time.timeScale = 0.0f;
                PlayerManager.stamina = 100.0f;
            }

            int levelToLoadIndex = levelIndex + 1;
            if (SceneManager.GetActiveScene().name == "level_03")
            {
                levelToLoadIndex = 0;
                Debug.Log("loaded main menu");
                Time.timeScale = 0.0f;
            }

            StartCoroutine(LoadAsyncScene(levelToLoadIndex));
        }

        IEnumerator LoadAsyncScene(int index)
        {
            Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
            Scene sceneToUnload = SceneManager.GetActiveScene();

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            // Espera até a cena ser carregada
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            //Quando chega aqui as duas scenes estão ativas, dá para fazer uma transição suave entre as duas nesse meio tempo

            if(sceneToUnload != null)
                SceneManager.UnloadSceneAsync(sceneToUnload); //Remove a scene anterior. Depois disso fica somente 1 scene ativa
        }
    }
}