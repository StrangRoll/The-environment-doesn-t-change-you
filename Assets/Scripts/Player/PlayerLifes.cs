using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerLifes : MonoBehaviour
{
    [SerializeField] private int lifes;
    [SerializeField] private LifesEvent lifeTextEvent;
    private bool isInvulnerability = false;
    void Start()
    {
        lifeTextEvent?.Invoke($"HP: {lifes}");
    }

    public void Hit()
    {
        if (!isInvulnerability)
        {
            isInvulnerability = true;
            StartCoroutine(invulnerabilityTimer());
            lifes--;
            lifeTextEvent?.Invoke($"HP: {lifes}");
            if (lifes <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator invulnerabilityTimer()
    {
        yield return new WaitForSeconds(0.2f);
        isInvulnerability = false;
    }
}

[System.Serializable]
public class LifesEvent : UnityEvent<string> { }
