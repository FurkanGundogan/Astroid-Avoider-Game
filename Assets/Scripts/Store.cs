using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Store : MonoBehaviour
{
    public const string upgradeShipId="ShipUpgraded";
    public const string upgradeName="com.furu.astroidavoider.upgradeship";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPurchaseComplete(Product p){
        if(p.definition.id==upgradeName){
            PlayerPrefs.SetInt(upgradeShipId,1);
        }
        
    }
    public void onPurchaseFailed(Product p,PurchaseFailureReason reason){
        PlayerPrefs.SetInt(upgradeShipId,0);
        Debug.LogWarning($"Failed to purchase prodcut {p.definition.id} reason {reason}");
    }
}
