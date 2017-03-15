using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public float speedX;
	public float jumpSpeedY;

	/* check */
	bool facingRight, Jumping;
	float speed;

	Animator anim;
	Rigidbody2D rb;

	public static GameMaster gm;

	// Use this for initialization
	void Start () {
		if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		facingRight = true;
	}

	private void Update()
	{
		MovePlayer(speed);

		if(Input)
	}

	 public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 2;

    public IEnumerator RespawnPlayer ()
    {
        Debug.Log("TODO: Add waiting for spawn sound");
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("TODO: Add spawn particles");
    }

    public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
