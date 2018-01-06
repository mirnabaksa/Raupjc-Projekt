﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Picterest.Models;
using System.Data.Entity;

namespace Picterest.Data
{
    public class GalleryDbContext : DbContext
    {
        public IDbSet<Image> Images { get; set; }
        public IDbSet<Album> Albums { get; set; }

        public GalleryDbContext(string cnnstr) : base(cnnstr)
        {

        }

        public GalleryDbContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasKey(item => item.AlbumId);
            modelBuilder.Entity<Image>().HasKey(label => label.ImageId);

            //many - many
            modelBuilder.Entity<Album>()
                .HasMany(item => item.Images)
                .WithMany(image => image.Albums);
        }
    }
}