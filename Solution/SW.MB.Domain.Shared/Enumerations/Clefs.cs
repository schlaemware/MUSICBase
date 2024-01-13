namespace SW.MB.Domain.Shared.Enumerations {
    /// <summary>
    /// Clefs
    /// </summary>
    /// <remarks>
    /// Notenschlüssel
    /// </remarks>
    [Flags]
    public enum Clefs {
        /// <summary>
        /// Treble clef
        /// </summary>
        /// <remarks>
        /// Violinschlüssel
        /// </remarks>
        Treble,
        /// <summary>
        /// Bass clef
        /// </summary>
        /// <remarks>
        /// Bassschlüssel
        /// </remarks>
        Bass,
        /// <summary>
        /// Tenor clef
        /// </summary>
        /// <remarks>
        /// Tenorschlüssel
        /// </remarks>
        Tenor,
        /// <summary>
        /// Rhythm clef
        /// </summary>
        /// <remarks>
        /// Rhythmusschlüssel
        /// </remarks>
        Rhythm
    }
}
