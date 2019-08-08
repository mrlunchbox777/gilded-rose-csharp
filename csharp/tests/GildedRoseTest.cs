using System.Reflection;
using Xunit;
using System.Collections.Generic;

namespace GildedRose.csharp
{
    public class GildedRoseTest
    {
        [Theory]
        // (name, sellIn, quality, expectedSellIn, expectedQuality)

        // generic
        [InlineData("foo", 0, 0, -1, 0)]
        [InlineData("foo", 10, 10, 9, 9)]
        [InlineData("foo", 50, 50, 49, 49)]
        [InlineData("foo", 80, 80, 79, 79)] // this is one I'd ask the client about, but it's "fair" according to the prompt (except maybe invalid data)
        [InlineData("foo", 8, 10, 7, 9)]
        [InlineData("foo", 4, 10, 3, 9)]
        [InlineData("foo", 1, 10, 0, 9)]
        [InlineData("foo", 0, 10, -1, 8)]

        // Sulfuras, Hand of Ragnaros
        // technically all of these where the quality isn't 80 are invalid data (legendaries should always be 80 according to the prompt)
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 0, 0, 0)]
        [InlineData("Sulfuras, Hand of Ragnaros", 10, 10, 10, 10)]
        [InlineData("Sulfuras, Hand of Ragnaros", 50, 50, 50, 50)]
        [InlineData("Sulfuras, Hand of Ragnaros", 80, 80, 80, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", 8, 10, 8, 10)]
        [InlineData("Sulfuras, Hand of Ragnaros", 4, 10, 4, 10)]
        [InlineData("Sulfuras, Hand of Ragnaros", 1, 10, 1, 10)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 10, 0, 10)]

        // Aged Brie
        [InlineData("Aged Brie", 0, 0, -1, 2)]
        [InlineData("Aged Brie", 10, 10, 9, 11)]
        [InlineData("Aged Brie", 50, 50, 49, 50)]
        [InlineData("Aged Brie", 80, 80, 79, 80)] // this is one I'd ask the client about, but it's "fair" according to the prompt (except maybe invalid data)
        [InlineData("Aged Brie", 8, 10, 7, 11)]
        [InlineData("Aged Brie", 4, 10, 3, 11)]
        [InlineData("Aged Brie", 1, 10, 0, 11)]
        [InlineData("Aged Brie", 0, 10, -1, 12)]

        // Backstage passes to a TAFKAL80ETC concert
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 0, -1, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 10, 9, 12)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 50, 50, 49, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 80, 80, 79, 80)] // this is one I'd ask the client about, but it's "fair" according to the prompt (except maybe invalid data)
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 8, 10, 7, 12)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 4, 10, 3, 13)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 10, 0, 13)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 10, -1, 0)]

        public void SingleItemTests(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(name, Items[0].Name);
            Assert.Equal(expectedSellIn, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}
