using System;
using System.Collections.Generic;
using System.IO;
using GazeusGamesEtapaTeste.Input;
using GazeusGamesEtapaTeste.Data;
using Newtonsoft.Json;




namespace GazeusGamesEtapaTeste.Scene
{
    public class EndGame : IScene
    {
        const string path = @"\Data\Json.txt";

        Ranking ranking;
        List<string> rankingText;

        string scoreText;
        string rankingTitle;

        string FullPath { get => Directory.GetCurrentDirectory() + path; }

        public EndGame(int score)
        {
            rankingTitle = string.Empty;
            if (score > 0)
            {
                scoreText = $"Parabéns você fez: {score} {(score > 1 ? "pontos" : "ponto")}.";

                try
                {
                    string json = Data.Data.Open(FullPath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        ranking = JsonConvert.DeserializeObject<Ranking>(json);
                        bool wasAdd =
                            ranking.TryAddToRanking(new RankingItem(score));

                        if (wasAdd)
                        {
                            rankingTitle = $"Parabéns de novo, você entrou para o ranking";
                            SaveRanking();
                        }
                    }
                    else
                    {
                        CreateRaking();
                    }
                }
                catch
                {
                    CreateRaking();
                }


                rankingText = ranking.GetText();
            }
            else
            {
                scoreText = $"Não foi dessa vez :(.";
            }

            void CreateRaking()
            {
                ranking = new Ranking();
                for (int i = 0; i < 5; i++)
                {
                    ranking.TryAddToRanking(new RankingItem(0));
                }
                SaveRanking();
            }
        }

        void SaveRanking()
        {
            string json = JsonConvert.SerializeObject(ranking, Formatting.Indented);
            Data.Data.Save(FullPath, json);
        }

        public void Draw()
        {
            Console.Clear();
            Console.WriteLine($"{SceneManager.tapString}{scoreText}");
            Console.WriteLine($"{SceneManager.tapString}{rankingTitle}");
            if (rankingText != null)
            {
                Console.WriteLine($"{SceneManager.tapString}Ranking: ");
                foreach (string s in rankingText)
                {
                    Console.WriteLine($"{SceneManager.tapString}{s}");
                }
            }
            Console.WriteLine($"{SceneManager.tapString}Aperte {InputManager.StartButton} para voltar ao menu.");
        }

        public void Input(ConsoleKey key)
        {
            if (key == InputManager.StartButton)
            {
                SceneManager.Singleton.ChangeScene(new Menu());
            }

        }
    }
}
