namespace SW.MB.Data.Contracts.Models {
    public interface IPerson : IEntity {
        public string Firstname { get; }
        public string Lastname { get; }
        public DateTime? DateOfBirth { get; }
    }
}
