using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [serializeField] private Rigidbody2D rb;
    [serializeField] private Transform groundCheck;
    [serializeField] private LayerMask groundlayer;
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
