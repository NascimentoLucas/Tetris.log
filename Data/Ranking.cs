using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeusGamesEtapaTeste.Data
{

    public class RankingItem
    {
        public int score;

        public RankingItem(int score)
        {
            this.score = score;
        }
    }


    public class Ranking
    {
        public RankingItem[] rankingItems = new RankingItem[5];

        public Ranking()
        {
            for (int i = 0; i < rankingItems.Length; i++)
            {
                rankingItems[i] = new RankingItem(0);
            }
        }

        internal bool TryAddToRanking(RankingItem rankingItem)
        {
            SortArray();

            for (int i = rankingItems.Length - 1; i >= 0; i--)
            {
                if (rankingItem.score > rankingItems[i].score)
                {
                    rankingItems[i] = rankingItem;

                    SortArray();
                    return true;
                }
            }

            return false;
        }

        private void SortArray()
        {
            RankingItem[] SortedList = rankingItems.OrderByDescending(o => o.score).ToArray();
            rankingItems = SortedList;
        }

        public List<string> GetText()
        {
            List<string> s = new List<string>();

            for (int i = 0; i < rankingItems.Length; i++)
            {
                s.Add($"{i + 1}º" +
                    $" com: {rankingItems[i].score}\n{Scene.SceneManager.tapString}");
            }

            return s;
        }
    }
}
