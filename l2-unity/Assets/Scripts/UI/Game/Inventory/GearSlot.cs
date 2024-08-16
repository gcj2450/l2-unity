using UnityEngine.UIElements;

public class GearSlot : InventorySlot
{
    public GearSlot(int position, VisualElement slotElement, InventoryGearTab tab) : base(position, slotElement, tab, true) {
    }
    
    protected override void HandleRightClick() {
        UseItem();
    }

    public override void UseItem() {
        if(!_empty) {
            GameClient.Instance.ClientPacketHandler.UnEquipItem(_position);
        }
    }
}
