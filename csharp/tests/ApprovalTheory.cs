using System.Reflection;
using Xunit;
using System.Collections.Generic;

namespace GildedRose.csharp
{
    public class ApprovalTheory
    {
        [Theory]
        // (name, sellIn, quality, expectedSellIn, expectedQuality)

        // day 1
        [InlineData("+5 Dexterity Vest", 10, 20, 9, 19)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 49, 9, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 49, 4, 50)]
        [InlineData("Conjured Mana Cake", 3, 6, 2, 4)]

        // day 2
        [InlineData("+5 Dexterity Vest", 9, 19, 8, 18)]
        [InlineData("Aged Brie", 1, 1, 0, 2)]
        [InlineData("Elixir of the Mongoose", 4, 6, 3, 5)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 14, 21, 13, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 9, 50, 8, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 4, 50, 3, 50)]
        [InlineData("Conjured Mana Cake", 2, 4, 1, 2)]

        // day 3
        [InlineData("+5 Dexterity Vest", 8, 18, 7 ,17)]
        [InlineData("Aged Brie", 0, 2, -1, 4)]
        [InlineData("Elixir of the Mongoose", 3, 5, 2, 4)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 13, 22, 12, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 8, 50, 7, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 50, 2, 50)]
        [InlineData("Conjured Mana Cake", 1, 2, 0, 0)]

        // day 4
        [InlineData("+5 Dexterity Vest", 7 ,17, 6, 16)]
        [InlineData("Aged Brie", -1, 4, -2, 6)]
        [InlineData("Elixir of the Mongoose", 2, 4, 1, 3)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 12, 23, 11, 24)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 7, 50, 6, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 50, 1, 50)]
        [InlineData("Conjured Mana Cake", 0, 0, -1, 0)]

        // day 5
        [InlineData("+5 Dexterity Vest", 6, 16, 5, 15)]
        [InlineData("Aged Brie", -2, 6, -3, 8)]
        [InlineData("Elixir of the Mongoose", 1, 3, 0, 2)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 24, 10, 25)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 50, 5, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 50, 0, 50)]
        [InlineData("Conjured Mana Cake", -1, 0, -2, 0)]

        // day 6
        [InlineData("+5 Dexterity Vest", 5, 15, 4, 14)]
        [InlineData("Aged Brie", -3, 8, -4, 10)]
        [InlineData("Elixir of the Mongoose", 0, 2, -1, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 25, 9, 27)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 50, 4, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 50, -1, 0)]
        [InlineData("Conjured Mana Cake", -2, 0, -3, 0)]

        // day 7
        [InlineData("+5 Dexterity Vest", 4, 14, 3, 13)]
        [InlineData("Aged Brie", -4, 10, -5, 12)]
        [InlineData("Elixir of the Mongoose", -1, 0, -2, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 9, 27, 8, 29)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", 4, 50, 3, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 0, -2, 0)]
        [InlineData("Conjured Mana Cake", -3, 0, -4, 0)]

        // day 8
        [InlineData("+5 Dexterity Vest", 3, 13, 2, 12)]
        [InlineData("Aged Brie", -5, 12, -6, 14)]
        [InlineData("Elixir of the Mongoose", -2, 0, -3, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 8, 29, 7, 31)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 50, 2, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -2, 0, -3, 0)]
        [InlineData("Conjured Mana Cake", -4, 0, -5, 0)]

        // day 9
        [InlineData("+5 Dexterity Vest", 2, 12, 1, 11)]
        [InlineData("Aged Brie", -6, 14, -7, 16)]
        [InlineData("Elixir of the Mongoose", -3, 0, -4, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 7, 31, 6, 33)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 50, 1, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -3, 0, -4, 0)]
        [InlineData("Conjured Mana Cake", -5, 0, -6, 0)]

        // day 10
        [InlineData("+5 Dexterity Vest", 1, 11, 0, 10)]
        [InlineData("Aged Brie", -7, 16, -8, 18)]
        [InlineData("Elixir of the Mongoose", -4, 0, -5, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 33, 5, 35)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 50, 0, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -4, 0, -5, 0)]
        [InlineData("Conjured Mana Cake", -6, 0, -7, 0)]

        // day 11
        [InlineData("+5 Dexterity Vest", 0, 10, -1, 8)]
        [InlineData("Aged Brie", -8, 18, -9, 20)]
        [InlineData("Elixir of the Mongoose", -5, 0, -6, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 35, 4, 38)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 50, -1, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -5, 0, -6, 0)]
        [InlineData("Conjured Mana Cake", -7, 0, -8, 0)]

        // day 12
        [InlineData("+5 Dexterity Vest", -1, 8, -2, 6)]
        [InlineData("Aged Brie", -9, 20, -10, 22)]
        [InlineData("Elixir of the Mongoose", -6, 0, -7, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 4, 38, 3, 41)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 0, -2, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -6, 0, -7, 0)]
        [InlineData("Conjured Mana Cake", -8, 0, -9, 0)]

        // day 13
        [InlineData("+5 Dexterity Vest", -2, 6, -3, 4)]
        [InlineData("Aged Brie", -10, 22, -11, 24)]
        [InlineData("Elixir of the Mongoose", -7, 0, -8, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 41, 2, 44)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -2, 0, -3, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -7, 0, -8, 0)]
        [InlineData("Conjured Mana Cake", -9, 0, -10, 0)]

        // day 14
        [InlineData("+5 Dexterity Vest", -3, 4, -4, 2)]
        [InlineData("Aged Brie", -11, 24, -12, 26)]
        [InlineData("Elixir of the Mongoose", -8, 0, -9, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 44, 1, 47)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -3, 0, -4, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -8, 0, -9, 0)]
        [InlineData("Conjured Mana Cake", -10, 0, -11, 0)]

        // day 15
        [InlineData("+5 Dexterity Vest", -4, 2, -5, 0)]
        [InlineData("Aged Brie", -12, 26, -13, 28)]
        [InlineData("Elixir of the Mongoose", -9, 0, -10, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 47, 0, 50)]
        // duplicate
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -4, 0, -5, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -9, 0, -10, 0)]
        [InlineData("Conjured Mana Cake", -11, 0, -12, 0)]

        // day 16
        [InlineData("+5 Dexterity Vest", -5, 0, -6, 0)]
        [InlineData("Aged Brie", -13, 28, -14, 30)]
        [InlineData("Elixir of the Mongoose", -10, 0, -11, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 50, -1, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -5, 0, -6, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -10, 0, -11, 0)]
        [InlineData("Conjured Mana Cake", -12, 0, -13, 0)]

        // day 17
        [InlineData("+5 Dexterity Vest", -6, 0, -7, 0)]
        [InlineData("Aged Brie", -14, 30, -15, 32)]
        [InlineData("Elixir of the Mongoose", -11, 0, -12, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -1, 0, -2, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -6, 0, -7, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -11, 0, -12, 0)]
        [InlineData("Conjured Mana Cake", -13, 0, -14, 0)]

        // day 18
        [InlineData("+5 Dexterity Vest", -7, 0, -8, 0)]
        [InlineData("Aged Brie", -15, 32, -16, 34)]
        [InlineData("Elixir of the Mongoose", -12, 0, -13, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -2, 0, -3, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -7, 0, -8, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -12, 0, -13, 0)]
        [InlineData("Conjured Mana Cake", -14, 0, -15, 0)]

        // day 19
        [InlineData("+5 Dexterity Vest", -8, 0, -9, 0)]
        [InlineData("Aged Brie", -16, 34, -17, 36)]
        [InlineData("Elixir of the Mongoose", -13, 0, -14, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -3, 0, -4, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -8, 0, -9, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -13, 0, -14, 0)]
        [InlineData("Conjured Mana Cake", -15, 0, -16, 0)]

        // day 20
        [InlineData("+5 Dexterity Vest", -9, 0, -10, 0)]
        [InlineData("Aged Brie", -17, 36, -18, 38)]
        [InlineData("Elixir of the Mongoose", -14, 0, -15, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -4, 0, -5, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -9, 0, -10, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -14, 0, -15, 0)]
        [InlineData("Conjured Mana Cake", -16, 0, -17, 0)]

        // day 21
        [InlineData("+5 Dexterity Vest", -10, 0, -11, 0)]
        [InlineData("Aged Brie", -18, 38, -19, 40)]
        [InlineData("Elixir of the Mongoose", -15, 0, -16, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -5, 0, -6, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -10, 0, -11, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -15, 0, -16, 0)]
        [InlineData("Conjured Mana Cake", -17, 0, -18, 0)]

        // day 22
        [InlineData("+5 Dexterity Vest", -11, 0, -12, 0)]
        [InlineData("Aged Brie", -19, 40, -20, 42)]
        [InlineData("Elixir of the Mongoose", -16, 0, -17, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -6, 0, -7, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -11, 0, -12, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -16, 0, -17, 0)]
        [InlineData("Conjured Mana Cake", -18, 0, -19, 0)]

        // day 23
        [InlineData("+5 Dexterity Vest", -12, 0, -13, 0)]
        [InlineData("Aged Brie", -20, 42, -21, 44)]
        [InlineData("Elixir of the Mongoose", -17, 0, -18, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -7, 0, -8, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -12, 0, -13, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -17, 0, -18, 0)]
        [InlineData("Conjured Mana Cake", -19, 0, -20, 0)]

        // day 24
        [InlineData("+5 Dexterity Vest", -13, 0, -14, 0)]
        [InlineData("Aged Brie", -21, 44, -22, 46)]
        [InlineData("Elixir of the Mongoose", -18, 0, -19, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -8, 0, -9, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -13, 0, -14, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -18, 0, -19, 0)]
        [InlineData("Conjured Mana Cake", -20, 0, -21, 0)]

        // day 25
        [InlineData("+5 Dexterity Vest", -14, 0, -15, 0)]
        [InlineData("Aged Brie", -22, 46, -23, 48)]
        [InlineData("Elixir of the Mongoose", -19, 0, -20, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -9, 0, -10, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -14, 0, -15, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -19, 0, -20, 0)]
        [InlineData("Conjured Mana Cake", -21, 0, -22, 0)]

        // day 26
        [InlineData("+5 Dexterity Vest", -15, 0, -16, 0)]
        [InlineData("Aged Brie", -23, 48, -24, 50)]
        [InlineData("Elixir of the Mongoose", -20, 0, -21, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -10, 0, -11, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -15, 0, -16, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -20, 0, -21, 0)]
        [InlineData("Conjured Mana Cake", -22, 0, -23, 0)]

        // day 27
        [InlineData("+5 Dexterity Vest", -16, 0, -17, 0)]
        [InlineData("Aged Brie", -24, 50, -25, 50)]
        [InlineData("Elixir of the Mongoose", -21, 0, -22, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -11, 0, -12, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -16, 0, -17, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -21, 0, -22, 0)]
        [InlineData("Conjured Mana Cake", -23, 0, -24, 0)]

        // day 28
        [InlineData("+5 Dexterity Vest", -17, 0, -18, 0)]
        [InlineData("Aged Brie", -25, 50, -26, 50)]
        [InlineData("Elixir of the Mongoose", -22, 0, -23, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -12, 0, -13, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -17, 0, -18, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -22, 0, -23, 0)]
        [InlineData("Conjured Mana Cake", -24, 0, -25, 0)]

        // day 29
        [InlineData("+5 Dexterity Vest", -18, 0, -19, 0)]
        [InlineData("Aged Brie", -26, 50, -27, 50)]
        [InlineData("Elixir of the Mongoose", -23, 0, -24, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -13, 0, -14, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -18, 0, -19, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -23, 0, -24, 0)]
        [InlineData("Conjured Mana Cake", -25, 0, -26, 0)]

        // day 30
        [InlineData("+5 Dexterity Vest", -19, 0, -20, 0)]
        [InlineData("Aged Brie", -27, 50, -28, 50)]
        [InlineData("Elixir of the Mongoose", -24, 0, -25, 0)]
        // duplicate
        // [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        // [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, -1, 80)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -14, 0, -15, 0)]
        // [InlineData("Backstage passes to a TAFKAL80ETC concert", -19, 0, -20, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", -24, 0, -25, 0)]
        [InlineData("Conjured Mana Cake", -26, 0, -27, 0)]

        public void ApprovalTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
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
