using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        if (TryGetComponent<WanderingAI>(out var behaviour))
        {
            behaviour.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        gameObject.transform.Rotate(-75f, 0f, 0f);

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
