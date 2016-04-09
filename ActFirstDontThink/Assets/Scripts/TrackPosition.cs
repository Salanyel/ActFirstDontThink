using UnityEngine;
using System.Collections;

public class TrackPosition : MonoBehaviour {

    public Transform target;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
            this.transform.position = target.transform.position + offset;
	}
}
