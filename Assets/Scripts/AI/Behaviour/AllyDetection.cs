using UnityEngine;

public class AllyDetection : MonoBehaviour 
{
    public LayerMask LayerMask;

    private Vector2 detectDirection;

    private bool allyNearby = false;

    private void Update() 
    {

    }

    private void CheckAlly() 
    {
        Ray2D ray = new Ray2D(transform.position.ToVector2(),detectDirection);

    }
}
