using System.Collections.Generic;
using System;

namespace GildedRose.csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private static readonly int maxQuality = 50;

        public void UpdateQuality() {
            foreach(var baseItem in this.Items) {
                var item = new WellDefinedItem(baseItem);
                item.UpdateTypes();
                int qualityChange = item.QualityChangeAmount;
                
                // if the net result is going to be over 50, don't add more than needed to get to 50
                if (qualityChange > 0 && baseItem.Quality + qualityChange >= maxQuality) {
                    qualityChange = Math.Max(maxQuality - item.Quality, 0);
                }
                
                // if the net result is going to be less than zero, don't subtract more than needed to get 0
                if (qualityChange < 0 && baseItem.Quality + qualityChange <= 0) {
                    qualityChange = -1 * Math.Max(baseItem.Quality, 0);
                }

                int sellInChange = item.SellInChangeAmount;

                baseItem.Quality += qualityChange;
                baseItem.SellIn += sellInChange;
            }
        }
    }
}
