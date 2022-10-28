namespace SW.MB.Domain.Extensions {
    public static class RandomExtensions {
        private static readonly string[] BAND_NAMES = new string[] { 
            "ABBA", "AC/DC", "Aerosmith", "A-ha",
            "BackstreetBoys", "Beach Boys", "Bee Gees", "Black Sabbath", "Blur", "Bon Jovi", "Boney M.",
            "Coldplay", "Creedence Clearwater Revival",
            "Deep Purple", "Depeche Mode",
            "Eagles", "Earth, Wind & Fire",
            "Fäaschtbänkler", "Foo Fighters",
            "Genesis", "Green Day", "Guns N' Roses",
            "Iron Maiden",
            "Kiss", "Kool & The Gang",
            "Led Zeppelin", "Linkin Park", "Lynyrd Skynyrd",
            "Maroon 5", "Metallica", "Motörhead", "Muse",
            "Nickelback", "Nirvana",
            "Oasis", "One Direction", "OneRepublic",
            "Pink Floyd",
            "Queen",
            "Radiohead", "Red Hot Chili Peppers", "Roxette",
            "Santana", "Simon & Garfunkel", "Snow Patrol", "Spice Girls", "Status Quo",
            "Take That", "Toto",
            "The Beatles", "The Black Eyed Peas", "The Doors", "The Kelly Family", "The Offspring", "The Pointer Sisters", "The Prodigy", "The Rolling Stones", "The Scorpions",
            "U2",
            "Van Halen",
            "Wham!",
            "ZZ Top"
        };

        public static string NextBandName(this Random random) {
            return BAND_NAMES[random.Next(BAND_NAMES.Length)];
        }
    }
}