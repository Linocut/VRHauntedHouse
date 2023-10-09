using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRig : MonoBehaviour
{
    [Header("Controllers")]
    public Transform playerHead;
    public Transform leftController;
    public Transform rightController;

    [Header("Body Parts")]
    public CapsuleCollider bodyCollider;
    public ConfigurableJoint headJoint;
    public ConfigurableJoint leftHandJoint;
    public ConfigurableJoint rightHandJoint;

    [Header("Body Height Parameters")]
    public float bodyHeightMin = 0.5f;
    public float bodyHeightMax = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Body height
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height / 2, playerHead.localPosition.z);

        // Position updates
        Vector3 bodyRotation = new Vector3(bodyCollider.transform.eulerAngles.x, playerHead.eulerAngles.y, bodyCollider.transform.eulerAngles.z);
        bodyCollider.transform.rotation = Quaternion.Euler(bodyRotation);
        bodyCollider.transform.position = new Vector3(playerHead.position.x, bodyCollider.transform.position.y, playerHead.position.z);
    }
}
