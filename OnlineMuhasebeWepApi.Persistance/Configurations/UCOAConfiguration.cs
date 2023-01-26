using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeWepApi.Domain.CompanyEntities;
using OnlineMuhasebeWepApi.Persistance.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Persistance.Configurations
{
    public sealed class UCOAConfiguration : IEntityTypeConfiguration<UCOA>
    {
        public void Configure(EntityTypeBuilder<UCOA> builder)
        {
            builder.ToTable(TableNames.UCOA);
            builder.HasKey(p => p.Id);
        }
    }
}
