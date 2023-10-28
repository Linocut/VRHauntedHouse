using System.Collections;
using UnityEngine;

public class SleepMonster : MonoBehaviour
{
    public GameObject monster;
    public AudioSource monsterSteps;
    public AudioSource monsterScream;
    public string instructions;

    private Coroutine monsterCoroutine;
    private Transform mainCamera;
    private Vector3 originalPosition;
    public bool isDone;
   

    void OnEnable()
    {
        mainCamera = Camera.main.transform; // Assuming the main camera is tagged as "MainCamera"
        if (!isDone)
        {
            monster.SetActive(true);
            // Play monster steps sound
            if (monsterSteps != null)
            {
                monsterSteps.Play();
            }

            // Reset monster position and start the coroutine when the object is enabled
            originalPosition = new Vector3(0f, 0f, 1.8f);
            ResetMonsterPosition();
            monsterCoroutine = StartCoroutine(ActivateMonsterCoroutine(mainCamera));
        }
    }

    void OnDisable()
    {
        // If the coroutine is running, stop it
        if (monsterCoroutine != null)
        {
            StopCoroutine(monsterCoroutine);
            monsterCoroutine = null;
        }

        monster.SetActive(false);
    }

    IEnumerator ActivateMonsterCoroutine(Transform targetTransform)
    {
        if (SubtitleManager.instance != null)
        {
            SubtitleManager.instance.AddText("disappear", 0);
        }
        float elapsedTime = 0f;

        while (elapsedTime < 7.8f) // Run for 8 seconds
        {
            if (elapsedTime < 3f)
            {
                MoveMonster(0.08f);
            }
            else if (elapsedTime < 5.5f)
            {
                MoveMonster(0.2f);
            }
            else if (elapsedTime < 6f)
            {
                MoveMonster(0f);
                if (monsterSteps != null)
                {
                    monsterScream.Play();
                }
            }
            else
            {
                
                MoveMonster(2.5f);

                // Play another noise or perform other actions
                
            }

            yield return null;
            elapsedTime += Time.deltaTime;
        }

        isDone = true;
        monster.SetActive(false);
        if (SubtitleManager.instance != null)
        {
            SubtitleManager.instance.AddText(instructions);
        }
    }

    void MoveMonster(float speed)
    {
        Vector3 directionToTarget = (mainCamera.position - monster.transform.position).normalized;
        monster.transform.Translate(directionToTarget * speed * Time.deltaTime, Space.World);
    }

    void ResetMonsterPosition()
    {
        // Reset the monster to its original position (relative to the parent)
        monster.transform.position = monster.transform.parent.TransformPoint(originalPosition);
    }
}