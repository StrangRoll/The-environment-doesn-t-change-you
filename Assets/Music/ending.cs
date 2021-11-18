using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    [SerializeField] private GameObject sound;
    public void Endmmm()
    { 
        StartCoroutine(Finally());
    }
    private IEnumerator Finally()
    {
        yield return new WaitForSeconds(6);
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSeconds(0.1f);
            sound.GetComponent<AudioSource>().volume -= 0.03f; 
        }
         sound.GetComponent<AudioSource>().Stop();
    }

}
