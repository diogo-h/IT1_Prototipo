using UnityEngine;

namespace Lusofona
{
    public class WorldBehaviour : MonoBehaviour
    {
        [SerializeField] private Animator fadeScreen;
        //Chamado por um evento na animação
        public void OnAnimationComplete()
        {
            CustomSceneManager.Instance.ChangeLevel();
        }

        public void FadeScreen()
        {
            fadeScreen.SetTrigger("Fade");
        }
    }
}