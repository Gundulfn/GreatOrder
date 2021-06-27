using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static Vector3 targetPos = Vector3.one;

    public static void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }

    public static void Reset()
    {
        targetPos = Vector3.one;
    }

    void Update()
    {
        if(targetPos != Vector3.one)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5 * Time.deltaTime);
        }
    }
}