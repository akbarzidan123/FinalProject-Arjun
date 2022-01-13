using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float headDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    
    private void Update() 
    {
        transform.position = new Vector3(Player.position.x + lookAhead, (Player.position.y - Player.position.y),
         transform.position.z); 
        lookAhead = Mathf.Lerp(lookAhead, (headDistance * Player.localScale.x), Time.deltaTime * cameraSpeed);   
    }
}
