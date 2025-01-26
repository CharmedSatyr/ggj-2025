using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {

        public delegate void PlayerDeathEvent();
        public static event PlayerDeathEvent PlayerDeathInstance;

        void OnEnable()
        {
            GameController.HazardCollision += Die;
        }

        void OnDisable()
        {
            GameController.HazardCollision -= Die;
        }

        void Die()
        {
            PlayerDeathInstance.Invoke();

            gameObject.SetActive(false);
        }
    }
}