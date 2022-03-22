using Behaviour;
using UnityEngine;

public class Ladder : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerBehaviour>();
        if (player == null) return;
        player.isOnLadder = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerBehaviour>();
        if (player == null) return;
        player.isOnLadder = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}