using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    GameController gameController;

    void Start()
    {
        var gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, transform.rotation);
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
