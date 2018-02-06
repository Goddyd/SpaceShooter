using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;
    public float fireRate;
    public Boundary boundary;
    public Transform BoltSpawn;
    public GameObject Bolt;
    private Rigidbody rb;
    private float nextFire = 0.0f;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire){
            GameObject ballet = Instantiate(Bolt, BoltSpawn.position, BoltSpawn.rotation)as GameObject;
            nextFire = Time.time + fireRate;
            this.GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveVec = new Vector3(moveHorizontal, 1.0f, moveVertical);
        rb.velocity = moveVec * moveSpeed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                1.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, moveVec.x * -rotateSpeed);
	}
}
