using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite beforeReachedSprite;
    public Sprite afterReachedSprite;
    private SpriteRenderer checkPointSpriteRenderer;
    public bool checkPointReached;
    // Start is called before the first frame update
    void Start()
    {
        checkPointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")// what happens when a player falls down
        {
            checkPointSpriteRenderer.sprite = afterReachedSprite;
            checkPointReached = true;
        }
       
    

    }
}
