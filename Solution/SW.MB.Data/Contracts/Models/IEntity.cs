namespace SW.MB.Data.Contracts.Models {
    public interface IEntity {
        public int ID { get; }
        public DateTime Created { get; }
        public int CreatedBy { get; }
        public DateTime Updated { get; }
        public int UpdatedBy { get; }
    }
}
