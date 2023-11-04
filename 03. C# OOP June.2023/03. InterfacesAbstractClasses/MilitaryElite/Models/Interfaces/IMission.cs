using MilitaryElite.Enums;
namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public State state {get;}
        void CompleteMission();
    }
}
