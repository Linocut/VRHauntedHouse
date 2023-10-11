using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public float jitterTime = .1f;
    public Animator jumpscareAnimator;
    public float offset = 1f;
    public float moveSpeed = 20f;
    public float jitterAmount = 10;
    public float ogFOV;

    Transform playerCam;
    private Transform lookPos;
    public bool jumping = false;
    private bool finishedLoop = true;
    private Player player;
    private Vector3 ogPos;
    private Quaternion ogRot;

    // Start is called before the first frame update
    void Start()
    {
        lookPos = GameObject.Find("Main Camera").transform;
        playerCam = lookPos.parent;
    }

    // Update is called once per frame
    void Update()
    {

        if (jumping && finishedLoop)
        {
            StartCoroutine(JitterDelay(playerCam.eulerAngles.y));
        }
        else if (!jumping)
        {
            ogFOV = playerCam.transform.parent.eulerAngles.y;
        }
    }

    private IEnumerator JitterDelay(float currentRot)
    {
        finishedLoop = false;

        float targetRot = playerCam.eulerAngles.y;
        if (currentRot > ogFOV)
        {
            targetRot -= jitterAmount * 2;
        }
        else if (currentRot < ogFOV)
        {
            targetRot += jitterAmount * 2 ;
        }
        else if (currentRot == ogFOV)
        {
            targetRot -= jitterAmount;
        }

        playerCam.eulerAngles = new Vector3(playerCam.eulerAngles.x, targetRot);


        yield return new WaitForSeconds(jitterTime);
        finishedLoop = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XROrigin>())
        {
            player = other.transform.root.GetComponent<Player>();
            player.canMove = false;
            // Determine an appropriate distance in front of the camera
            Vector3 pos = lookPos.position + new Vector3(lookPos.forward.x, Mathf.Clamp(lookPos.forward.y, -.5f, -.25f), lookPos.forward.z).normalized * offset;

            // Get creature's original position and rotation
            ogPos = transform.position;
            ogRot = transform.rotation;

            // Moves creature in front of camera, but not instantly
            transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
            
            RunJumpscare();
        }
    }

    void RunJumpscare()
    {
        jumping = true;
        transform.LookAt(lookPos);
        jumpscareAnimator.SetTrigger("Jumpscare"); // Play creature's animation
    }

    public void ReturnToPosition()
    {
        playerCam.eulerAngles = new Vector3(0, 0);
        transform.position = ogPos;
        transform.rotation = ogRot;
        player.canMove = true;
        jumping = false;
    }
}
