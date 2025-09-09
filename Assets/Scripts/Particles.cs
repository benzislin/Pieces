using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Play());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Play()
    {
        yield return new WaitForSeconds(3.5f);
        particles.Play();
        Destroy(gameObject, 1f);
        Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
    }
}
