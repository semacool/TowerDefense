using UnityEngine;
using UnityEngine.UI;

public class InfoClick : MonoBehaviour
{
    public TowerBase SelectedTower;
    Text Damage;
    Text Cost;
    Text AttackSpeed;
    Text Range;
    Text Upgrade;
    Text Sale;

    void Start()
    {
        Damage = transform.Find("Damage")?.gameObject.GetComponent<Text>();
        Cost = transform.Find("Сost")?.gameObject.GetComponent<Text>();
        AttackSpeed = transform.Find("AttackSpeed")?.gameObject.GetComponent<Text>();
        Range = transform.Find("Range")?.gameObject.GetComponent<Text>();
        Upgrade = transform.Find("Upgrade")?.transform.Find("Text").gameObject.GetComponent<Text>();
        Sale = transform.Find("Sale")?.transform.Find("Text").gameObject.GetComponent<Text>();
    }
    
    public void ShowInfo(TowerBase info)
    {
        SelectedTower = info;
        if (Cost != null) Cost.text = Util.ChangeText(Cost.text, info.gameObject.GetComponent<ShopItem>().Cost);
        if (Damage != null) Damage.text = Util.ChangeText(Damage.text, info.damage.ToString("##.##"));
        if (AttackSpeed != null) AttackSpeed.text = Util.ChangeText(AttackSpeed.text, info.attackSpeed.ToString("##.##"));
        if (Range != null) Range.text = Util.ChangeText(Range.text, info.Range.ToString("##.##"));
        if (Upgrade != null) Upgrade.text = Util.ChangeText(Upgrade.text, info.UpgradeCost.ToString("##.##"));
        if (Sale != null) Sale.text = Util.ChangeText(Sale.text, info.Sale.ToString("##.##"));
    }
}
