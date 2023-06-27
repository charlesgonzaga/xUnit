namespace ProjetoTeste.Application.Produtos;

public record ProdutoEntity
{
    public int Id { get; init; }
    public string Title { get; init; } = default!;
    public decimal Price { get; init; }
    public string Description { get; init; } = default!;
    public string Category { get; init; } = default!;
    public string Image { get; init; } = default!;
    public RatingEntity Rating { get; init; } = default!;

    public record RatingEntity
    {
        public double Rate { get; init; }
        public int Count { get; init; }
    }
}