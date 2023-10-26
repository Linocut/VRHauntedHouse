using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepMonster : MonoBehaviour
{
    public GameObject monster;
    public AudioSource monsterSteps;
    public bool isDone;

    private Coroutine monsterCoroutine;
    private int numberOfCoroutines; 

    void OnEnable()
    {
        // Get a reference to xr origin by finding the object with the tag "XROrigin"
        Transform xrOrigin = GameObject.FindGameObjectWithTag("XROrigin").transform;
        // Start the coroutine
        monsterCoroutine = StartCoroutine(ActivateMonsterCoroutine(xrOrigin));
    }

    void OnDisable()
    {
        // If the coroutine is running, stop it
        if (monsterCoroutine != null)
        {
            StopCoroutine(monsterCoroutine);
            monsterCoroutine = null;
        }
    }

    IEnumerator ActivateMonsterCoroutine(Transform xrOrigin)
    {
        // Set the monster object active
        monster.SetActive(true);

        // Play monster steps sound
        if (monsterSteps != null)
        {
            monsterSteps.Play();
        }

        float duration = 5f; // Duration for the movement
        float elapsedTime = 0f;

        Vector3 initialPosition = monster.transform.position;

        // Adjust the offset based on the number of times the coroutine has been called
        Vector3 offset = new Vector3(1f * numberOfCoroutines, 0f, 1f * numberOfCoroutines);

        Vector3 targetPosition = xrOrigin.position + offset;

        // Move the monster to the new position instantly
        monster.transform.position = targetPosition;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Increment the number of coroutines
        numberOfCoroutines++;

        // Set isDone to true when the coroutine is done
        isDone = true;
    }
}
