﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.TicTacToeClasses
{
    public class AiOpponent
    {
        public TicTacToeTeam AiTeam { get; set; }

        public AiOpponent(TicTacToeTeam team)
        {
            AiTeam = team;
        }

        public Square GetBestMove(Grid grid)
        {
            var PossibleMoves = new List<PossibleMove>();

            foreach (var move in grid.PossibleMoves)
            {
                var possibleMove = EvaluateMove(grid, move);

                if (possibleMove.ResultingTeam == AiTeam) return possibleMove.Square;

                PossibleMoves.Add(possibleMove);
            }

            if (PossibleMoves.Count == 0) return null;

            // Randomizes moves then gives top move
            //return PossibleMoves
            //    .OrderBy(x => Guid.NewGuid())
            //    .ThenBy(x => x.ResultingTeam)
            //    .Select(x => x.Square)
            //    .First();

            var newPossibleMoves = PossibleMoves
                .OrderBy(x => Guid.NewGuid())
                .ToList();

            PossibleMoves = newPossibleMoves.OrderBy(x => x.ResultingTeam).ToList(); 

            return PossibleMoves.Select(x => x.Square).First();
        }

        private PossibleMove EvaluateMove(Grid grid, Square move)
        {
            TicTacToeTeam resultingTeam = TicTacToeTeam.None;

            // Checks for whether AI has won.
            move.Status = (SquareStatus)AiTeam;
            if (grid.GetWinner() == AiTeam)
            {
                resultingTeam = AiTeam;
            }
            move.Status = SquareStatus.Empty;

            // Checks for whether player has won.
            move.Status = AiTeam == TicTacToeTeam.Circle 
                ? (SquareStatus)TicTacToeTeam.Cross 
                : (SquareStatus)TicTacToeTeam.Circle;
            if (grid.GetWinner() == (TicTacToeTeam)move.Status)
            {
                resultingTeam = (TicTacToeTeam)move.Status;
            }
            move.Status = SquareStatus.Empty;

            return new PossibleMove
            {
                Square = move,
                ResultingTeam = resultingTeam
            };
        }
    }
}