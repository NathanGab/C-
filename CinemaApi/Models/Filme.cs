namespace CinemaApi.Models {

    public class Filme {

        public int filmeId { get; set; }

        public string? nome { get; set; }

        public string? genero { get; set; }

        public int ano { get; set; }

        public int cinemaId { get; set; }
    }
}