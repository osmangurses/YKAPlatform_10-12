using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 rayPosition;
    public float rayLenght,enemySpeed;
    public int movementRotation=0;

    private void Update()
    {
        transform.position += Vector3.right * enemySpeed * movementRotation * Time.deltaTime;

        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + rayPosition, Vector3.right, rayLenght);
        Debug.DrawRay(transform.position + rayPosition, Vector3.right * rayLenght, Color.red);

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - rayPosition, Vector3.left, rayLenght);
        Debug.DrawRay(transform.position - rayPosition, Vector3.left * rayLenght, Color.red);


        if (hit1.collider != null && hit1.collider.gameObject.tag == "Player")
        {
            movementRotation = 1;
        }
        else if (hit2.collider != null && hit2.collider.gameObject.tag == "Player")
        {
            movementRotation = -1;
        }
        else
        {
            movementRotation = 0;
        }
    }
}
