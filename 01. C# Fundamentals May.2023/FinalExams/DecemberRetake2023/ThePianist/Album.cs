using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePianist
{
    public class Album
    {
        private List<Piece> pieces;

        public Album()
        {
            this.Pieces = new List<Piece>();
        }

        public List<Piece> Pieces { get; set; }

        public void AddPiece(Piece piece)
        {
            bool isContained = false;
            foreach (var item in Pieces)
            {
                if (item.Name == piece.Name)
                {
                    isContained = true;
                }
            }

            if (isContained)
            {
                Console.WriteLine($"{piece.Name} is already in the collection!");
            }
            else
            {
                Console.WriteLine($"{piece.Name} by {piece.Composer} in {piece.Key} added to the collection!");                
                Pieces.Add(piece);                
            }
        }

        public void RemovePiece(string pieceName)
        {
            Piece pieceToRemove = null;

            foreach (var piece in Pieces)
            {
                if (piece.Name == pieceName)
                {
                    pieceToRemove = piece;
                }
            }

            if (pieceToRemove != null)
            {
                Pieces.Remove(pieceToRemove);
                Console.WriteLine($"Successfully removed {pieceName}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }
        }

        public void ChangeKey(string pieceName, string newKey)
        {
            Piece pieceToChange = null;

            foreach (var piece in Pieces)
            {
                if (piece.Name == pieceName)
                {
                    pieceToChange = piece;
                }
            }

            if (pieceToChange != null)
            {
                pieceToChange.Key = newKey;
                Console.WriteLine($"Changed the key of {pieceToChange.Name} to {pieceToChange.Key}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }
        }

        public void PrintAllPieces()
        {
            foreach (Piece piece in Pieces)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }
}
