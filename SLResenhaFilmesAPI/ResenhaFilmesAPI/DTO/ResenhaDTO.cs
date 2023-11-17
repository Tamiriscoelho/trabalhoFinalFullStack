namespace ResenhaFilmesAPI.DTO
{
    public class ResenhaDTO
    {
        public int Id { get; set; }

        public int Nota { get; set; }

        public string Comentario { get; set; } = string.Empty;
    }
}
