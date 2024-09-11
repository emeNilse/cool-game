using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;
    [SerializeField] Transform swordParent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f); //so that knife has movement at start of game and if player doesn't move
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
        //SwordRotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); // last moved x
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); //last moved y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector); //while moving
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Rotation(1.0f));
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    //void SwordRotate()
    //{
      //swordParent.Rotate(-Vector3.forward, 360 * Time.deltaTime);
      
    //}

    IEnumerator Rotation(float duration)
    {
        //float startRotation = swordParent.eulerAngles.z;
        Vector3 startRotation = swordParent.eulerAngles;
        
        float endRotation = startRotation.z + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation.z, endRotation, t / duration) % 360.0f;
            swordParent.eulerAngles = new Vector3(startRotation.x, startRotation.y, zRotation);
            yield return null;
        }
        swordParent.eulerAngles = startRotation;

    }
}
