using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [Header("Things to set")]
    public Animator jumpscareAnimator;
    public AudioSource jumpscareAudio;
    public float jitterTime = .1f;
    public float offset = 1f;
    public float moveSpeed = 20f;
    public float jitterAmount = 10;

    Transform playerCam;
    private Transform lookPos;
    public bool jumping = false;
    private bool finishedLoop = true;
    private Player player;
    private Vector3 ogPos;
    private Quaternion ogRot;
    private Vector3 ogCamPos;

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
            StartCoroutine(JitterDelay(playerCam.position.y));
        }
        else if (!jumping)
        {
            ogCamPos = playerCam.transform.parent.transform.position;
        }
    }

    private IEnumerator JitterDelay(float currentRot)
    {
        finishedLoop = false;
        float degree = Random.Range(-jitterAmount, jitterAmount); // Determines a random value between two values to jitter the camera
        playerCam.position = new Vector3(ogCamPos.x, ogCamPos.y, ogCamPos.z + degree); // Moves the camera according to 'degree' value

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
            Vector3 pos = lookPos.position + new Vector3(lookPos.forward.x, -lookPos.position.y + transform.position.y, lookPos.forward.z).normalized * offset;

            // Get creature's original position and rotation
            ogPos = transform.position;
            ogRot = transform.rotation;

            // Moves creature in front of camera, but not instantly
            transform.position = pos;
            
            RunJumpscare();
        }
    }

    void RunJumpscare()
    {
        if (jumpscareAudio)
        {
            jumpscareAudio.Play();
        }
        jumping = true;
        transform.LookAt(lookPos.Find("Target"));
        jumpscareAnimator.SetTrigger("Jumpscare"); // Play creature's animation
    }

    public void ReturnToPosition()
    {
        playerCam.transform.position = ogCamPos;
        transform.position = ogPos;
        transform.rotation = ogRot;
        player.canMove = true;
        jumping = false;
    }
}
