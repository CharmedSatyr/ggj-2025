using UnityEngine;


public class Victory : MonoBehaviour
{
    [SerializeField]
    AudioClip victoryAudio;

    public delegate void VictoryEvent();
    public static event VictoryEvent PlayerVictory;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Player"))
        {
            return;
        }

        PlayerVictory.Invoke();
    }
}
