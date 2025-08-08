namespace GestaoClinica.DTO;

public class ServicoDTO
{
    public int IdServico { get; set; }
    public string NomeServico { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int DuracaoEstimada { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime UltimaAtualizacao { get; set; }
    public int CategoriaId { get; set; }
    public CategoriaDTO? Categoria { get; set; }
}

public class ServicoCreateDTO
{
    public string NomeServico { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int DuracaoEstimada { get; set; }
    public bool Ativo { get; set; } = true;
    public int CategoriaId { get; set; }
}

public class ServicoUpdateDTO
{
    public string? NomeServico { get; set; }
    public string? Descricao { get; set; }
    public decimal? Preco { get; set; }
    public int? DuracaoEstimada { get; set; }
    public bool? Ativo { get; set; }
    public int? CategoriaId { get; set; }
}