using UnityEngine;

namespace Lusofona
{
    public class WorldBehaviour : MonoBehaviour
    {
        //Chamado por um evento na animação
        public void OnAnimationComplete()
        {
            CustomSceneManager.Instance.ChangeLevel();
        }
    }
}