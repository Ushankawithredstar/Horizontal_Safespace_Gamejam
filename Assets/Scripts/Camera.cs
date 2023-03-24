using UnityEngine;

public class Camera : MonoBehaviour
{
    /*
     *  UNUSED.
     */

    [SerializeField] private Transform player;
    private Vector3 tempPos;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    private void Awake() 
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (player == null)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
