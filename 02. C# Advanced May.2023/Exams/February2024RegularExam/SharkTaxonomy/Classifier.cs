using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark> ();
        }
        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;
        public bool uniqueShark(Shark shark) => !Species.Contains(shark);
        public bool canAddShark(Shark shark) => Capacity > GetCount && uniqueShark(shark);
        public Shark GetSharkByKind(string kind) => Species.Find(n => n.Kind == kind);
        public string GetLargestShark() => Species.MaxBy(n => n.Length).ToString();
        public double GetAverageLength() => Species.Average(n => n.Length);

        public void AddShark(Shark shark)
        {
            if (canAddShark(shark))
            {
                Species.Add(shark);
            }
        }
        public bool RemoveShark(string kind)
        {
            Shark sharkToBeRemoved = GetSharkByKind(kind);

            if (sharkToBeRemoved != null)
            {
                return Species.Remove(sharkToBeRemoved);
            }
            return false;
        }
        public string Report()
        
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Species.Count} sharks classified:");
            foreach (Shark shark in Species)
            {
                output.AppendLine(shark.ToString());
            }

            return output.ToString().Trim();
        }

    }
}
