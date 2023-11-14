using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{
    [SerializeField]
    private float destroyAfter = 5f;

    [SerializeField]
    private bool disableInstead = false;
    private void OnEnable()
    {
        StartCoroutine(DestroyParticle());
    }

    private IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(destroyAfter);

        if (disableInstead)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
