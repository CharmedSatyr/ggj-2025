using UnityEngine;



public class GameController : MonoBehaviour
{
    public enum CollisionType
    {
        AirBubble,
        Hazard
    }

    public delegate void CollisionEvent();
    public static event CollisionEvent CollectedAirBubble;
    public static event CollisionEvent HazardCollision;

    public static void EmitCollisionEvent(CollisionType type)
    {
        if (type == CollisionType.AirBubble)
        {
            CollectedAirBubble.Invoke();
        }

        if (type == CollisionType.Hazard)
        {
            HazardCollision.Invoke();
        }
    }
}
