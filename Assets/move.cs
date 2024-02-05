using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public float speed = 75.0f;
    public float waterSpeed = 25.0f;
    private float initialSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSpeed = speed; // Save the initial speed
    }

    void Update()
    {
        // Move the character forward continuously
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            speed = waterSpeed; // Slow down in water
        }
        else if (other.CompareTag("coin"))
        {
            other.gameObject.SetActive(false); // Deactivate coin
            StartCoroutine(ReactivateCoin(other.gameObject)); // Start the coroutine to reactivate the coin
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            speed = initialSpeed; // Return to initial speed
        }
    }

    IEnumerator ReactivateCoin(GameObject coin)
    {
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        coin.SetActive(true); // Reactivate the coin
    }
}
