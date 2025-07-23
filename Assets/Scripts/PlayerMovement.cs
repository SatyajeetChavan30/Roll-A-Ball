using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private int count;
    public float speed = 5;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        winTextObject.SetActive(false);
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count > 4)
            winTextObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("YelloThingy"))
        {
            count = count + 1;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }
}