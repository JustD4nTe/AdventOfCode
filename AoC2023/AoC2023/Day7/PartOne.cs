using AoC.Shared;

namespace AoC2023.Day7;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var hands = File.ReadAllLines(Input)
                        .Select(x => x.Split(" "))
                        .Select(x => new Hand(x[0], x[1]))
                        .ToArray();

        var temp = hands.Order(new HandComparer()).ToArray();

        var totalWinnings = 0;

        for (var i = 0; i < temp.Length; i++)
            totalWinnings += (i + 1) * temp[i].Bid;

        return totalWinnings;
    }

    private enum HandType
    {
        FiveOfKind = 7,
        FourOfKind = 6,
        FullHouse = 5,
        ThreeOfKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1
    }

    private class Hand
    {
        public readonly char[] Cards;
        public readonly HandType HandType;
        public readonly int Bid;

        public Hand(string cards, string bid)
        {
            Cards = cards.ToCharArray();

            HandType = GetHandType();

            Bid = int.Parse(bid);
        }

        private HandType GetHandType()
        {
            var cardCounter = new Dictionary<char, int>();

            foreach (var card in Cards)
            {
                if (cardCounter.TryGetValue(card, out var cardCount))
                    cardCounter[card]++;
                else
                    cardCounter[card] = 1;
            }

            return cardCounter.Keys.Count switch
            {
                1 => HandType.FiveOfKind,
                2 when cardCounter.Values.Any(x => x == 4) => HandType.FourOfKind,
                2 when cardCounter.Values.Any(x => x == 3) => HandType.FullHouse,
                3 when cardCounter.Values.Any(x => x == 3) => HandType.ThreeOfKind,
                3 when cardCounter.Values.Count(x => x == 2) == 2 => HandType.TwoPair,
                4 when cardCounter.Values.Any(x => x == 2) => HandType.OnePair,
                5 => HandType.HighCard,
                _ => throw new Exception("Could not find hand type")
            };
        }
    }

    private class HandComparer : IComparer<Hand>
    {
        private const string CardStrength = "23456789TJQKA";

        public int Compare(Hand? x, Hand? y)
        {
            if (x!.HandType != y!.HandType)
                return x!.HandType.CompareTo(y!.HandType);

            for (var i = 0; i < 5; i++)
            {
                if (CardStrength.IndexOf(x!.Cards[i]) > CardStrength.IndexOf(y!.Cards[i]))
                    return 1;
                if (CardStrength.IndexOf(x!.Cards[i]) < CardStrength.IndexOf(y!.Cards[i]))
                    return -1;
            }

            return 0;
        }
    }
}