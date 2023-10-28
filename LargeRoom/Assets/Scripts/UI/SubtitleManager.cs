using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleManager : MonoBehaviour
{
    #region Singleton

    public static SubtitleManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of SubtitleManager found!");
            return;
        }
        instance = this;
    }

    #endregion

    [Header("Display")]
    [SerializeField] private Transform mainCam;
    public float maxAngleDistance = 50f;
    public float maxDistance = 5f;
    public float smoothSpeed = 5f;
    public float min = 0;
    public float max = 100f;
    public float offset = 5f;
    public float distanceOffset = .2f;
    public float moveSpeed = .015f;
    public float displayTime = 15f;

    bool alignWithPlayer = false;
    float currentYVelocity;


    [Header("Text")]
    [SerializeField] private Subtitles subtitles;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private GameObject visible;

    public float time = 1f;
    public string person = "";
    public string text = "";

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").transform;
    }

    private void LateUpdate()
    {
        Move();
        RotateX();
        RotateY();

        if (messageText.text.Equals(""))
        {
            messageText.text = "-";
            visible.SetActive(false);
        }
    }

    public void AddText(string message)
    {
        visible.SetActive(true);
        subtitles.AddWriter(messageText, message, time, true, -1);
    }

    public void AddText(string message, float timer)
    {
        visible.SetActive(true);
        subtitles.AddWriter(messageText, message, time, true, timer);
    }

    void Move()
    {
        Vector3 pos = mainCam.position + new Vector3(mainCam.forward.x, Mathf.Clamp(mainCam.forward.y, -.5f, -.25f), mainCam.forward.z).normalized * offset;

        float distance = (transform.position - pos).magnitude;
        if (distance > maxDistance)
        {
            alignWithPlayer = true;
        }

        if (alignWithPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);

            if ((transform.position - pos).magnitude < distanceOffset)
            {
                alignWithPlayer = false;
            }
        }
    }

    void RotateY()
    {
        float targetYRot = mainCam.eulerAngles.y;
        float currentYRot = transform.eulerAngles.y;
        float distance = Mathf.Abs(currentYRot - targetYRot);

        if (distance > maxAngleDistance)
        {
            alignWithPlayer = true;
        }

        if (alignWithPlayer)
        {
            float newAngle = Mathf.SmoothDampAngle(currentYRot, targetYRot, ref currentYVelocity, Time.deltaTime * smoothSpeed); // Slowly rotates panel
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, newAngle);
        }
    }

    private void RotateX()
    {
        float xAngle = mainCam.eulerAngles.x;
        xAngle = ClampAngle(xAngle, min, max);
        transform.eulerAngles = new Vector3(xAngle, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public float ClampAngle(float angle, float min, float max)
    {
        float start = (min + max) * 0.5f - 180;
        float floor = Mathf.FloorToInt((angle - start) / 360) * 360;
        return Mathf.Clamp(angle, min + floor, max + floor);
    }
}
