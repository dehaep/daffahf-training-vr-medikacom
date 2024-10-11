using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // The tag of the NPC clones
    public string npcTag = "NPC";
    public string objectTag = "Object";

    private void OnCollisionEnter(Collision collision)
    {
        DestroyNpc(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyNpc(other.gameObject);
    }

    private void DestroyNpc(GameObject collisionObject)
    {
        if (collisionObject.CompareTag(npcTag))
        {
            Destroy(collisionObject);
        }
        if (collisionObject.CompareTag(objectTag))
        {
            Destroy(collisionObject);
        }
    }
}