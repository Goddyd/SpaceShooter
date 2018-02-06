using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterControll : MonoBehaviour {
    public float tumble;
    public float speed;
    public int perScore = 10;
    public GameObject explosion;
    public GameObject playerExplosion;
    private Rigidbody rb;
    private GameController gamecontroller;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * speed;
        rb.angularVelocity = Random.insideUnitSphere * tumble;
        GameObject gamecontrollerObject = GameObject.FindWithTag("GameController");
        if (gamecontrollerObject != null) {
            gamecontroller = gamecontrollerObject.GetComponent<GameController>();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Instantiate(playerExplosion, this.transform.position, this.transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            return;
        }
        if (other.tag == "boundary") {
            Destroy(this.gameObject);
            return;
        }
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        gamecontroller.UpdateScore(perScore);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        
    }
    // Update is called once per frame
}
