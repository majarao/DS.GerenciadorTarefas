using DS.GerenciadorTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.GerenciadorTarefas.Infra.Configurations;

public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Titulo)
            .HasColumnName("Titulo")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(300);

        builder.Property(t => t.DataCriacao)
            .HasColumnName("DataCriacao")
            .IsRequired();

        builder.Property(t => t.DataConclusao)
            .HasColumnName("DataConclusao");

        builder.Property(t => t.Status)
            .HasColumnName("Status")
            .IsRequired();
    }
}
