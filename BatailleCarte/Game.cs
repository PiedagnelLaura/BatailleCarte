using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleCarte
{
    class Game
    {
        private int _playerScore, _IAscore;
        private List<Card> _playerHand, _iaHand;
        private Dealer _dealer;
        public void StartGame()
        {
            _dealer = new Dealer();

            _playerHand = _dealer.RandomCardFromDeck(5);
            _iaHand = _dealer.RandomCardFromDeck(5);

            Turn();
        }

        private void Turn()
        {
            if (_playerHand.Count<=0)
            {
                EndGame();
                return;
            }
                
            var playerCard = PlayerTurn();
            var iaCard = IATurn();

            int comparator = playerCard.CompareTo(iaCard);

            if (comparator > 0)
            {
                Console.WriteLine("Le joueur à remporté la manche");
                _playerScore++;
            }
            else if (comparator < 0)
            {
                Console.WriteLine("L' IA à remporté la manche");
                _IAscore++;
            }
            else 
            {
                Console.WriteLine("La manche est nulle");
            }

            Console.ReadLine();
            _playerHand.Remove(playerCard);
            _iaHand.Remove(iaCard);

            if (_dealer.CanDeal)
            {
                _playerHand.Add(_dealer.RandomCardFromDeck());
                _iaHand.Add(_dealer.RandomCardFromDeck());
            }

            Console.Clear();
            Turn();
        }

        private Card PlayerTurn()
        {
            for (int i = 0; i < _playerHand.Count; i++)
            {
                Card card = _playerHand[i];
                card.ShowCard(i);
            }

            var input = int.Parse(Console.ReadKey().KeyChar.ToString());

            Console.Clear();

            if (input >=0 && input<_playerHand.Count)
            {
                var card = _playerHand[input];
                Console.Write("Vous venez de jouer le ");
                card.ShowCard();
                Console.ReadLine();

                return card;
            }
            else 
            {
                Console.WriteLine("L'input est incorrect, merci de recommencer");
                Console.ReadLine();
                PlayerTurn();
            }

            return null;
        }

        private Card IATurn()
        {
            _iaHand.Sort();
            var card = _iaHand[_iaHand.Count-1];
            Console.Write("Votre adversaire vient de jouer ");
            card.ShowCard();
            Console.ReadLine();

            return card;
        }

        private void EndGame()
        {
            Console.WriteLine("Vous avez marqué " + _playerScore.ToString() + " points.");
            Console.WriteLine("L'IA a marqué " + _IAscore.ToString() + " points.");

            if (_playerScore > _IAscore)
            {
                Console.WriteLine("Bien joué !");
            }
            else if (_IAscore > _playerScore) 
            {
                Console.WriteLine("Pas de Chance !");
            }
            else
            {
                Console.WriteLine("Match nul !");
            }

            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
