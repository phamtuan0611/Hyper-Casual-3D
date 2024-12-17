using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private CrowdSystem crowdSystem;

    [Header(" Setting ")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float roadWidth;

    [Header(" Control ")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();

        ManageControl();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 postition = transform.position;
            postition.x = clickedPlayerPosition.x + xScreenDifference;

            postition.x = Mathf.Clamp(postition.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());

            transform.position = postition;

            //transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;
        }
    }
}
