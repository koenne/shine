using UnityEngine;

public class enemyGroundCheck : MonoBehaviour
{
    public EnemyScript EnemyScript;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spikes"))
        {
            EnemyScript.noGround();
        }
    }
}
