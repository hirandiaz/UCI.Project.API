using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCI.Project.Domain.Entities;

namespace UCI.Project.Infraestructure.Data.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserId)
               .HasColumnName("UserID")
               .IsRequired(false);

            builder.Property(e => e.Message)
                .HasColumnName("Message")
                .IsRequired();

            builder.Property(e => e.DateTime)
                .HasColumnName("CreationDate")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
