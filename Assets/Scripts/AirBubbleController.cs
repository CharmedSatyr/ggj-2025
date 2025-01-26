using UnityEngine;

public class AirBubbleController : MonoBehaviour
{
    public delegate void CollectionEvent();
    public static event CollectionEvent CollectedAirBubble;

    public static void EmitCollectionEvent()
    {
        CollectedAirBubble.Invoke();
    }
}
