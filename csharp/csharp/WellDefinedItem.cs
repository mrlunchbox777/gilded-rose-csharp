namespace GildedRose.csharp
{
    public class WellDefinedItem : Item
    {
        public WellDefinedItem(Item sourceItem) {
            this.Name = sourceItem.Name;
            this.SellIn = sourceItem.SellIn;
            this.Quality = sourceItem.Quality;
        }
        public AgingType DefinedAgingType { get; private set; }
        public ItemType DefinedItemType { get; private set; }
        public bool IsConjured { get; private set; }

        private static readonly string _sulfuras = "sulfuras, hand of ragnaros";
        private static readonly string _brie = "aged brie";
        private static readonly string _concertTickets = "backstage passes to a tafkal80etc concert";
        private static readonly string _conjured = "conjured";

        public void UpdateTypes()
        {
            var loweredName = this.Name.ToLower();
            this.DefinedItemType = ItemType.Normal;
            this.DefinedAgingType = AgingType.Normal;

            // sulfuras
            if (loweredName.Contains(_sulfuras)) {
                this.DefinedItemType = ItemType.Legendary;
                if (!loweredName.Contains(_conjured)) {
                    this.DefinedAgingType = AgingType.NoAging;
                }
            }

            // brie
            if (loweredName.Contains(_brie)) {
                this.DefinedAgingType = AgingType.AgesWell;
            }

            // concert
            if (loweredName.Contains(_concertTickets)) {
                this.DefinedAgingType = AgingType.LimitedAgesWell;
            }

            // conjured
            if (loweredName.Contains(_conjured)) {
                IsConjured = true;
            }
        }

        public int SellInChangeAmount {
            get =>
                this.IsConjured || this.DefinedItemType == ItemType.Normal
                    ? -1
                    : 0;
        }

        public int QualityChangeAmount {
            get {
                int qualityChange;

                switch (this.DefinedAgingType) {
                    case AgingType.AgesWell:
                        qualityChange = 1;
                        break;
                    case AgingType.LimitedAgesWell:
                        if (SellIn >= 50) {
                            qualityChange = 0;
                        } else if (SellIn > 10) {
                            qualityChange = 1;
                        } else if (SellIn > 5) {
                            qualityChange = 2;
                        } else if (SellIn > 0) {
                            qualityChange = 3;
                        } else {
                            // return early because it always goes to 0 after the concert
                            return Quality > 0
                                ? -1 * Quality
                                : 0;
                        }
                        break;
                    case AgingType.NoAging:
                        qualityChange = 0;
                        break;
                    case AgingType.Normal:
                        goto default;
                    default:
                        qualityChange = -1;
                        break;
                }

                if (SellIn <= 0) {
                    qualityChange *= 2;
                }

                if (IsConjured) {
                    qualityChange *= 2;
                }

                return qualityChange;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + DefinedItemType + ", " + DefinedAgingType;
        }  
    }
}
