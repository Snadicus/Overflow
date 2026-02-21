using UnityEngine;

public class MovingHands : MonoBehaviour
{
    [SerializeField] Rigidbody2D handsRB;
    [Space(20)]
    [SerializeField] float moveSpeed = 1;

    void Start()
    {
        handsRB.linearVelocity += Vector2.up * moveSpeed;
    }
}
