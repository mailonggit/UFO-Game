using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;
    private Rigidbody2D rb2d;
    public Text countText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        displayCountText();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D gold)
    {
        if (gold.gameObject.CompareTag("PickUp"))
        {
            gold.gameObject.SetActive(false);
            count++;
            displayCountText();
        }
    }
    void displayCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count > 6)
        {
            winText.text = "You Win!";
        }
    }
}
