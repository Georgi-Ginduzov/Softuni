namespace ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split("|");
            string name = input[0];
            string composer = input[1];
            string key = input[2];

            Album album = new Album();

            for (int i = 0; i < numberOfPieces; i++)
            {
                album.Pieces.Add(new Piece(name, composer, key));

                input = Console.ReadLine().Split("|");
                name = input[0];
                composer = input[1];
                key = input[2];
            }
            Console.WriteLine(); Console.WriteLine();
            while (input[0] != "Stop")
            {
                name = input[1];
                
                switch (input[0])
                {
                    case "Add":
                        composer = input[2];
                        key = input[3];

                        album.AddPiece(new Piece(name, composer, key));
                        break;

                    case "Remove":
                        album.RemovePiece(name);
                        break;

                    case "ChangeKey":
                        key = input[2];
                        album.ChangeKey(name, key);
                    break;

                    default:
                        break;
                }


                input = Console.ReadLine().Split("|");
            }
            album.PrintAllPieces();
        }
    }
}
