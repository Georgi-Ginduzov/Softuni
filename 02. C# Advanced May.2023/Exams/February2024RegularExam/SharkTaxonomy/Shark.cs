using System.Text;

namespace SharkTaxonomy
{
    public class Shark
    {
        public string Kind { get; set; }
        public int Length { get; set; }
        public string Food { get; set; }
        public string Habitat { get; set; }

        public Shark(string kind, int length, string food, string habitat)
        {
            Kind = kind;
            Length = length;
            Food = food;
            Habitat = habitat;
        }



        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Kind} shark: {Length}m long.");
            output.AppendLine($"Could be spotted in the {Habitat}, typical menu: {Food}");

            return output.ToString().Trim();
        }
    }
}
