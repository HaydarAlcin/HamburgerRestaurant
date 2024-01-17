using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    #region Serialize Variables
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject knifeTransform;
    #endregion

    #region Private Variables
    private Inventory inventory;
    private bool isRelax;
    #endregion


    private void Start()
    {
        inventory = GetComponent<Inventory>();
        AnimationSignals.Instance.onTakeItemAnimationEvent += OnTakeItemAnimationEvent;
        CoreGameSignals.Instance.OnItemSliced += OnSlicedItem;
        isRelax = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& isRelax)
        {
            //item alma koyma animasyonu
            DoAction();
            isRelax = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.E) && isRelax)
        {
            //Animasyon devreye girer
            DoSlice();
            isRelax = false;
        }
    }


    private void DoAction()
    {
        anim.SetTrigger("Take");
        
    }

    private void DoSlice()
    {
        anim.SetTrigger("Slice");
        knifeTransform.SetActive(true);
    }

    private void OnTakeItemAnimationEvent()
    {
        Ray ray = new Ray(transform.position + Vector3.up / 2, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            if (hit.collider.TryGetComponent<ItemBox>(out ItemBox itemBox))
            {
                inventory.TakeItem(itemBox.GetItem());
            }

            else if (hit.collider.TryGetComponent<IPutItemFull>(out IPutItemFull itemPutBox))
            {
                if (inventory.GetCurrentItem() == ItemType.NONE)
                {
                    inventory.TakeItem(itemPutBox.GetCurrentItem());
                    itemPutBox.ClearItemType();   
                    return;
                }
                bool status =  itemPutBox.PutItem(inventory.GetCurrentItem());
                if (status)
                {
                    inventory.PutItem();
                    inventory.ClearHand();
                }
            }

            else if (hit.collider.TryGetComponent<ServiceController>(out ServiceController service))
            {
                if (inventory.GetCurrentItem()==ItemType.BURGER)
                {
                    inventory.PutItem();
                    inventory.ClearHand();
                    service.ServeTheBurger();
                }
            }
        }
    }


    //Animasyon eventin tetiklediði actiona baðlý slice fonksiyonu
    private void OnSlicedItem()
    {
        Ray ray = new Ray(transform.position + Vector3.up / 2, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            
            if (hit.collider.TryGetComponent<SliceBoard>(out SliceBoard sliceBoard))
            {
                sliceBoard.ProcessItem();
            }
        }
        knifeTransform.SetActive(false);
    }

    public void SetRelax(bool relax)
    {
        isRelax = relax;
    }
}
