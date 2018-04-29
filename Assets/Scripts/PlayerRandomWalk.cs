using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomWalk : MonoBehaviour {
    public float Speed;

    private Vector3 _Target;
    bool _Start;
	// Use this for initialization
	void Start () {
        RandomizeTarget();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, _Target, Speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _Target) < 1f) RandomizeTarget();
	}

    void RandomizeTarget()
    {
        _Target = new Vector3(Random.Range(-11.1f, 11.1f), Random.Range(-17.2f,- 9.71f), 13.1f);
    }
}
