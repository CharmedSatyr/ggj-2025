using UnityEngine;

public class Controller : MonoBehaviour
{
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
        print("Player pops!");
        gameObject.SetActive(false);
    }
}
