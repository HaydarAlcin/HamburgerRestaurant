using System.Collections.Generic;
using UnityEngine;

public class EatingPlace : MonoBehaviour
{
    #region Singleton
    public static EatingPlace Instance;
    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }
    #endregion

    private List<GameObject> _emptyChairs=new List<GameObject>();
    private  List<GameObject> _fullChairs=new List<GameObject>();

    private void Start()
    {
        GameObject[] chairs = GameObject.FindGameObjectsWithTag("Chair");
        foreach (var item in chairs)
        {
            //item.EmptyChair();
            _emptyChairs.Add(item);
        }
    }
    public void EmptyChairIncreased(GameObject chair)
    {
        _emptyChairs.Add(chair);
        _fullChairs.Remove(chair);
    }

    public void EmptyChairDecreased(GameObject chair)
    {
        _emptyChairs.Remove(chair);
        _fullChairs.Add(chair);
    }

    public List<GameObject> GetEmptyChairs()
    {
        return _emptyChairs;
    }

}
