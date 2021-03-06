﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Core.EntityModels.Localization;

namespace Net.Core.Repositories.Configuration
{
    internal class LocalizationKeyConfiguration : IEntityTypeConfiguration<LocalizationKey>
    {
        public void Configure(EntityTypeBuilder<LocalizationKey> builder)
        {
            builder.ToTable("LocalizationKeys").HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.LocalizationKeyCode)
                .HasColumnName("LocalizationKey")
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(x => x.EnglishValue)
                .HasColumnName("EnglishValue")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.IrishValue)
                .HasColumnName("IrishValue")
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();

            builder.Property(x => x.IsActive)
            .HasColumnName("IsActive")
            .HasColumnType("bit")
            .IsRequired();
        }
    }
}
