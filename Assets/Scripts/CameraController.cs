using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float xOffset = 7f;
    public float offSetSmoothingDelay;
    public Player mainPlayer;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainPlayer.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(mainPlayer.transform.position.x + xOffset, transform.position.y, transform.position.z); //player moving forward 
        }

        else
        {
            playerPosition = new Vector3(mainPlayer.transform.position.x - xOffset, transform.position.y, transform.position.z); //player moving backwrds 
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offSetSmoothingDelay * Time.deltaTime);
    }
}
