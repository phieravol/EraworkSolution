using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Confiuration
{
    public class OrderRequestConfiguration : IEntityTypeConfiguration<OrderRequest>
    {
        public readonly int StatusWaiting = 0;
        public readonly int StatusApproved = 1;
        public readonly int StatusRejected = -1;
        
        public void Configure(EntityTypeBuilder<OrderRequest> builder)
        {
            // config table name Order_Request
            builder.ToTable("OrderRequest");

            // Config primary key OrderRequestId
            builder.HasKey(x => x.OrderRequestId);

            // Config default value for isApprove is 0
            builder.Property(x => x.IsApprove)
                .IsRequired()
                .HasDefaultValue(StatusWaiting);

            // config reference key to Post
            builder.HasOne(x => x.Post)
                .WithMany(o => o.OrderRequests)
                .HasForeignKey(p => p.PostId);

            // Config reference key to Service
            builder.HasOne(x => x.Service)
                .WithMany(o => o.OrderRequests)
                .HasForeignKey(s => s.ServiceId);
        }
    }
}
