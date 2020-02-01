using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField]
    Transform m_SpawnPoint;
    
    [SerializeField]
    GameObject m_CubePrefab;

    public void SpawnPrefab()
    {
        Instantiate(m_CubePrefab, m_SpawnPoint.position, m_SpawnPoint.rotation);
    }
}
