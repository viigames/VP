using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController1 playerController;
    private PlayerController2 playerController2;
    private Vector3 playerPosition;
    private float distanceToMoveX;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController1>();
        playerController2 = FindObjectOfType<PlayerController2>();
        playerPosition = playerController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMoveX = playerController.transform.position.x - playerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y , transform.position.z);
        playerPosition = playerController.transform.position;
    }
}
