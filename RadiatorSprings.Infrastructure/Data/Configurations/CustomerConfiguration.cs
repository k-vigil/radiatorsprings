namespace RadiatorSprings.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.FirstName)
            .IsRequired();

        builder.OwnsOne(p => p.Document, builder =>
        {
            builder.Property(p => p.DocumentType)
                .HasColumnName("DocumentType")
                .IsRequired();

            builder.Property(p => p.DocumentNumber)
                .HasColumnName("DocumentNumber")
                .IsRequired();
        });
    }
}
