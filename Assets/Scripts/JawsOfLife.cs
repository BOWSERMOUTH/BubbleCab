using UnityEngine;

public class JawsOfLife : MonoBehaviour
{
    Vector2 mousePos;
    Vector3 screenPos;

    void Update()
    {
        mousePos = Input.mousePosition;
        screenPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z)
        );
        var currentRot = transform.eulerAngles;
        // rotate around Z; the -90 is because the object is oriented upward.. 
        // if the object points to the right when at a zero rotation, take that away
        currentRot.z = Mathf.Atan2(
            (screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = currentRot;
    }
}