using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform Player;

    private float offset;

    [SerializeField]
    private float cameraBaseHeight = -0.4f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = Player.transform.position.x;

        if(Player.transform.position.y <= cameraBaseHeight)
        {
            temp.y = cameraBaseHeight;
        }
        else
        {
            temp.y = Player.transform.position.y;
        }

        transform.position = temp;
    }

    /*[SerializeField]
    private GameObject player;       //Public variable to store a reference to the player game object
    
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }*/
}
