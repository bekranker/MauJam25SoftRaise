public interface IItem
{
    public bool objestIsTaken { get; set; }
    public ItemSO itemSettings { get; set; }
    public DragAndDrop itemDropData { get; set; }
    public float price { get; set; }



    void ItemTaken();
    void ItemSell();
   
    void DayPriceEventVoid();
    void NightPriceEventVoid();
}
